using Entitas;
using UnityEngine;

namespace MergeToStay.Components.Combat
{
	public class MergeEvent : IComponent
	{
		public Vector2 originCell;
		public Vector2 targetCell;
	}
}