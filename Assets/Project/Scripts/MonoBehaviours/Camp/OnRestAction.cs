using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MergeToStay
{
    public class OnRestAction : MonoBehaviour
    {
        [Inject] private GameContext _context;

        void Awake()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(CreateNodeEnterEvent);
        }

        void CreateNodeEnterEvent()
        {
            GameEntity result = _context.CreateEntity();
            result.isRestEvent = true;
        }
    }
}

