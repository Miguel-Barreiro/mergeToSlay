using Entitas;
using UnityEngine;

namespace MergeToSlay.Components
{
	public class DragGridObjectUpdateComponent : IComponent
	{
		public Vector2 OriginCell;
		public GameObject DraggedGameObject;
	}
}