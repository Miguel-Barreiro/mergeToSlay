using MergeToStay.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MergeToStay.MonoBehaviours.Camp
{
    public class RewardCardView : MonoBehaviour
    {
        public Image Image;
        public TextMeshProUGUI Name;
        public Button AddToDeckButton;

        [Inject] BattleRewardsService _battleRewardsService;
        
        int _rewardIndex;

        private void Awake() => AddToDeckButton.onClick.AddListener(AddToDeck);

        public void UpdateValues(Sprite image, string name, int rewardIndex)
        {
            Image.sprite = image;
            Name.text = name;
            _rewardIndex = rewardIndex;
        }

        void AddToDeck()
        {
            _battleRewardsService.ExecuteReward(_rewardIndex);
            gameObject.SetActive(false);
        }
    }
}
