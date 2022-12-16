using System.Collections.Generic;
using MergeToStay.Services;
using UnityEngine;

namespace MergeToStay.Data
{
	[CreateAssetMenu(fileName = "NEW_GAME_CONFIG", menuName = "MergeToSlay/new GameConfig", order = 0)]
	public class GameConfigData : ScriptableObject
	{
		public CardList CardListData;
		
		public GameObject DefaultGridObjetView;
		public GameObject DefaultEnemyView;

		public CombatData DebugCombatData;

		[SerializeField] public List<CombatData> BossBattles;
		[SerializeField] public List<CombatData> ElitesBattles;
		[SerializeField] public List<CombatData> NormalBattles;

		[Range(1, 10)]
		public int StartingDrawLevel = 5;
		public int StartingHealth;
		public int MaxHealth;
		public int StartingGold;
		public int CampHealingAmount;
	}
}