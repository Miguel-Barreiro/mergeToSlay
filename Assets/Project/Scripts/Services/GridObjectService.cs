using MergeToSlay.Data;
using Zenject;

namespace MergeToSlay.Services
{
	public sealed class GridObjectService
	{
		[Inject]
		private GameContext _context;

		public GameEntity CreateNewGridObjectFromCard(CardData cardData)
		{
			GameEntity result = _context.CreateEntity();
			// result.AddGridObject(null, cardData.);
			return result;
		}
	}
}