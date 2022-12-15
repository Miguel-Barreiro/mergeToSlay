using Entitas;
using UnityEngine;

namespace MergeToStay.Components.Combat
{
	public class DragGridObjectUpdateComponent : IComponent
	{
		public Vector2 OriginCell;
		public GameObject DraggedGameObject;

	}
}