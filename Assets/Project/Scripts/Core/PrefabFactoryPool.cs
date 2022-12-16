using MergeToStay.Data;
using MergeToStay.MonoBehaviours;
using UnityEngine;
using Zenject;

namespace MergeToStay.Core
{
	public class PrefabFactoryPool
	{
		// TODO: add object pools
		
		[Inject] private RootView _rootView;
		[Inject] private GameConfigData _gameConfig;

		public GameObject NewGridObject(GameObject prefab)
		{
			if (prefab == null)
				prefab = _gameConfig.DefaultGridObjetView;
			
			return GameObject.Instantiate(prefab, _rootView.GridObjectsRoot);
		}


		public GameObject NewEnemy(GameObject enemyDataPrefab)
		{
			if (enemyDataPrefab == null)
				enemyDataPrefab = _gameConfig.DefaultEnemyView;
			
			return GameObject.Instantiate(enemyDataPrefab, _rootView.BattleRoot);
		}

		public GameObject NewRewardCard(GameObject prefab)
		{
			if (prefab == null)
				prefab = _gameConfig.RewardCardPrefab;
			
			return GameObject.Instantiate(prefab, _rootView.BattleRoot);
		}

		public void Destroy(GameObject view)
		{
			GameObject.Destroy(view);
		}
	}
}