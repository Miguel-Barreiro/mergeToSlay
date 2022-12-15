using System.Collections.Generic;
using Entitas;

namespace MergeToStay.Systems.Path
{
	public abstract class PathReactiveSystem : ReactiveGameSystem
	{
		protected abstract void React(GameEntity pathEntity);
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Path);
		}

		protected override bool Filter(GameEntity entity) => entity.hasPath;

		protected override void Execute(List<GameEntity> entities)
		{
			if (entities.Count <= 0)
				return;

			GameEntity pathEntity = entities[0];
			if (pathEntity.hasPath)
				React(pathEntity);
		}

	}
}