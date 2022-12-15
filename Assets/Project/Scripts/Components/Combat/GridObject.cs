using Entitas;
using MergeToStay.Data;
using UnityEngine;

namespace MergeToStay.Components.Combat
{
	public sealed class GridObject : IComponent
	{
		public CardData CardData;
		public int Level = 0;
		public GameObject View;
		
		public Vector2? GridPosition = null;
	}
}