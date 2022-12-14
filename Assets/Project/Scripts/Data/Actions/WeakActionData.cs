using MergeToStay.Data.Actions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MergeToStay.Data
{
	[CreateAssetMenu(fileName = "NEW_Weak", menuName = "MergeToSlay.CARD/new WEAK action", order = 1)]
	public class WeakActionData : ActionBase
	{
		[Range(1, 5)]
		public int turns = 1;
		
		[Title("Targets")]
		[EnumToggleButtons]
		public ActionsModel.CombatTargetsEnum CombatTargets = ActionsModel.CombatTargetsEnum.FORWARD;
	}
}