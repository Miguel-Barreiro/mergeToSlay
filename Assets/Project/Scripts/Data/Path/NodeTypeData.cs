using MergeToStay.MonoBehaviours.Path;
using UnityEngine;

namespace MergeToStay.Data
{
    [CreateAssetMenu(fileName = "NEW_NODE", menuName = "MergeToSlay.PATH/new NODE", order = 0)]
    public sealed class NodeTypeData : ScriptableObject
    {
        public NodeType Type;
        public Sprite Icon;
    }
}
