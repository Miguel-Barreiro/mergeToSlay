using System.Collections.Generic;
using Entitas;
using MergeToSlay.Core;

namespace MergeToSlay.Systems
{
	 public class GridObjectDragSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;

		public GridObjectDragSystem(Contexts contexts) : base(contexts.game)
		{
			_contexts = contexts;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			Log.Normal(entities.ToString());
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