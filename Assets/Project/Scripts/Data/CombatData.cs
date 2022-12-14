using System.Collections.Generic;
using MergeToSlay.Data.Rewards;
using UnityEngine;

namespace MergeToSlay.Data
{
	[CreateAssetMenu(fileName = "NEW_COMBAT_DATA", menuName = "MergeToSlay.COMBAT/new COMBAT", order = 0)]
	public class CombatData : ScriptableObject
	{

		[SerializeField]
		public List<EnemyData> Enemies;

		[SerializeField]
		public List<RewardBase> Rewards;

	}
}