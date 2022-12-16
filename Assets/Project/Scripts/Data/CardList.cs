using System.Collections.Generic;
using UnityEngine;

namespace MergeToStay.Data
{
	[CreateAssetMenu(fileName = "NEW_CARD_List", menuName = "MergeToSlay.CARD/new CARD_LIST", order = 0)]
	public class CardList : ScriptableObject
	{
		[SerializeField]
		public List<CardsModel.Card> Cards;
		
		[SerializeField]
		private List<CardData> AllCards;
	}
}