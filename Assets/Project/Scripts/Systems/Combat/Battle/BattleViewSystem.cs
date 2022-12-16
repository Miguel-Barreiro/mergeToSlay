using Entitas;
using MergeToStay.Components.Combat.Battle;
using MergeToStay.Core;
using MergeToStay.MonoBehaviours.Combat;
using UnityEngine;
using Zenject;

namespace MergeToStay.Systems.Combat.Battle
{
	public class BattleViewSystem : IExecuteSystem, IInitializeSystem
	{
		
		[Inject] private Contexts _contexts;
		[Inject] private BattleView _battleView;
		[Inject] private PrefabFactoryPool _prefabFactoryPool;
		
		private IGroup<GameEntity> _batleGroup;

		public void Execute()
		{
			GameEntity battleEntity = _batleGroup.GetSingleEntity();
			Components.Combat.Battle.Battle battle = battleEntity.battle;

			int spot = 0;
			foreach (GameEntity enemyEntity in battle.Enemies)
			{
				if(spot > 2)
					return;
				
				Enemy enemy = enemyEntity.enemy;
				if ( enemy.View == null )
					enemy.View = _prefabFactoryPool.NewEnemy(enemy.EnemyData.Prefab);

				RectTransform rectTransform = enemy.View.GetComponent<RectTransform>();
				
				RectTransform enemySpot = _battleView.EnemySpots[spot];
				
				enemy.View.transform.localPosition = Vector3.zero;
				enemy.View.transform.SetParent(enemySpot, false);
				rectTransform.sizeDelta = Vector2.zero;
				rectTransform.localScale = Vector3.one;


				EnemyStatusView statusView = _battleView.EnemyStatusViews[spot];

				UpdateEnemyStatus(statusView, enemy);

				spot++;
			}
		}

		private static void UpdateEnemyStatus(EnemyStatusView statusView, Enemy enemy)
		{
			statusView.HpLabel.text = enemy.Hp.ToString();
		}

		public void Initialize() { _batleGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Battle)); }
		

	}
}