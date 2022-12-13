using Sirenix.OdinInspector;
using UnityEngine;

namespace MergeToStay.Data
{
	[CreateAssetMenu(fileName = "NewAttack", menuName = "MergeToSlay/new attack action", order = 1)]
	public class AttackActionData : ActionBase
	{
		[Range(1, 100)]
		public int Value = 1;
		
		[Title("Targets")]
		[EnumToggleButtons]
		public TargetsEnum Targets;
		
		[System.Flags]
		public enum TargetsEnum
		{
			FOWARD = 1 << 1,
			MIDDLE1 = 1 << 2,
			MIDDLE2 = 1 << 3,
			BACK = 1 << 4,
			ALL = FOWARD | MIDDLE1 | MIDDLE2 | BACK
		}
	}
}