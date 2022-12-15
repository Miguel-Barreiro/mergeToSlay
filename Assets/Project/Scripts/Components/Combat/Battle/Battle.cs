using System.Collections.Generic;
using Entitas;

namespace MergeToStay.Components.Combat.Battle
{
	public class Battle : IComponent
	{
		public List<Enemy> Enemies;
		public int CardDrawLevel;

	}
}