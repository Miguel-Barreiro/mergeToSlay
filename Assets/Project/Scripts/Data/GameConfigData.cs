using UnityEngine;

namespace MergeToStay.Data
{
	[CreateAssetMenu(fileName = "NEW_GAME_CONFIG", menuName = "MergeToSlay/new GameConfig", order = 0)]
	public class GameConfigData : ScriptableObject
	{
		public CardList CardListData;
		
		public GameObject DefaultGridObjetView;
		public GameObject DefaultEnemyView;

		[Range(1, 10)]
		public int StartingDrawLevel = 5;
	}
}