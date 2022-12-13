using Sirenix.OdinInspector;
using UnityEngine;

namespace MergeToStay.Data
{
	[CreateAssetMenu(fileName = "NEW_ATTACK", menuName = "MergeToSlay/new ATTACK action", order = 1)]
	public class AttackActionData : ActionBase
	{
		[Range(1, 100)]
		public int Value = 1;
		
		[Title("Targets")]
		[EnumToggleButtons]
		public Actions.TargetsEnum Targets = Actions.TargetsEnum.FORWARD;
		

	}
}