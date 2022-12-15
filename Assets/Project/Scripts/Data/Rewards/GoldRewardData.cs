using UnityEngine;

namespace MergeToStay.Data.Rewards
{
	[CreateAssetMenu(fileName = "NEW_GoldReward", menuName = "MergeToSlay.REWARDS/new GOLD reward", order = 1)]
	public class GoldRewardData : RewardBase
	{
		[Range(1, 100)] 
		public int Value = 10;

	}
}