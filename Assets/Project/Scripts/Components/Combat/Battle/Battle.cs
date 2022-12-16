using System.Collections.Generic;
using Entitas;

namespace MergeToStay.Components.Combat.Battle
{
	public class Battle : IComponent
	{
		public enum BattleState
		{
			Init, 
			Draw, 
			Play, 
			EnemyTurn,
		}

		public List<GameEntity> Enemies;
		public int CardDrawLevel;
		public BattleState State;

	}
}