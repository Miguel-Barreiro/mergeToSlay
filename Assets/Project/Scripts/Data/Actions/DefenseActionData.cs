using MergeToSlay.Data.Actions;
using UnityEngine;

namespace MergeToSlay.Data
{
	[CreateAssetMenu(fileName = "NEW_DEFENSE", menuName = "MergeToSlay.CARD/new DEFENSE action", order = 1)]
	public class DefenseActionData : ActionBase
	{
		[Range(1, 100)]
		public int Value = 1;
	}
}