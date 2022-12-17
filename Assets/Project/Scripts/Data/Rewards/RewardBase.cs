using MergeToStay.Services;
using UnityEngine;

namespace MergeToStay.Data.Rewards
{
	public class RewardBase : ScriptableObject
	{
		// public virtual int Execute(BattleRewardsService service) { return -1; }

		public virtual GameObject GetView(BattleRewardsService service)
		{
			return null;
		}
	}
}