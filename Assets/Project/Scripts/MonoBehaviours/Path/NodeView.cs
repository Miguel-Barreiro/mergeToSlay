using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MergeToStay.MonoBehaviours.Path
{
    public class NodeView : MonoBehaviour
    {
        readonly Color nodeSelectedColor = Color.green;
        readonly Color selectableNodeColor = Color.white;
        readonly Color unselectableNodeColor = Color.gray;

        public List<NodeView> Nodes;

        public NodeType Type;

        [SerializeField] TextMeshProUGUI typeText;

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

        private void Update()
        {
            typeText.text = Type.ToString();
        }

        public void SetSelected(bool value)
        {
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
