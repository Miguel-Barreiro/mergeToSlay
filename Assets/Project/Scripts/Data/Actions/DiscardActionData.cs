using MergeToSlay.Data.Actions;
using UnityEngine;

namespace MergeToSlay.Data
{
	[CreateAssetMenu(fileName = "NEW_DISCARD", menuName = "MergeToSlay.CARD/new DISCARD action", order = 1)]
	public class DiscardActionData: ActionBase
	{
		[Range(1, 5)]
		public int Value = 1;
	}
}

