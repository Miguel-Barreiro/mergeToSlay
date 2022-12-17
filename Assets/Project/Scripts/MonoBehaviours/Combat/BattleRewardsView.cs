using UnityEngine;

namespace MergeToStay.MonoBehaviours.Combat
{
    public class BattleRewardsView : MonoBehaviour
    {
        public Transform CardsParent;

        public void AddReward(Transform card) => card.SetParent(CardsParent);
    }
}
