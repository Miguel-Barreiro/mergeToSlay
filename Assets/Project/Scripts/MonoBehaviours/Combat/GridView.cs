using System;
using UnityEngine;

namespace MergeToStay.MonoBehaviours.Combat
{
    public class GridView : MonoBehaviour
    {
        [SerializeField] 
        private GridRow[] Rows;

        [Serializable]
        public sealed class GridRow
        {
            [SerializeField] public CellView[] Cells;
        }
    }
    
}
