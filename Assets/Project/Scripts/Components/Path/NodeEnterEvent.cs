using Entitas;
using MergeToStay.MonoBehaviours.Path;

namespace MergeToStay.Components.Path
{
	public class NodeEnterEvent : IComponent
	{
		public string PickedNodeId;
		public NodeType NodeType;
	}
}