using MergeToSlay.Data.Actions;
using UnityEngine;

namespace MergeToSlay.Data
{
	[CreateAssetMenu(fileName = "NEW_DRAW", menuName = "MergeToSlay.CARD/new DRAW action", order = 1)]
	public class DrawActionData : ActionBase
	{
		[Range(1, 5)]
		public int Value = 1;
	}
}



