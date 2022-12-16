using System.Collections.Generic;
using Entitas;
using MergeToStay.Components.Combat.Battle;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.Combat.Battle
{
	// public class EnemiesSystem : ReactiveGameSystem, IInitializeSystem
	public class EnemiesSystem : IExecuteSystem, IInitializeSystem
	{

		[Inject] private Contexts _contexts;
		[Inject] private CombatService _combatService;
		
		private IGroup<GameEntity> _batleGroup;
		private IGroup<GameEntity> _enemyGroup;


		public void Initialize()
		{
			_enemyGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy));
			_batleGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Battle));
		}

		public void Execute() 
		// protected override void Execute(List<GameEntity> entities)
		{
			GameEntity battleEntity = _batleGroup.GetSingleEntity();
			Components.Combat.Battle.Battle battle = battleEntity.battle;

			GameEntity[] enemies = _enemyGroup.GetEntities();

			foreach (GameEntity enemyEntity in enemies)
			{
				Enemy enemy = enemyEntity.enemy;

				if (enemy.Hp <= 0)
				{
					battle.Enemies.Remove(enemyEntity);
					battleEntity.ReplaceBattle(battle.Enemies, battle.CardDrawLevel);
					enemyEntity.Destroy();
				}
				
			}
			
		}

		// protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		// {
		// 	return context.CreateCollector(GameMatcher.Enemy);
		// }
		//
		// protected override bool Filter(GameEntity entity) { return entity.hasEnemy; }
	}
}