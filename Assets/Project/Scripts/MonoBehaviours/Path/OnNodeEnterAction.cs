using System;
using MergeToStay.MonoBehaviours.Path;
using MergeToStay.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MergeToStay
{
    public class OnNodeEnterAction : MonoBehaviour
    {
        [Inject]
        PathService _pathService;

        NodeView nodeView;

        void Awake()
        {
            nodeView = GetComponent<NodeView>();
            Button button = GetComponent<Button>();
            button.onClick.AddListener(CreateNodeEnterEvent);
        }

        void CreateNodeEnterEvent() => _pathService.CreateNodeEnterEvent(gameObject.name, nodeView.Type);
    }
}

