using System.Collections.Generic;
using Entitas;
using TMPro;
using UnityEngine;
using Zenject;

namespace MergeToStay.MonoBehaviours.Combat
{
    public class BattleView : MonoBehaviour
    {
        [Inject] protected Contexts _contexts;
        
        public TMP_Text PlayerDefense;
        public List<EnemyStatusView> EnemyStatusViews;
        public List<RectTransform> EnemySpots;
        public RectTransform PlayerSpot;

        private IGroup<GameEntity> _batleGroup;

        private void Start()
        {
            _batleGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Battle));
        }

        private void Update()
        {
            GameEntity battleEntity = _batleGroup.GetSingleEntity();
            if (battleEntity == null)
                return;

            int defense = battleEntity.battle.PlayerCurrentTurnStats.Defense;

            if (defense > 0)
            {
                PlayerDefense.gameObject.SetActive(true);
                PlayerDefense.text = defense.ToString();
            } else
            {
                PlayerDefense.gameObject.SetActive(false);
                PlayerDefense.text = defense.ToString();
            }
        }
    }
    
}
