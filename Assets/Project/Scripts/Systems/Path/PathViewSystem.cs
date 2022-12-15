using MergeToStay.MonoBehaviours.Path;
using MergeToStay.Systems.Path;
using Zenject;

namespace MergeToStay.Systems.Combat.Board
{
	public abstract class PathViewSystem : PathReactiveSystem
	{
		[Inject] private PathView _pathView;

		protected override void React(GameEntity pathEntity)
		{
			UpdateNodesList(pathEntity.path.CurrentNodeId);
		}

		public void UpdateNodesList(string playerNodeId)
		{
			NodeView playerNode = _pathView.AllNodes.Find(node => node.name == playerNodeId);

			if (playerNode == null)
			{
				HandleBeginningState();
				return;
			}

			foreach (NodeView node in _pathView.AllNodes)
			{
				if (node == playerNode)
				{
					node.SetSelected(true);
					continue;
				}

				if (playerNode.Nodes.Contains(node))
				{
					node.IsSelectable = true;
					continue;
				}

				node.IsSelectable = false;
			}
		}

		private void HandleBeginningState()
		{
			foreach (NodeView node in _pathView.AllNodes)
				node.IsSelectable = false;

			foreach (NodeView node in _pathView.Nodes)
				node.IsSelectable = true;
		}
	}
}