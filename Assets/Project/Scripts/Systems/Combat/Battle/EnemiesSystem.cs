using System.Collections.Generic;
using Entitas;
using MergeToStay.Components.Combat.Battle;
using MergeToStay.Core;
using MergeToStay.MonoBehaviours;
using MergeToStay.MonoBehaviours.Combat;
using MergeToStay.Services;
using UnityEngine;
using Zenject;

namespace MergeToStay.Systems.Combat.Battle
{
	// public class EnemiesSystem : ReactiveGameSystem, IInitializeSystem
	public class EnemiesSystem : IExecuteSystem, IInitializeSystem
	{

		[Inject] private Contexts _contexts;
		[Inject] private CombatService _combatService;
		[Inject] private BattleView _battleView;
		[Inject] private PrefabFactoryPool _prefabFactoryPool;
		[Inject] private ViewService _viewService;
		
		private IGroup<GameEntity> _batleGroup;
		private IGroup<GameEntity> _enemyGroup;


		public void Initialize()
		{
			_enemyGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy));
			_batleGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Battle));
		}

		public void Execute() 
		{
			GameEntity battleEntity = _batleGroup.GetSingleEntity();
			Components.Combat.Battle.Battle battle = battleEntity.battle;
			if (battle.State == Components.Combat.Battle.Battle.BattleState.Init)
				return;

			GameEntity[] enemies = _enemyGroup.GetEntities();

			foreach (GameEntity enemyEntity in enemies)
			{
				Enemy enemy = enemyEntity.enemy;

				if (enemy.Hp <= 0)
				{
					battle.Enemies.Remove(enemyEntity);
					_combatService.ResetBattle(battleEntity);
					_prefabFactoryPool.Destroy(enemy.View);
					
					enemyEntity.Destroy();
					continue;
				}
			}

			if (battle.Enemies.Count == 0)
			{
				battle.State = Components.Combat.Battle.Battle.BattleState.Init;
				_viewService.CreateShowViewEvent(View.BattleRewards);
			}

			
		}
	}
}