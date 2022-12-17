using MergeToStay.Services;
using UnityEngine;

namespace MergeToStay.Data.Rewards
{
	[CreateAssetMenu(fileName = "NEW_CARDreward", menuName = "MergeToSlay.REWARDS/new CARD reward", order = 1)]
	public class CardRewardData : RewardBase
	{
		public CardsModel.CardRarity CardRarity;
		
		public override GameObject GetView(BattleRewardsService service)
		{
			return service.GetRewardViewForCard();
		}
	}
}