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

        void Awake()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(CreateNodeEnterEvent);
        }

        void CreateNodeEnterEvent() => _pathService.CreateNodeEnterEvent(gameObject.name);
    }
}

