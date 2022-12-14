using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace MergeToSlay.Components
{
	public sealed class BoardComponent: IComponent
	{
		public Dictionary<Vector2, GridCell> Cells = new Dictionary<Vector2, GridCell>();

	}

	public sealed class GridCell
	{
		public readonly Vector2 Position;
		public GameEntity GridObject = null;
		public GridCell(Vector2 position) { Position = position; }
	}
}