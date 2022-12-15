using Entitas;
using UnityEngine;

namespace MergeToStay.Components.Combat
{
	public class DragGridObjectEvent : IComponent
	{
		public Vector2 DraggedCell;
		public Vector2 TargetCell;
	}
}