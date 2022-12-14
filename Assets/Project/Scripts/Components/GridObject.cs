using Entitas;
using MergeToSlay.Data;
using UnityEngine;

namespace MergeToSlay.Components
{
	public sealed class GridObject : IComponent
	{
		public CardData CardData;
		public int Level = 0;
		public GameObject View;
		
		public Vector2? GridPosition = null;
	}
}