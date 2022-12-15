using Entitas;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.Combat
{
	public class PathInitSystem : IInitializeSystem
	{
		[Inject] private BoardService _boardService;
		[Inject] private PathService _pathService;
		
		public void Initialize()
		{
			GameEntity newPath = _pathService.CreateNewPath(null);
		}
	}
}