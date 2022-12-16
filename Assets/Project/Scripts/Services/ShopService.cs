using System;
using System.Collections.Generic;
using MergeToStay.Components.Player;
using MergeToStay.Components.Shop;
using MergeToStay.Data;
using Zenject;

namespace MergeToStay.Services
{
	public class ShopService
	{
		[Inject] private GameContext _context;
		[Inject] private CardList _cardListData;

		public (CardData randomCard, CardLevelData randomCardLevel) CreateAShopCard(ShopComponent shop)
		{
			Random random = new Random();

			int randomCardIndex = random.Next(_cardListData.AllCards.Count);
			CardData randomCard = _cardListData.AllCards[randomCardIndex];

			int randomLevelIndex = random.Next(randomCard.LevelData.Length);
			CardLevelData randomCardLevel = randomCard.LevelData[randomLevelIndex];

			shop.Cards.Add(new CardsModel.Card
			{
				CardData = randomCard,
				Level = randomLevelIndex
			});

			return (randomCard, randomCardLevel);
		}

		public bool BuyShopCard(GameEntity playerEntity, ShopComponent shop, int shopCardIndex)
		{
			CardsModel.Card card = shop.Cards[shopCardIndex];

			CardLevelData cardLevelData = card.CardData.LevelData[card.Level];
			PlayerComponent player = playerEntity.player;
			if (player.Gold >= cardLevelData.Price)
			{
				player.Deck.Cards.Add(card);
				int newPlayerGold = player.Gold - cardLevelData.Price;
				playerEntity.ReplacePlayer(player.Health, newPlayerGold, player.DrawLevel, player.Deck);

				return true;
			}
			
			return false;
		}

		public GameEntity CreateShopComponent()
		{
			GameEntity result = _context.CreateEntity();
			result.ReplaceShop(new List<CardsModel.Card>());

			return result;
		}

		public GameEntity CreateBuyShopCardEvent(int shopCardIndex)
		{
			GameEntity result = _context.CreateEntity();
			result.AddBuyShopCardEvent(shopCardIndex);

			return result;
		}

		public GameEntity CreateLoadShopCardsEvent()
		{
			GameEntity result = _context.CreateEntity();
			result.isLoadShopCardsEvent = true;

			return result;
		}
	}
}