using System.Collections.Generic;
using Entitas;
using MergeToStay.Components.Combat;
using MergeToStay.Data;
using MergeToStay.Data.Actions;
using MergeToStay.Services;
using UnityEngine;
using Zenject;

namespace MergeToStay.Systems.Combat.Board
{
	 public class ExecuteBattleDragSystem : ReactiveGameSystem, IInitializeSystem
	{
		
		[Inject] private BoardService _boardService;
		[Inject] private CombatService _combatService;
		
		private IGroup<GameEntity> _boardGroup;
		private IGroup<GameEntity> _battleGroup;
		private IGroup<GameEntity> _playerGroup;

		public void Initialize()
		{
			_playerGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
			_boardGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Board));
			_battleGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Battle));
		}
		
		protected override void Execute(List<GameEntity> entities)
		{

			GameEntity boardEntity = _boardGroup.GetSingleEntity();
			if (!boardEntity.hasBoard)
				return;

			GameEntity battleEntity = _battleGroup.GetSingleEntity();
			if (!battleEntity.hasBattle)
				return;
			
			GameEntity playerEntity = _playerGroup.GetSingleEntity();
			if (!playerEntity.hasPlayer)
				return;
			

			foreach (GameEntity draggedEventEntity in entities)
			{
				Vector2 originCell = draggedEventEntity.gridObjectUseEvent.originCell;
				GameEntity gridObject = _boardService.GetGridObjectAt(boardEntity, originCell);
				if (gridObject != null)
				{
					ExecuteGridObjectActions(boardEntity, battleEntity, playerEntity, gridObject);
					_boardService.RemoveGridObject(boardEntity, originCell);
				}

				draggedEventEntity.Destroy();
			}
		}

		private void ExecuteGridObjectActions(GameEntity boardEntity, GameEntity battleEntity, GameEntity playerEntity, GameEntity gridObjectEntity)
		{
			BoardComponent board = boardEntity.board;

			GridObject gridObject = gridObjectEntity.gridObject;
			CardData gridObjectCardData = gridObject.CardData;
			CardLevelData cardLevelData = gridObjectCardData.LevelData[gridObject.Level];
			foreach (ActionBase action in cardLevelData.Actions)
			{
				action.Execute(battleEntity, boardEntity, playerEntity, _combatService, _boardService);
			}
			
		}


		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector( GameMatcher.GridObjectUseEvent);
		}
		protected override bool Filter(GameEntity entity) { return entity.hasGridObjectUseEvent; }

	}
}