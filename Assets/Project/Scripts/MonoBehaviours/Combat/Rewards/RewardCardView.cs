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
        
        private int _rewardValue;
        private RewardType _type;

        private void Awake() => AddToDeckButton.onClick.AddListener(ExecuteReward);

        public enum RewardType
        {
            Card, 
            DrawLevel, 
            Gold, 
            Heal
        }

        public void UpdateValues(Sprite image, string name, int rewardIndex, RewardType type)
        {
            _type = type;
            Image.sprite = image;
            _rewardValue = rewardIndex;
            Name.text = name;
        }

        void ExecuteReward()
        {
            switch (_type)
            {
                case RewardType.Card:
                    _battleRewardsService.ExecuteCardReward(_rewardValue);
                    gameObject.SetActive(false);
                    break;
                case RewardType.Gold:
                    _battleRewardsService.ExecuteGoldReward(_rewardValue);
                    gameObject.SetActive(false);
                    break;
                case RewardType.Heal:
                    _battleRewardsService.ExecuteHealReward(_rewardValue);
                    gameObject.SetActive(false);
                    break;
                case RewardType.DrawLevel:
                    _battleRewardsService.ExecuteDrawLevelReward(_rewardValue);
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}
