using MergeToStay.Services;
using UnityEngine;

namespace MergeToStay.Data.Rewards
{
	[CreateAssetMenu(fileName = "NEW_DrawLvlReward", menuName = "MergeToSlay.REWARDS/new DRAW_LVL reward", order = 1)]
	public class DrawLvlRewardData : RewardBase
	{
		[Range(1, 5)] 
		public int Value = 1;
		
		public override GameObject GetView(BattleRewardsService service)
		{
			return service.GetRewardViewForDrawLevel(Value);
		}

	}
}