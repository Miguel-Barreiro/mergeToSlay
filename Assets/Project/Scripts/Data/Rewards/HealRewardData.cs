using MergeToStay.Services;
using UnityEngine;

namespace MergeToStay.Data.Rewards
{
	[CreateAssetMenu(fileName = "NEW_healReward", menuName = "MergeToSlay.REWARDS/new HEAL reward", order = 1)]
	public class HealRewardData : RewardBase
	{
		[Range(0, 100)] 
		public int Value = 0;

		[Range(0, 100)] 
		public int ValuePercentage = 0;

		public override GameObject GetView(BattleRewardsService service)
		{
			return service.GetRewardViewForHeal(Value);
		}

	}
}