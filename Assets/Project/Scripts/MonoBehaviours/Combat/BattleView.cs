using System;
using System.Collections.Generic;
using Entitas;
using MergeToStay.Components.Combat.Battle;
using MergeToStay.Data;
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

        [SerializeField]
        public List<EnemyIntention> EnemyIntentions;
        public RectTransform PlayerSpot;

        private IGroup<GameEntity> _batleGroup;

        [Serializable]
        public class EnemyIntention
        {
            public GameObject DefendIcon;
            public GameObject AttackIcon; 
            public TMP_Text Attack;
        }
        
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

            int spot = 0;
            foreach (GameEntity enemyEntity in battleEntity.battle.Enemies)
            {
                if(spot > 2)
                    return;

                EnemyIntention enemyIntention = EnemyIntentions[spot];
                Enemy enemy = enemyEntity.enemy;

                List<CombatSequence> combatBehaviours = enemy.EnemyData.CombatBehaviours;

                if (enemy.CurrentBehaviourSequenceIndex < 0 || enemy.CurrentBehaviourSequenceIndex >= combatBehaviours.Count)
                    continue;
                
                CombatSequence combatBehaviour = combatBehaviours[enemy.CurrentBehaviourSequenceIndex];

                if (enemy.CurrentBehaviourSequenceTurn < 0 || enemy.CurrentBehaviourSequenceTurn >= combatBehaviour.TurnActionsSequence.Count)
                    continue;

                TurnActions turnActions = combatBehaviour.TurnActionsSequence[enemy.CurrentBehaviourSequenceTurn];
                
                enemyIntention.DefendIcon.SetActive(turnActions.IsDefend);
                enemyIntention.AttackIcon.SetActive(turnActions.Attack > 0);
                enemyIntention.Attack.text = turnActions.Attack.ToString();

                spot++;
            }
            
        }
    }
    
}
