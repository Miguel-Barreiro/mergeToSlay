using Entitas;
using MergeToStay.Components;
using MergeToStay.Components.Combat;
using MergeToStay.Services;
using UnityEngine;
using Zenject;

namespace MergeToStay.Systems.Combat.Board
{
	public class DragGridObjectUpdateViewSystem : IExecuteSystem, IInitializeSystem
	{
		[Inject]
		private BoardService _boardService;
		
		[Inject] private Contexts _contexts;

		private IGroup<GameEntity> _boardGroup;
		private IGroup<GameEntity> _dragUpdateEventGroup;
		
		public void Execute()
		{
			GameEntity boardEntity = _boardGroup.GetSingleEntity();
			if (!boardEntity.hasBoard)
				return;

			Camera camera = Camera.main;

			GameEntity[] entities = _dragUpdateEventGroup.GetEntities();
			foreach (GameEntity gameEntity in entities)
			{
				DragGridObjectUpdateComponent dragGridObjectUpdate = gameEntity.dragGridObjectUpdate;

				GameEntity gridObject = _boardService.GetGridObjectAt(boardEntity, dragGridObjectUpdate.OriginCell);
				if (gridObject == null || !gridObject.hasGridObject)
					return;

				GameObject gridObjectView = gridObject.gridObject.View;

				if (dragGridObjectUpdate.DraggedGameObject == null)
					dragGridObjectUpdate.DraggedGameObject = gridObjectView;

				if (Input.touches.Length > 0)
				{
					Touch touch = Input.touches[0];
					gridObjectView.transform.position = touch.position;
				}
			}
			
		}

		public void Initialize()
		{
			_dragUpdateEventGroup = _contexts.game.GetGroup(GameMatcher.DragGridObjectUpdate);
			_boardGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Board));
		}

	}
}