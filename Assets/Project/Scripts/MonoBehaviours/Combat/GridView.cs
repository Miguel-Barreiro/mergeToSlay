using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace MergeToSlay.MonoBehaviours.Combat
{
    public class GridView : MonoBehaviour
    {

        [SerializeField] 
        private GridRow[] Rows;

        private Vector2? _dragTargetCell = null;
        private readonly List<CellView> _allCells = new List<CellView>();

        [Serializable]
        public sealed class GridRow
        {
            [SerializeField] public CellView[] Cells;
        }

        private void Awake()
        {
            _allCells.Clear();
            
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
                    _allCells.Add(cellView);
                }
            }
        }
        

        public ReadOnlyCollection<CellView> GetCells() { return _allCells.AsReadOnly(); }
    }
    
}
