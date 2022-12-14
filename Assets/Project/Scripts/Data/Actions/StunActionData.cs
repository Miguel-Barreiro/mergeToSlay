
using MergeToSlay.Data.Actions;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace MergeToSlay.Data
{
	[CreateAssetMenu(fileName = "NEW_STUN", menuName = "MergeToSlay.CARD/new STUN action", order = 1)]
	public class StunActionData : ActionBase
	{

		[Range(1, 5)]
		public int Turns = 1;
		
		[Title("Targets")]
		[EnumToggleButtons]
		public ActionsModel.CombatTargetsEnum CombatTargets = ActionsModel.CombatTargetsEnum.FORWARD;
	}
}
