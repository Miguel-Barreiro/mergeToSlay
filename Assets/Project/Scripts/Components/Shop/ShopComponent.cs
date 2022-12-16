using System.Collections.Generic;
using Entitas;
using MergeToStay.Data;

namespace MergeToStay.Components.Shop
{
	public class ShopComponent : IComponent
	{
		public List<CardsModel.Card> Cards;
	}
}