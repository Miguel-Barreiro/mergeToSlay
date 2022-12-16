using System.Collections.Generic;
using Entitas;
using MergeToStay.Components.Player;
using MergeToStay.Data;
using MergeToStay.MonoBehaviours.Camp;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.Combat
{
	public class BuyShopCardSystem : ReactiveGameSystem, IInitializeSystem
	{
		[Inject] private ShopView _shopView;
		[Inject] private ShopService _shopService;

		private IGroup<GameEntity> _playerGroup;
		private IGroup<GameEntity> _shopGroup;

		public void Initialize()
		{
			_playerGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
			_shopGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Shop));
		}

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity playerEntity = _playerGroup.GetSingleEntity();
			GameEntity shopEntity = _shopGroup.GetSingleEntity();
			if (!playerEntity.hasPlayer || !shopEntity.hasShop)
				return;

			foreach (GameEntity entity in entities)
			{
				bool wasBought = _shopService.BuyShopCard(playerEntity, shopEntity.shop, entity.buyShopCardEvent.ShopCardIndex);
				if (wasBought)
				{
					
				}
			}
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.BuyShopCardEvent);
		}

		protected override bool Filter(GameEntity entity) => entity.hasBuyShopCardEvent;
	}
}