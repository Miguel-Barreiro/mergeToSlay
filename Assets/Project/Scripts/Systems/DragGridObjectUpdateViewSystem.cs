using System.Collections.Generic;
using Entitas;
using MergeToSlay.Components;
using MergeToSlay.Services;
using UnityEngine;
using Zenject;

namespace MergeToSlay.Systems
{
	public class DragGridObjectUpdateViewSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		[Inject]
		private BoardService _boardService;
		
		private readonly Contexts _contexts;
		private IGroup<GameEntity> _boardGroup;

		public DragGridObjectUpdateViewSystem(Contexts contexts) : base(contexts.game)
		{
			_contexts = contexts;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.DragGridObjectUpdate);
		}
		protected override bool Filter(GameEntity entity) { return true; }

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity boardEntity = _boardGroup.GetSingleEntity();
			if (!boardEntity.hasBoard)
				return;
			
			foreach (GameEntity gameEntity in entities)
			{
				DragGridObjectUpdateComponent dragGridObjectUpdate = gameEntity.dragGridObjectUpdate;

				GameEntity gridObject = _boardService.GetGridObjectAt(boardEntity.board, dragGridObjectUpdate.OriginCell);
				if (gridObject == null || !gridObject.hasGridObject)
					return;

				GameObject gridObjectView = gridObject.gridObject.View;

				if (dragGridObjectUpdate.DraggedGameObject == null)
					dragGridObjectUpdate.DraggedGameObject = gridObjectView;

				if (Input.touches.Length > 0)
				{
					Touch touch = Input.touches[0];
					gridObjectView.transform.position = Camera.main.ScreenToWorldPoint(touch.position);
				}
			}
			
		}

		public void Initialize()
		{
			_boardGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Board));
		}
	}
}