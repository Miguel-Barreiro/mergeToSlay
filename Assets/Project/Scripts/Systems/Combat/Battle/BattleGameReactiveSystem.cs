using System.Collections.Generic;
using Entitas;

namespace MergeToStay.Systems.Combat.Battle
{
	public abstract class BattleGameReactiveSystem : ReactiveGameSystem
	{
		abstract protected void React(GameEntity battleEntity);
		
		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity battleEntity = entities[0];
			React(battleEntity);
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Battle);
		}
		protected override bool Filter(GameEntity entity) { return entity.hasBattle; }
	}
}