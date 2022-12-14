using System.Collections.Generic;
using UnityEngine;

namespace MergeToSlay.Data.Rewards
{
	[CreateAssetMenu(fileName = "NEW_CARDreward", menuName = "MergeToSlay.REWARDS/new CARD reward", order = 1)]
	public class CardRewardData : RewardBase
	{
		[Range(1, 5)]
		public int Value = 1;

	}
}