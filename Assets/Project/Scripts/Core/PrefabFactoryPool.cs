using MergeToStay.MonoBehaviours;
using UnityEngine;
using Zenject;

namespace MergeToSlay.Core
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


	}
}