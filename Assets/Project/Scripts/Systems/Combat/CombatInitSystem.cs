using System.Collections.Generic;
using Entitas;
using MergeToStay.Data;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.Combat
{
	public class CombatInitSystem : ReactiveGameSystem, IInitializeSystem
	{

		[Inject] private GameContext _context;
		[Inject] private GameConfigData _gameConfigData;
		[Inject] private BoardService _boardService;
		[Inject] private CombatService _combatService;
		[Inject] private GridObjectService _gridObjectService;
		private IGroup<GameEntity> _batleGroup;

		public void Initialize()
		{
			_batleGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Battle));
			
			GameEntity newBoard = _boardService.CreateNewBoard(5, 5);

			GameEntity battleEntity = _context.CreateEntity();
			battleEntity.AddBattle(new List<GameEntity>(), _gameConfigData.StartingDrawLevel);
		}

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity battleEntity = _batleGroup.GetSingleEntity();
			// TODO: here is where we set the current battle details
			
			if (battleEntity == null)
			{
				battleEntity = _context.CreateEntity();
				battleEntity.AddBattle(new List<GameEntity>(), _gameConfigData.StartingDrawLevel);
			} else
			{
				battleEntity.ReplaceBattle(new List<GameEntity>(), _gameConfigData.StartingDrawLevel);
			}
			
			foreach (GameEntity eventEntity in entities)
				eventEntity.Destroy();
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.StartCombatEvent);
		}
		protected override bool Filter(GameEntity entity) { return entity.hasStartCombatEvent; }
	}
}