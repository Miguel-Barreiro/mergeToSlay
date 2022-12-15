using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace MergeToStay.MonoBehaviours.Combat
{
    public class GridView : MonoBehaviour
    {

        [SerializeField] 
        private GridRow[] Rows;

        private Vector2? _dragTargetCell = null;
        private readonly List<CellView> _allCells = new List<CellView>();
        private readonly Dictionary<Vector2, CellView> _cellByPosition = new Dictionary<Vector2, CellView>();

        [Serializable]
        public sealed class GridRow
        {
            [SerializeField] public CellView[] Cells;
        }
        

        public ReadOnlyCollection<CellView> GetCells() { return _allCells.AsReadOnly(); }

        public CellView GetCellViewByPosition(Vector2 cellPosition)
        {
            return _cellByPosition[cellPosition];
        }

        private void Awake()
        {
            _allCells.Clear();
            
            int x = 0;
            int y = 0;
            foreach (GridRow gridRow in Rows)
            {
                x = 0;
                foreach (CellView cellView in gridRow.Cells)
                {
                    Vector2 position = new Vector2(x, y);
                    cellView.SetPosition(position);
                    _allCells.Add(cellView);
                    _cellByPosition[position] = cellView;
                    x++;
                }
                y++;
            }
        }
    }
    
}
