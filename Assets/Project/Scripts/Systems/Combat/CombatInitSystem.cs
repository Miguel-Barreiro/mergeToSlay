using System.Collections.Generic;
using Entitas;
using MergeToStay.Components.Combat.Battle;
using MergeToStay.Core;
using MergeToStay.Data;
using MergeToStay.Services;
using MergeToStay.Systems.Combat.Battle;
using UnityEngine;
using Zenject;

namespace MergeToStay.Systems.Combat
{
	public class CombatInitSystem : ReactiveGameSystem, IInitializeSystem
	{

		[Inject] private PrefabFactoryPool _prefabFactoryPool;
		[Inject] private GameContext _context;
		[Inject] private GameConfigData _gameConfigData;
		[Inject] private BoardService _boardService;
		[Inject] private CombatService _combatService;
		[Inject] private GridObjectService _gridObjectService;
		private IGroup<GameEntity> _batleGroup;
		private IGroup<GameEntity> _boardGroup;
		private IGroup<GameEntity> _playerGroup;

		public void Initialize()
		{
			_batleGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Battle));
			_boardGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Board));
			_playerGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
			
			GameEntity newBoard = _boardService.CreateNewBoard(5, 5);

			GameEntity battleEntity = _context.CreateEntity();
			battleEntity.AddBattle(new List<GameEntity>(), _gameConfigData.StartingDrawLevel, 
									Components.Combat.Battle.Battle.BattleState.Init, 
									 new TurnStats(), new Effects() );
		}

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity boardEntity = _boardGroup.GetSingleEntity();
			GameEntity battleEntity = _batleGroup.GetSingleEntity();
			GameEntity playerEntity = _playerGroup.GetSingleEntity();
			// TODO: here is where we set the current battle details

			CombatData combatData = _gameConfigData.DebugCombatData;

			List<GameEntity> enemies = AddEnemiesFromData(combatData);

			if (battleEntity == null)
			{
				battleEntity = _context.CreateEntity();
				battleEntity.AddBattle(enemies, playerEntity.player.DrawLevel, 
										Components.Combat.Battle.Battle.BattleState.Init, 
										new TurnStats(), new Effects() );
			} else
			{
				battleEntity.ReplaceBattle(enemies, playerEntity.player.DrawLevel, 
											Components.Combat.Battle.Battle.BattleState.Init, 
											new TurnStats(), new Effects() );
			}

			_boardService.ClearBoard(boardEntity);
			_combatService.CreateGameStateChange(Components.Combat.Battle.Battle.BattleState.Draw);
			
			foreach (GameEntity eventEntity in entities)
				eventEntity.Destroy();
		}

		private List<GameEntity> AddEnemiesFromData(CombatData combatData)
		{
			List<GameEntity> result = new List<GameEntity>();
			foreach (EnemyData enemyData in combatData.Enemies)
			{
				result.Add(CreateEnemy(enemyData));
			}

			return result;
		}
		
		public GameEntity CreateEnemy(EnemyData enemyData)
		{
			GameEntity newEnemy = _context.CreateEntity();
			newEnemy.AddEnemy(null, enemyData, enemyData.Hp, new TurnStats(), new Effects(), 0, 0 );

			return newEnemy;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.StartCombatEvent);
		}
		protected override bool Filter(GameEntity entity) { return entity.hasStartCombatEvent; }
	}
}