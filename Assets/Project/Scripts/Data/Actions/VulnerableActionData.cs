using MergeToSlay.Data.Actions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MergeToSlay.Data
{
	[CreateAssetMenu(fileName = "NEW_VulnerableAction", menuName = "MergeToSlay.CARD/new VULNERABLE action", order = 1)]
	public class VulnerableActionData : ActionBase
	{
		[Title("Targets")] 
		[EnumToggleButtons] 
		public ActionsModel.CombatTargetsEnum CombatTargets = ActionsModel.CombatTargetsEnum.FORWARD;		
	}
}
