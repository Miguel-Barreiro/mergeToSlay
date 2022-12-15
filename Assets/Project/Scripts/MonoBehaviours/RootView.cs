using UnityEngine;

namespace MergeToStay.MonoBehaviours
{
	public class RootView : MonoBehaviour
	{
		public RectTransform PathRoot;
		public RectTransform BoardRoot;
		public RectTransform GridObjectsRoot;
		public RectTransform BattleRoot;
		public RectTransform CampRoot;
		public RectTransform ShopRoot;

		public void ShowPathView()
		{
			HideAllViews();
			PathRoot.gameObject.SetActive(true);
		}

		public void ShowBattleView()
		{
			HideAllViews();
			BattleRoot.gameObject.SetActive(true);
			BoardRoot.gameObject.SetActive(true);
		}

		public void ShowCampView()
		{
			HideAllViews();
			CampRoot.gameObject.SetActive(true);
		}

		public void ShowShopView()
		{
			HideAllViews();
			ShopRoot.gameObject.SetActive(true);
		}

		private void HideAllViews()
		{
			PathRoot.gameObject.SetActive(false);
			BoardRoot.gameObject.SetActive(false);
			GridObjectsRoot.gameObject.SetActive(false);
			BattleRoot.gameObject.SetActive(false);
			CampRoot.gameObject.SetActive(false);
			ShopRoot.gameObject.SetActive(false);
		}
	}
}