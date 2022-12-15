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
			foreach (Enemy enemy in battle.Enemies)
			{
				if ( enemy.View == null )
					enemy.View = _prefabFactoryPool.NewEnemy(enemy.EnemyData.Prefab);

				enemy.View.transform.localPosition = Vector3.zero;
				enemy.View.transform.SetParent(_battleView.EnemySpots[spot]);
				
				

			}
			
		}
	}
}