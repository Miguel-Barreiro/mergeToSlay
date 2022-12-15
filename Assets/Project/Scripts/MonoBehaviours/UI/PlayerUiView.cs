using TMPro;
using UnityEngine;

namespace MergeToStay.MonoBehaviours.UI
{
    public class PlayerUiView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI Health;
        [SerializeField] TextMeshProUGUI Gold;
        [SerializeField] TextMeshProUGUI DrawLevel;

        public void SetHealth(int health) => Health.text = health.ToString();
        public void SetGold(int gold) => Gold.text = gold.ToString();
        public void SetDrawLevel(int drawLevel) => DrawLevel.text = drawLevel.ToString();
    }
}
