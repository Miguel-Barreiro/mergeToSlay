using Sirenix.OdinInspector;
using UnityEngine;

namespace MergeToSlay.Data.Actions
{
	[CreateAssetMenu(fileName = "NEW_ATTACK", menuName = "MergeToSlay.CARD/new ATTACK action", order = 1)]
	public class AttackActionData : ActionBase
	{
		[Range(1, 100)]
		public int Value = 1;
		
		[Title("Targets")]
		[EnumToggleButtons]
		public ActionsModel.CombatTargetsEnum CombatTargets = ActionsModel.CombatTargetsEnum.FORWARD;
		

	}
}