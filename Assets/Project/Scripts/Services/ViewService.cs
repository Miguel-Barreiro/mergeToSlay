using MergeToStay.MonoBehaviours;
using Zenject;

namespace MergeToStay.Services
{
	public class ViewService
	{
		[Inject] private GameContext _context;

		public GameEntity CreateShowViewEvent(View view)
		{
			GameEntity result = _context.CreateEntity();
			result.AddShowViewEvent(view);

			return result;
		}
	}
}