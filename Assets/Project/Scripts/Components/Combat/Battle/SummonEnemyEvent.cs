using Entitas;
using MergeToStay.Data;

namespace MergeToStay.Components.Combat.Battle
{
	public class SummonEnemyEvent : IComponent
	{
		public EnemyData EnemyData;
		public int Position;
	}
}