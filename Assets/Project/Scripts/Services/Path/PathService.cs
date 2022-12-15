using MergeToStay.MonoBehaviours.Path;
using Zenject;

namespace MergeToStay.Services
{
	public class PathService
	{
		[Inject] private GameContext _context;

		public GameEntity CreateNewPath(string currentNodeId)
		{
			GameEntity result = _context.CreateEntity();
			result.AddPath(currentNodeId);

			return result;
		}

		public void SetCurrentNodeId(GameEntity pathEntity, string currentNodeId)
		{
			pathEntity.ReplacePath(currentNodeId);
		}

		public GameEntity CreateNodeEnterEvent(string nodeName, NodeType nodeType)
		{
			GameEntity result = _context.CreateEntity();
			result.AddNodeEnterEvent(nodeName, nodeType);

			return result;
		}

		public GameEntity CreateNodeCompleteEvent(bool isCompleted)
		{
			GameEntity result = _context.CreateEntity();
			result.AddNodeExitEvent(isCompleted);

			return result;
		}
	}
}