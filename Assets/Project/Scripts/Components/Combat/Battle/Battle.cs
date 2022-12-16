using System.Collections.Generic;
using Entitas;

namespace MergeToStay.Components.Combat.Battle
{
	public class Battle : IComponent
	{
		public List<GameEntity> Enemies;
		public int CardDrawLevel;

	}
}