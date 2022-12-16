using System.Collections.Generic;
using Entitas;
using MergeToStay.Components.Player;
using MergeToStay.Components.Shop;
using MergeToStay.Core;
using MergeToStay.Data;
using MergeToStay.Data.Rewards;
using MergeToStay.MonoBehaviours.Camp;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace MergeToStay.Services
{
	public class BattleRewardsService
	{
		[Inject] private GameContext _context;
		[Inject] private GameConfigData _gameConfigData;
		[Inject] private PrefabFactoryPool _prefabFactoryPool;

		public GameEntity CreateLoadBattleRewardsEvent()
		{
			GameEntity result = _context.CreateEntity();
			result.isLoadBattleRewardsEvent = true;

			return result;
		}

		public void ExecuteReward(int rewardIndex)
		{
			IGroup<GameEntity> battleGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Battle));
			GameEntity battleEntity = battleGroup.GetSingleEntity();
			RewardBase reward = battleEntity.battle.CombatData.Rewards[rewardIndex];
			reward.Execute();
		}

		public void EarnCard(CardsModel.Card card)
		{
			IGroup<GameEntity> playerGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
			GameEntity playerEntity = playerGroup.GetSingleEntity();
			IGroup<GameEntity> battleGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Battle));
			GameEntity battleEntity = battleGroup.GetSingleEntity();

			List<RewardBase> rewards = battleEntity.battle.CombatData.Rewards;
			
			CardsModel.Card card = _gameConfigData.RewardCardList.Cards[shopCardIndex];

			PlayerComponent player = playerEntity.player;
			player.Deck.Cards.Add(card);
			playerEntity.ReplacePlayer(player.Health, player.Gold, player.DrawLevel, player.Deck);
		}

		public (CardsModel.Card card, RewardCardView view) GetRewardViewForCard()
		{
			Random random = new Random();

			List<CardsModel.Card> rewardCards = _gameConfigData.RewardCardList.Cards;

			int randomCardIndex = random.Next(rewardCards.Count);
			CardsModel.Card randomCard = rewardCards[randomCardIndex];

			CardsModel.Card card = new CardsModel.Card
			{
				CardData = randomCard.CardData,
				Level = randomCard.Level
			};
			
			GameObject rewardCard = _prefabFactoryPool.NewRewardCard(_gameConfigData.RewardCardPrefab);
			RewardCardView rewardCardView = rewardCard.GetComponent<RewardCardView>();
			CardLevelData randomCardLevel = randomCard.CardData.LevelData[card.Level];
			rewardCardView.UpdateValues(randomCardLevel.Icon, randomCard.CardData.Name, randomCardLevel.Price);

			return (card, rewardCardView);
		}
	}
}