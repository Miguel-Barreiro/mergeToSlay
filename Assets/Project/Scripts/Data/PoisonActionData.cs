using Sirenix.OdinInspector;
using UnityEngine;

namespace MergeToStay.Data
{
	[CreateAssetMenu(fileName = "NEW_POISON", menuName = "MergeToSlay.CARD/new POISON action", order = 1)]
	public class PoisonActionData : ActionBase
	{
		[Range(1, 5)]
		public int Value = 1;
		
		[Title("Targets")]
		[EnumToggleButtons]
		public Actions.CombatTargetsEnum CombatTargets = Actions.CombatTargetsEnum.FORWARD;

	}
}



