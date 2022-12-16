using System.Collections.Generic;
using MergeToStay.MonoBehaviours.Path;
using UnityEngine;

namespace MergeToStay.Data
{
	[CreateAssetMenu(fileName = "NEW_PATH", menuName = "MergeToSlay.PATH/new PATH", order = 0)]
	public class PathData : ScriptableObject
	{
		[SerializeField] private List<NodeTypeData> allNodeTypes;
		public readonly Dictionary<NodeType, NodeTypeData> _AllNodeTypes = new Dictionary<NodeType, NodeTypeData>();

		public Dictionary<NodeType, NodeTypeData> AllNodeTypes
		{
			get
			{
				if (_AllNodeTypes.Count == 0)
					PopulateDictionary();

				return _AllNodeTypes;
			}
		}

		private void PopulateDictionary()
		{
			foreach (NodeTypeData nodeTypeData in allNodeTypes)
			{
				if (!_AllNodeTypes.ContainsKey(nodeTypeData.Type))
					_AllNodeTypes[nodeTypeData.Type] = nodeTypeData;
			}
		}
	}
}