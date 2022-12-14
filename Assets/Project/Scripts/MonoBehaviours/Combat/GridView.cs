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

        private void Start()
        {
            int x = 0;
            int y = 0;
            foreach (GridRow gridRow in Rows)
            {
                y++;
                x = 0;
                foreach (CellView cellView in gridRow.Cells)
                {
                    x++;
                    cellView.SetPosition(new Vector2(x, y));
                }
            }
        }
        
    }
    
}
