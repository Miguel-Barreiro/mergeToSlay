using Entitas;
using MergeToStay.Data;

namespace MergeToStay.Components.Player
{
	public class PlayerComponent : IComponent
	{
		public int Health;
		public int Gold;
		public int DrawLevel;
		public CardsModel.Deck Deck;
	}
}