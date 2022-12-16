using UnityEngine;

namespace MergeToStay.MonoBehaviours.Combat
{
    public class BattleRewardsView : MonoBehaviour
    {
        public Transform CardsParent;

        public void AddCard(Transform card) => card.SetParent(CardsParent);
    }
}
