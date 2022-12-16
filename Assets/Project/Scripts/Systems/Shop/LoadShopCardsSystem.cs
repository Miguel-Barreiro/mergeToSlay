using System.Collections.Generic;
using Entitas;
using MergeToStay.Data;
using MergeToStay.MonoBehaviours.Camp;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.Combat
{
	public class LoadShopCardsSystem : ReactiveGameSystem, IInitializeSystem
	{
		[Inject] private ShopView _shopView;
		[Inject] private ShopService _shopService;

		private IGroup<GameEntity> _shopGroup;

		public void Initialize()
		{
			_shopGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Shop));
			_shopService.CreateShopComponent();
		}

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity shopEntity = _shopGroup.GetSingleEntity();
			if (!shopEntity.hasShop)
				return;

			foreach (ShopCardView cardView in _shopView.CardViews)
			{
				(CardData randomCard, int level) = _shopService.CreateAShopCard(shopEntity.shop);
				CardLevelData randomCardLevel = randomCard.LevelData[level];
				cardView.UpdateValues(randomCardLevel.Icon, randomCard.Name, randomCardLevel.Price);
			}
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.LoadShopCardsEvent);
		}

		protected override bool Filter(GameEntity entity) => entity.isLoadShopCardsEvent;
	}
}