using UnityEngine;

namespace MergeToSlay.Core
{
	public class PrefabFactoryPool
	{
		// TODO: add object pools

		public GameObject New(GameObject prefab)
		{
			return GameObject.Instantiate(prefab);
		}


	}
}