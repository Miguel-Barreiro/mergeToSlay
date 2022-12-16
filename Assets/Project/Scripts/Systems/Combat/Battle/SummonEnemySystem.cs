using System.Collections.Generic;
using Entitas;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.Combat.Battle
{
	public class SummonEnemySystem : ReactiveGameSystem, IInitializeSystem
	{
		[Inject]
		private CombatService _combatService;
		
		private IGroup<GameEntity> _batleGroup;

		public void Initialize()
		{
			_batleGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Battle));
		}

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity battleEntity = _batleGroup.GetSingleEntity();
			if (battleEntity == null)
				return;

			foreach (GameEntity eventEntity in entities)
			{
				_combatService.SummonEnemy(battleEntity, eventEntity.summonEnemyEvent.EnemyData, eventEntity.summonEnemyEvent.Position);
				eventEntity.Destroy();
			}

		}
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.SummonEnemyEvent);
		}
		protected override bool Filter(GameEntity entity) { return entity.hasSummonEnemyEvent; }
	}
}