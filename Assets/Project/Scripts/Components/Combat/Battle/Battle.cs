using System.Collections.Generic;
using Entitas;

namespace MergeToStay.Components.Combat.Battle
{
	public sealed class Battle : IComponent
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
		
		public TurnStats PlayerCurrentTurnStats;
		public Effects PlayerEffects;
	}

	public sealed class TurnStats
	{
		public int Defense = 0;
	}

	public sealed class Effects
	{
		public int StunTurns = 0;
		
		public int Poison = 0;
		public int WeakTurns = 0;
		public int VulnerableTurns = 0;
	}
}