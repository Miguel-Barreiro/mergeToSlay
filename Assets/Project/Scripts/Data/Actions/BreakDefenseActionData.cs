using MergeToStay.Data.Actions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MergeToStay.Data
{
	[CreateAssetMenu(fileName = "NEW_BreakDefense", menuName = "MergeToSlay.CARD/new BREAK DEFENSE action", order = 1)]
	public class BreakDefenseActionData : ActionBase
	{
		[Range(1, 100)]
		public int Value = 1;
		
		[Title("Targets")]
		[EnumToggleButtons]
		public ActionsModel.CombatTargetsEnum CombatTargets = ActionsModel.CombatTargetsEnum.FORWARD;
	}
}