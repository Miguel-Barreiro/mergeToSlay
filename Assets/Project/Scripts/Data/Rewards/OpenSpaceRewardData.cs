using UnityEngine;

namespace MergeToStay.Data.Rewards
{
	[CreateAssetMenu(fileName = "NEW_OpenSpaceReward", menuName = "MergeToSlay.REWARDS/new OPEN_SPACE reward", order = 1)]
	public class OpenSpaceRewardData : RewardBase
	{
		[Range(1, 5)] 
		public int Value = 1;	
	}
}