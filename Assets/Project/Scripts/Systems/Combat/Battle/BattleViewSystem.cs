using MergeToStay.Components.Combat.Battle;
using MergeToStay.Core;
using MergeToStay.MonoBehaviours.Combat;
using UnityEngine;
using Zenject;

namespace MergeToStay.Systems.Combat.Battle
{
	public class BattleViewSystem : BattleGameReactiveSystem
	{
		[Inject] private BattleView _battleView;
		[Inject] private PrefabFactoryPool _prefabFactoryPool;
		
		protected override void React(GameEntity battleEntity)
		{
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
				spot++;
			}
			
		}
	}
}