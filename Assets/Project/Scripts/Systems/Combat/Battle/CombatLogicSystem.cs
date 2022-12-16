using System.Collections.Generic;
using Entitas;

namespace MergeToStay.Systems.Combat.Battle
{
	public class CombatLogicSystem : ReactiveGameSystem
	{
		protected override void Execute(List<GameEntity> entities) {  }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return _contexts.game.CreateCollector(GameMatcher.ChangeCombatStateEvent);
		}
		protected override bool Filter(GameEntity entity) { return entity.hasChangeCombatStateEvent; }
	}
}