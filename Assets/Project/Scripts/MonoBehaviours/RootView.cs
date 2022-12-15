using UnityEngine;

namespace MergeToStay.MonoBehaviours
{
	public class RootView : MonoBehaviour
	{
		public RectTransform PathRoot;
		public RectTransform PlayerUiRoot;
		public RectTransform BoardRoot;
		public RectTransform GridObjectsRoot;
		public RectTransform BattleRoot;
		public RectTransform BattleRewardsRoot;
		public RectTransform CampRoot;
		public RectTransform ShopRoot;

		public void ShowView(View view, bool hideOpenedViews = true)
		{
			if (hideOpenedViews)
				HideAllViews();

			switch (view)
			{
				case View.PlayerUi:
					PlayerUiRoot.gameObject.SetActive(true);
					break;
				case View.Path:
					PathRoot.gameObject.SetActive(true);
					break;
				case View.Battle:
				case View.EliteBattle:
				case View.BossBattle:
					BattleRoot.gameObject.SetActive(true);
					BoardRoot.gameObject.SetActive(true);
					break;
				case View.BattleRewards:
					BattleRewardsRoot.gameObject.SetActive(true);
					break;
				case View.Camp:
					CampRoot.gameObject.SetActive(true);
					break;
				case View.Shop:
					ShopRoot.gameObject.SetActive(true);
					break;
			}
		}

		private void HideAllViews()
		{
			PathRoot.gameObject.SetActive(false);
			BattleRoot.gameObject.SetActive(false);
			BoardRoot.gameObject.SetActive(false);
			GridObjectsRoot.gameObject.SetActive(false);
			BattleRewardsRoot.gameObject.SetActive(false);
			CampRoot.gameObject.SetActive(false);
			ShopRoot.gameObject.SetActive(false);
		}
	}

	public enum View
	{
		PlayerUi,
		Path,
		Battle,
		BattleRewards,
		EliteBattle,
		BossBattle,
		Camp,
		Shop
	}
}