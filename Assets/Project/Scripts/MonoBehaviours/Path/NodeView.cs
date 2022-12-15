using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MergeToStay.MonoBehaviours.Path
{
    public class NodeView : MonoBehaviour
    {
        public List<NodeView> Nodes;

        readonly Color nodeSelectedColor = Color.green;
        readonly Color selectableNodeColor = Color.white;
        readonly Color unselectableNodeColor = Color.gray;

        public bool IsSelectable
        {
            get => button.enabled;
            set => SetSelectable(value);
        }

        Image image;
        Button button;

        private void Awake()
        {
            image = GetComponent<Image>();
            button = GetComponent<Button>();
        }

        public void SetSelected(bool value)
        {
            // SetSelectable(IsSelectable);

            if (value)
                image.color = nodeSelectedColor;
        }

        private void SetSelectable(bool value)
        {
            button.enabled = value;
            image.color = value ? selectableNodeColor : unselectableNodeColor;
        }
    }
}
