using MergeToStay.Core;
using MergeToStay.Data;
using UnityEngine;
using Zenject;

namespace MergeToStay.Services
{
	public sealed class GridObjectService
	{
		[Inject] private GameContext _context;
		[Inject] private GameConfigData _gameConfigData;
		[Inject] private PrefabFactoryPool _prefabFactoryPool;

		public GameEntity CreateNewGridObjectFromCard(CardData cardData, int level = 0)
		{
			GameEntity result = _context.CreateEntity();
			GameObject prefab = cardData.LevelData[0].Prefab;
			
			if (prefab == null)
				prefab = _gameConfigData.DefaultGridObjetView;
			
			GameObject newView = _prefabFactoryPool.NewGridObject(prefab);
			result.AddGridObject( cardData, level, newView, null);
			return result;
		}

		public bool IsValid(GameEntity targetGridObject)
		{
			return targetGridObject is {isEnabled: true};
		}
	}
}