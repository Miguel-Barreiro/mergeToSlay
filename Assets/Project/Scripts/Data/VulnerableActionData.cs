using Sirenix.OdinInspector;
using UnityEngine;

namespace MergeToStay.Data
{
	[CreateAssetMenu(fileName = "NEW_VulnerableAction", menuName = "MergeToSlay.CARD/new VULNERABLE action", order = 1)]
	public class VulnerableActionData : ActionBase
	{
		[Title("Targets")] 
		[EnumToggleButtons] 
		public Actions.CombatTargetsEnum CombatTargets = Actions.CombatTargetsEnum.FORWARD;		
	}
}
