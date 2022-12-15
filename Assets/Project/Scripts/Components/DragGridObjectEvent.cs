using Entitas;
using UnityEngine;

namespace MergeToStay.Components
{
	public class DragGridObjectEvent : IComponent
	{
		public Vector2 DraggedCell;
		
		public Vector2? TargetCell;
		public bool targetBattle = false;
	}
}