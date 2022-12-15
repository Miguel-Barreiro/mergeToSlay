using System.Collections.Generic;
using MergeToStay.MonoBehaviours.Path;
using UnityEngine;

namespace MergeToStay
{
    public class PathView : MonoBehaviour
    {
        public List<NodeView> Nodes;

        public List<NodeView> AllNodes { get; } = new List<NodeView>();
        
        private void Awake() => UpdateNodes(null, Nodes);

        void UpdateNodes(NodeView parent, List<NodeView> children)
        {
            foreach (NodeView child in children)
            {
                if (AllNodes.Contains(child))
                    continue;

                AllNodes.Add(child);
                UpdateNodes(child, child.Nodes);
            }
        }
    }
}
