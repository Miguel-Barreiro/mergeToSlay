using Entitas;
using UnityEngine;

namespace MergeToSlay.Components
{
	public sealed class GridObject : IComponent
	{
		public Vector2? GridPosition = null;
		public GameObject View;
	}
}