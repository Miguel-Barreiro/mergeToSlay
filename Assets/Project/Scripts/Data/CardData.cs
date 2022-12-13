using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MergeToStay.Data
{
    [CreateAssetMenu(fileName = "NEW_CARD", menuName = "MergeToSlay/new CARD", order = 0)]
    public sealed class CardData : ScriptableObject
    {
        
        public string Name;

        [InfoBox("This is where we define each level data for the card")]
        [SerializeField]
        public CardLevelData[] LevelData;
    }


    [Serializable]
    public sealed class CardLevelData
    {
        public GameObject Prefab;

        [TextArea]
        public string Description;
        
        [SerializeField]
        public List<ActionBase> Actions;
        
    }
}
