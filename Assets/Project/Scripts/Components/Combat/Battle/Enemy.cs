using Entitas;
using MergeToStay.Data;
using UnityEngine;

namespace MergeToStay.Components.Combat.Battle
{
	public class Enemy : IComponent
	{
		public GameObject View;
		
		public EnemyData EnemyData;
		public int Hp;
		public int TurnsStun = 0;

		public int CurrentBehaviourSequenceTurn = 0;
		public int CurrentBehaviourSequenceIndex = 0;

	}
}