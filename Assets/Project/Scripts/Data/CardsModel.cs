using System;
using System.Collections.Generic;

namespace MergeToStay.Data
{
	public static class CardsModel
	{
		public enum CardRarity
		{
			Common, 
			Uncommon, 
			Rare
		}

		public class Deck
		{
			public readonly List<Card> Cards = new List<Card>();
		}
		
		[Serializable]
		public class Card
		{
			public CardData CardData;
			public int Level = 0;
		}
	}
}