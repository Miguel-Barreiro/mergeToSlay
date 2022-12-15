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

		public void ShowView(View view)
		{
			HideAllViews();

			switch (view)
			{
				case View.Path:
					PathRoot.gameObject.SetActive(true);
					break;
				case View.Battle:
				case View.EliteBattle:
				case View.BossBattle:
					BattleRoot.gameObject.SetActive(true);
					BoardRoot.gameObject.SetActive(true);
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
			BoardRoot.gameObject.SetActive(false);
			GridObjectsRoot.gameObject.SetActive(false);
			BattleRoot.gameObject.SetActive(false);
			CampRoot.gameObject.SetActive(false);
			ShopRoot.gameObject.SetActive(false);
		}
	}

	public enum View
	{
		Path,
		Battle,
		EliteBattle,
		BossBattle,
		Camp,
		Shop
	}
}