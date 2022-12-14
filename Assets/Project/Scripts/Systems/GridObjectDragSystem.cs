using System.Collections.Generic;
using Entitas;
using MergeToSlay.Core;

namespace MergeToSlay.Systems
{
	 public class GridObjectDragSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private readonly Contexts _contexts;
		private IGroup<GameEntity> _boardGroup;

		public GridObjectDragSystem(Contexts contexts) : base(contexts.game)
		{
			_contexts = contexts;
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

		public void Initialize()
		{
			_boardGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Board));
		}
	}
}