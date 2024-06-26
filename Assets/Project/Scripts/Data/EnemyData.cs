using System;
using System.Collections.Generic;
using MergeToStay.Data.Actions;
using UnityEngine;

namespace MergeToStay.Data
{
	[CreateAssetMenu(fileName = "NEW_ENEMY", menuName = "MergeToSlay.COMBAT/new ENEMY", order = 0)]
	public sealed class EnemyData : ScriptableObject
	{
		
		[Range(1, 200)] 
		public int Hp = 1;
		
		public string Name;
		
		public GameObject Prefab;
		
		public bool IsBoss = false;
		
		[SerializeField]
		public List<CombatSequence> CombatBehaviours;
	}

	[Serializable]
	public sealed class CombatSequence
	{
		[SerializeField] 
		public List<TurnActions> TurnActionsSequence;
	}
	
	[Serializable]
	public sealed class TurnActions
	{
		public int Attack = 0;
		public bool IsSpecial = false;
		public bool IsDefend = false;
		
		[SerializeField]
		public List<TurnAction> Actions;
	}
	
	[Serializable]
	public sealed class TurnAction
	{
		public GameObject Icon;
		public ActionBase Action;
	}
}