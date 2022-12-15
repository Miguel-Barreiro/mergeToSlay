using System.Collections.Generic;
using Entitas;

namespace MergeToStay.Systems.Combat.Board
{
	public abstract class BoardReactiveSystem : ReactiveGameSystem
	{
		abstract protected void _execute(GameEntity boardEntity);
		
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Board);
		}
		protected override bool Filter(GameEntity entity) { return entity.hasBoard; }

		protected override void Execute(List<GameEntity> entities)
		{
			if (entities.Count > 0)
			{
				GameEntity boardEntity = entities[0];
				if (!boardEntity.hasBoard)
					return;
				_execute(boardEntity);
			}
		}

	}
}