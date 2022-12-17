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
        
        private int _rewardIndex;
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
            Name.text = name;
            _rewardIndex = rewardIndex;
        }

        void ExecuteReward()
        {
            switch (_type)
            {
                case RewardType.Card:
                    _battleRewardsService.ExecuteCardReward(_rewardIndex);
                    gameObject.SetActive(false);
                    break;
                case RewardType.Gold:
                    _battleRewardsService.ExecuteGoldReward(_rewardIndex);
                    gameObject.SetActive(false);
                    break;
                case RewardType.Heal:
                    _battleRewardsService.ExecuteHealReward(_rewardIndex);
                    gameObject.SetActive(false);
                    break;
                case RewardType.DrawLevel:
                    _battleRewardsService.ExecuteDrawLevelReward(_rewardIndex);
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}
