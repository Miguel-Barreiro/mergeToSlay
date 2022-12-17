using System.Collections.Generic;
using System.ComponentModel;
using Entitas;
using MergeToStay.Components.Player;
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
		[Inject] private DiContainer _container;
		[Inject] private GameContext _context;
		[Inject] private CombatService _combatService;
		[Inject] private GameConfigData _gameConfigData;
		[Inject] private PrefabFactoryPool _prefabFactoryPool;

		public GameEntity CreateLoadBattleRewardsEvent()
		{
			GameEntity result = _context.CreateEntity();
			result.isLoadBattleRewardsEvent = true;

			return result;
		}

		public void ExecuteDrawLevelReward(int drawLevel)
		{
			IGroup<GameEntity> playerGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
			GameEntity playerEntity = playerGroup.GetSingleEntity();
			PlayerComponent player = playerEntity.player;

			player.DrawLevel += drawLevel;
			ResetPlayer(playerEntity);
		}

		public void ExecuteHealReward(int healQuantity)
		{
			IGroup<GameEntity> playerGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
			GameEntity playerEntity = playerGroup.GetSingleEntity();
			_combatService.HealPlayer(playerEntity, healQuantity);
		}

		public void ExecuteGoldReward(int gold)
		{
			IGroup<GameEntity> playerGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
			GameEntity playerEntity = playerGroup.GetSingleEntity();
			PlayerComponent player = playerEntity.player;

			player.Gold += gold;
			ResetPlayer(playerEntity);
		}
		
		public void ExecuteCardReward(int rewardIndex)
		{
			IGroup<GameEntity> playerGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
			GameEntity playerEntity = playerGroup.GetSingleEntity();
			IGroup<GameEntity> battleGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Battle));
			GameEntity battleEntity = battleGroup.GetSingleEntity();

			List<RewardBase> rewards = battleEntity.battle.CombatData.Rewards;
			
			CardsModel.Card card = _gameConfigData.RewardCardList.Cards[rewardIndex];

			PlayerComponent player = playerEntity.player;
			player.Deck.Cards.Add(card);
			ResetPlayer(playerEntity);

		}

		private static void ResetPlayer(GameEntity playerEntity)
		{
			PlayerComponent player = playerEntity.player;
			playerEntity.ReplacePlayer(player.Health, player.Gold, player.DrawLevel, player.Deck);
		}


		public GameObject GetRewardViewForCard()
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
			
			GameObject rewardCard = _prefabFactoryPool.NewRewardCard(_gameConfigData.RewardCardPrefab, _container);
			RewardCardView rewardCardView = rewardCard.GetComponent<RewardCardView>();
			CardLevelData randomCardLevel = randomCard.CardData.LevelData[card.Level];
			rewardCardView.UpdateValues(randomCardLevel.Icon, randomCard.CardData.Name, randomCardIndex, RewardCardView.RewardType.Card);
		
			return rewardCardView.gameObject;
		}

		public GameObject GetRewardViewForDrawLevel(int drawLevel)
		{
			GameObject rewardCard = _prefabFactoryPool.NewRewardCard(_gameConfigData.RewardCardPrefab, _container);
			RewardCardView rewardCardView = rewardCard.GetComponent<RewardCardView>();
			rewardCardView.UpdateValues(_gameConfigData.DrawLevelRewardViewIcon, "+" + drawLevel + " draw level", drawLevel, RewardCardView.RewardType.DrawLevel);
			return rewardCardView.gameObject;
		}

		public GameObject GetRewardViewForGold(int gold)
		{
			GameObject rewardCard = _prefabFactoryPool.NewRewardCard(_gameConfigData.RewardCardPrefab, _container);
			RewardCardView rewardCardView = rewardCard.GetComponent<RewardCardView>();
			rewardCardView.UpdateValues(_gameConfigData.DrawLevelRewardViewIcon, "+ " + gold + " gold", gold, RewardCardView.RewardType.Gold);
			return rewardCardView.gameObject;
		}

		public GameObject GetRewardViewForHeal(int healAmount)
		{
			GameObject rewardCard = _prefabFactoryPool.NewRewardCard(_gameConfigData.RewardCardPrefab, _container);
			RewardCardView rewardCardView = rewardCard.GetComponent<RewardCardView>();
			rewardCardView.UpdateValues(_gameConfigData.DrawLevelRewardViewIcon, "heal for " + healAmount , healAmount, RewardCardView.RewardType.Heal);
			return rewardCardView.gameObject;
		}
	}
}