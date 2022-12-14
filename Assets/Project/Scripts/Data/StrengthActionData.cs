using Sirenix.OdinInspector;
using UnityEngine;

namespace MergeToStay.Data
{
	[CreateAssetMenu(fileName = "NEW_StrengthAction", menuName = "MergeToSlay.CARD/new STRENGTH action", order = 1)]
	public class StrengthActionData : ActionBase
	{
		[Title("Targets")] 
		[EnumToggleButtons] 
		public Actions.CombatTargetsEnum CombatTargets = Actions.CombatTargetsEnum.FORWARD;		
	}
}

