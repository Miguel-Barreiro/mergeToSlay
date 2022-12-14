using MergeToSlay.Core;
using MergeToSlay.Data;
using UnityEngine;
using Zenject;

namespace MergeToSlay.Services
{
	public sealed class GridObjectService
	{
		[Inject] private GameContext _context;
		[Inject] private GameConfigData _gameConfigData;
		[Inject] private PrefabFactoryPool _prefabFactoryPool;

		public GameEntity CreateNewGridObjectFromCard(CardData cardData)
		{
			GameEntity result = _context.CreateEntity();
			GameObject prefab = cardData.LevelData[0].Prefab;
			
			if (prefab == null)
				prefab = _gameConfigData.DefaultGridObjetView;
			
			GameObject newView = _prefabFactoryPool.NewGridObject(prefab);
			result.AddGridObject( cardData, 0, newView, null);
			return result;
		}
	}
}