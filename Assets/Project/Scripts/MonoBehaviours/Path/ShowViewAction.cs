using MergeToStay.MonoBehaviours;
using MergeToStay.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MergeToStay
{
    public class ShowViewAction : MonoBehaviour
    {
        [SerializeField] private View view;
        
        [Inject] ViewService _viewService;

        void Awake()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(CreateShowViewEvent);
        }

        void CreateShowViewEvent() => _viewService.CreateShowViewEvent(view);
    }
}

