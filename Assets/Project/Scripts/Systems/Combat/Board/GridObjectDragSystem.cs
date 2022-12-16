using System.Collections.Generic;
using Entitas;
using MergeToStay.Components;
using MergeToStay.Components.Combat;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.Combat.Board
{
	 public class GridObjectDragSystem : ReactiveGameSystem, IInitializeSystem
	{
		
		[Inject] private BoardService _boardService;
		[Inject] private CombatService _combatService;
		
		private IGroup<GameEntity> _boardGroup;

		public void Initialize()
		{
			_boardGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Board));
		}
		
		protected override void Execute(List<GameEntity> entities)
		{

			GameEntity boardEntity = _boardGroup.GetSingleEntity();
			if (!boardEntity.hasBoard)
				return;

			foreach (GameEntity draggedEventEntity in entities)
			{
				if (draggedEventEntity.dragGridObjectEvent.InvalidDrag)
					HandleInvalidDragEvent(draggedEventEntity, boardEntity);
				else
					HandleDragEvent(draggedEventEntity, boardEntity);
				draggedEventEntity.Destroy();
			}
		}
		private void HandleInvalidDragEvent(GameEntity draggedEventEntity, GameEntity boardEntity)
		{
			DragGridObjectEvent draggedEvent = draggedEventEntity.dragGridObjectEvent;
			GameEntity gridObject = _boardService.GetGridObjectAt(boardEntity, draggedEvent.DraggedCell);
			if (gridObject == null)
				return;
			
			_boardService.ResetBoardView(boardEntity);
		}
		
		private void HandleDragEvent(GameEntity draggedEventEntity, GameEntity boardEntity)
		{
			DragGridObjectEvent draggedEvent = draggedEventEntity.dragGridObjectEvent;
			GameEntity gridObject = _boardService.GetGridObjectAt(boardEntity, draggedEvent.DraggedCell);
			if (gridObject == null)
				return;
			
			GameEntity targetGridObject = _boardService.GetGridObjectAt(boardEntity, draggedEvent.TargetCell);
			if (targetGridObject != null && targetGridObject == gridObject)
			{
				HandleInvalidDragEvent(draggedEventEntity, boardEntity);
				return;	
			}
			
			if (targetGridObject != null && targetGridObject != gridObject)
			{ 
				_combatService.CreateMergeEvent(draggedEvent.DraggedCell, draggedEvent.TargetCell); 
				return;
			}

			_boardService.MoveGridObject(boardEntity, gridObject, draggedEvent.TargetCell);
		}
		

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector( GameMatcher.DragGridObjectEvent);
		}
		protected override bool Filter(GameEntity entity) { return entity.hasDragGridObjectEvent; }

	}
}