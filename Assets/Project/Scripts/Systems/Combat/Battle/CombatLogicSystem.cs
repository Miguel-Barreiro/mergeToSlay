using System.Collections.Generic;
using Entitas;

namespace MergeToStay.Systems.Combat.Battle
{
	public class CombatLogicSystem : ReactiveGameSystem
	{
		
		private IGroup<GameEntity> _batleGroup;

		public void Initialize()
		{
			_batleGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Battle));
		}

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity battleEntity = _batleGroup.GetSingleEntity();


			foreach (GameEntity eventEntity in entities)
			{
				
				
				eventEntity.Destroy();
			}
			
			
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return _contexts.game.CreateCollector(GameMatcher.ChangeCombatStateEvent);
		}
		protected override bool Filter(GameEntity entity) { return entity.hasChangeCombatStateEvent; }
	}
}