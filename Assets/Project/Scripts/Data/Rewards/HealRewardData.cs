using UnityEngine;

namespace MergeToSlay.Data.Rewards
{
	[CreateAssetMenu(fileName = "NEW_healReward", menuName = "MergeToSlay.REWARDS/new HEAL reward", order = 1)]
	public class HealRewardData : RewardBase
	{
		[Range(0, 100)] 
		public int Value = 0;

		[Range(0, 100)] 
		public int ValuePercentage = 0;

	}
}