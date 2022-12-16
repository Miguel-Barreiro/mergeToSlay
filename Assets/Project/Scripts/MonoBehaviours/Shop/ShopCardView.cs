using System;
using MergeToStay.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MergeToStay.MonoBehaviours.Camp
{
    public class ShopCardView : MonoBehaviour
    {
        public Image Image;
        public TextMeshProUGUI Name;
        public TextMeshProUGUI Price;

        [SerializeField] int shopCardIndex;

        [Inject] ShopService _shopService;

        private void Awake()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(CreateBuyShopCardEvent);
        }

        public void UpdateValues(Sprite image, string name, int price)
        {
            Image.sprite = image;
            Name.text = name;
            Price.text = price.ToString();
        }
        
        void CreateBuyShopCardEvent() => _shopService.CreateBuyShopCardEvent(shopCardIndex);
    }
}
