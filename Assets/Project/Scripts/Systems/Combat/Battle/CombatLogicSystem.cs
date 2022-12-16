using System.Collections.Generic;
using Entitas;
using MergeToStay.Components.Combat;
using MergeToStay.Components.Combat.Battle;
using MergeToStay.Data;
using MergeToStay.MonoBehaviours.Combat;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.Combat.Battle
{
	public class CombatLogicSystem : ReactiveGameSystem, IInitializeSystem
	{

		[Inject] private GameContext _context;
		[Inject] private BoardView _boardView;
		[Inject] private CombatService _combatService;
		[Inject] private BoardService _boardService;
		
		private IGroup<GameEntity> _batleGroup;
		private IGroup<GameEntity> _playerGroup;
		private IGroup<GameEntity> _boardGroup;
		public void Initialize()
		{
			_boardGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Board));
			_batleGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Battle));
			_playerGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
		}

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity battleEntity = _batleGroup.GetSingleEntity();
			GameEntity playerEntity = _playerGroup.GetSingleEntity();
			GameEntity boardEntity = _boardGroup.GetSingleEntity();
			Components.Combat.Battle.Battle battle = battleEntity.battle;
			
			foreach (GameEntity eventEntity in entities)
			{
				ChangeCombatStateEvent changeCombatStateEvent = eventEntity.changeCombatStateEvent;

				switch (battle.State)
				{
					case Components.Combat.Battle.Battle.BattleState.Draw:
						if (changeCombatStateEvent.NewState == Components.Combat.Battle.Battle.BattleState.Play)
						{
							_boardView.EndTurnButton.gameObject.SetActive(true);
							_boardView.ToggleDrag(true);
							ChangeCombatState(battleEntity, boardEntity, playerEntity, changeCombatStateEvent.NewState);
						}
						break;
					case Components.Combat.Battle.Battle.BattleState.Play:
						if (changeCombatStateEvent.NewState == Components.Combat.Battle.Battle.BattleState.EnemyTurn)
						{
							_boardView.EndTurnButton.gameObject.SetActive(false);
							_boardView.ToggleDrag(false);
							ChangeCombatState(battleEntity, boardEntity, playerEntity, changeCombatStateEvent.NewState);
						}
						break;
					case Components.Combat.Battle.Battle.BattleState.EnemyTurn:
						if (changeCombatStateEvent.NewState == Components.Combat.Battle.Battle.BattleState.Draw)
						{
							_boardView.EndTurnButton.gameObject.SetActive(false);
							_boardView.ToggleDrag(false);
							ChangeCombatState(battleEntity, boardEntity, playerEntity, changeCombatStateEvent.NewState);
						}
						break;
					case Components.Combat.Battle.Battle.BattleState.Init:
						if (changeCombatStateEvent.NewState == Components.Combat.Battle.Battle.BattleState.Draw)
						{
							_combatService.ResetFullBattleStats(battleEntity, playerEntity);
							_boardView.EndTurnButton.gameObject.SetActive(false);
							_boardView.ToggleDrag(false);
							ChangeCombatState(battleEntity, boardEntity, playerEntity, changeCombatStateEvent.NewState);
						}
						break;
				}

				eventEntity.Destroy();
			}
			
			
		}

		private void ChangeCombatState(GameEntity battleEntity, GameEntity boardEntity, GameEntity playerEntity, 
											Components.Combat.Battle.Battle.BattleState newState)
		{
			Components.Combat.Battle.Battle battle = battleEntity.battle;
			battle.State = newState;
			_combatService.ResetBattle(battleEntity);

			switch (newState)
			{
				case Components.Combat.Battle.Battle.BattleState.Draw:
					ExecuteDraw(battleEntity);
					break;
				case Components.Combat.Battle.Battle.BattleState.EnemyTurn:
					ExecuteEnemyTurn(battleEntity, boardEntity, playerEntity);
					break;
				case Components.Combat.Battle.Battle.BattleState.Play:
					ExecutePlay();
					break;
			}
			
		}

		private void ExecutePlay()
		{
			
		}

		private void ExecuteEnemyTurn(GameEntity battleEntity, GameEntity boardEntity, GameEntity playerEntity)
		{
			// needs to happen first to allow enemies to defend
			_combatService.ResetBattleTurnStats(battleEntity);
			
			//TODO: PLAY ENEMY ACTIONS
			foreach (GameEntity enemyEntity in battleEntity.battle.Enemies)
			{
				Enemy enemy = enemyEntity.enemy;
				List<CombatSequence> behaviours = enemy.EnemyData.CombatBehaviours;
				CombatSequence currentCombatSequence = behaviours[enemy.CurrentBehaviourSequenceIndex];
				
				if (enemy.CurrentBehaviourSequenceTurn< 0 || 
						enemy.CurrentBehaviourSequenceTurn >= currentCombatSequence.TurnActionsSequence.Count)
				{
					_combatService.PickNewRandonEnemyBehaviour(enemyEntity);
					currentCombatSequence = behaviours[enemy.CurrentBehaviourSequenceIndex];
				}

				TurnActions turnActions = currentCombatSequence.TurnActionsSequence[enemy.CurrentBehaviourSequenceTurn];
				foreach (TurnAction turnAction in turnActions.Actions)
					turnAction.Action.ExecuteEnemyBehaviour(battleEntity, boardEntity, enemyEntity, playerEntity,
															_combatService, _boardService);

				enemy.CurrentBehaviourSequenceTurn++;
			}

			_combatService.CreateGameStateChange(Components.Combat.Battle.Battle.BattleState.Draw);
		}

		private void ExecuteDraw(GameEntity battleEntity)
		{
			//TODO: PLAY TURN EFFECTS
			
			PickEnemyBehaviours(battleEntity);
			
			
			Components.Combat.Battle.Battle battle = battleEntity.battle;
			_combatService.CreateDrawCardEvent(battle.CardDrawLevel);
			_combatService.CreateGameStateChange(Components.Combat.Battle.Battle.BattleState.Play);
		}

		private void PickEnemyBehaviours(GameEntity battleEntity)
		{
			foreach (GameEntity enemyEntity in battleEntity.battle.Enemies)
			{
				Enemy enemy = enemyEntity.enemy;
				List<CombatSequence> behaviours = enemy.EnemyData.CombatBehaviours;
				CombatSequence currentCombatSequence = behaviours[enemy.CurrentBehaviourSequenceIndex];

				if (enemy.CurrentBehaviourSequenceTurn < 0 ||
					enemy.CurrentBehaviourSequenceTurn >= currentCombatSequence.TurnActionsSequence.Count)
				{
					_combatService.PickNewRandonEnemyBehaviour(enemyEntity);
				}
			}
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.ChangeCombatStateEvent);
		}
		protected override bool Filter(GameEntity entity) { return entity.hasChangeCombatStateEvent; }
	}
}