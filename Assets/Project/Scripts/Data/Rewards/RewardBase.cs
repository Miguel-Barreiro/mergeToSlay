using MergeToStay.Services;
using UnityEngine;

namespace MergeToStay.Data.Rewards
{
	public class RewardBase : ScriptableObject
	{
		public virtual void Execute() {}

		public virtual GameObject GetView(BattleRewardsService service)
		{
			return null;
		}
	}
}