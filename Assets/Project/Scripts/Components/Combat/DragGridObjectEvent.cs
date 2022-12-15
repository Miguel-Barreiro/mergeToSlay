using Entitas;
using UnityEngine;

namespace MergeToStay.Components.Combat
{
	public class DragGridObjectEvent : IComponent
	{
		public bool InvalidDrag = false;
		public Vector2 DraggedCell;
		public Vector2 TargetCell;
	}
}