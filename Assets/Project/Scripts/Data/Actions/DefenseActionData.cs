using UnityEngine;

namespace MergeToStay.Data
{
	[CreateAssetMenu(fileName = "NEW_DEFENSE", menuName = "MergeToSlay.CARD/new DEFENSE action", order = 1)]
	public class DefenseActionData : ScriptableObject
	{
		[Range(1, 100)]
		public int Value = 1;
	}
}