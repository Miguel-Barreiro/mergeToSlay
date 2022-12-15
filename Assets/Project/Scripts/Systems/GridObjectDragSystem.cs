using System.Collections.Generic;
using Entitas;
using MergeToStay.Components;
using MergeToStay.Core;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems
{
	 public class GridObjectDragSystem : ReactiveGameSystem, IInitializeSystem
	{
		
		[Inject] private Contexts _contexts;
		[Inject] private BoardService _boardService;
		
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
				DragGridObjectEvent draggedEvent = draggedEventEntity.dragGridObjectEvent;
				if (!draggedEvent.targetBattle && draggedEvent.TargetCell!=null)
				{
					GameEntity gridObject = _boardService.GetGridObjectAt(boardEntity, draggedEvent.DraggedCell);
					if (gridObject == null)
						return;
					
					_boardService.MoveGridObject(boardEntity, gridObject, draggedEvent.TargetCell.Value);
				}
			}
			
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector( GameMatcher.DragGridObjectEvent);
		}
		protected override bool Filter(GameEntity entity)
		{
			return entity.hasDragGridObjectEvent;
		}

	}
}