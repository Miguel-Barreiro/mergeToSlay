using System.Collections.Generic;
using Entitas;
using MergeToSlay.Core;
using MergeToStay.Systems;
using Zenject;

namespace MergeToSlay.Systems
{
	 public class GridObjectDragSystem : ReactiveGameSystem, IInitializeSystem
	{
		
		[Inject]
		private Contexts _contexts;
		private IGroup<GameEntity> _boardGroup;

		public void Initialize()
		{
			_boardGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Board));
		}
		
		protected override void Execute(List<GameEntity> entities)
		{
			Log.Normal(entities.ToString());
			
			GameEntity boardEntity = _boardGroup.GetSingleEntity();
			if (!boardEntity.hasBoard)
				return;
			
			
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