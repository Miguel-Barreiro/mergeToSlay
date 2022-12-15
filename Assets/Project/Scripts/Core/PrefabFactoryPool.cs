using MergeToStay.MonoBehaviours;
using UnityEngine;
using Zenject;

namespace MergeToStay.Core
{
	public class PrefabFactoryPool
	{
		// TODO: add object pools
		
		[Inject]
		private RootView _rootView;

		public GameObject NewGridObject(GameObject prefab)
		{
			return GameObject.Instantiate(prefab, _rootView.GridObjectsRoot);
		}

		public void Destroy(GameObject view)
		{
			GameObject.Destroy(view);
		}

		public GameObject NewEnemy(GameObject enemyDataPrefab)
		{
			return GameObject.Instantiate(enemyDataPrefab, _rootView.BattleRoot);
		}
	}
}