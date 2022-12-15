using UnityEngine;
using Zenject;

namespace MergeToStay.Services
{
	public class CombatService
	{
		[Inject] private GameContext _context;

		public GameEntity CreateMergeEvent(Vector2 originCell, Vector2 targetCell)
		{
			GameEntity result = _context.CreateEntity();
			result.AddMergeEvent(originCell, targetCell);
			return result;
		}
		
		public GameEntity CreateBattleUseEvent(Vector2 originCell)
		{
			GameEntity result = _context.CreateEntity();
			result.AddGridObjectUseEvent(originCell);
			return result;
		}
		
	}
}