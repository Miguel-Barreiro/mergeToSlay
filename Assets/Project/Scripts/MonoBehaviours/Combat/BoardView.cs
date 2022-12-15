using System.Collections.ObjectModel;
using MergeToStay.Services;
using UnityEngine;
using Zenject;

namespace MergeToStay.MonoBehaviours.Combat
{
    public class BoardView : MonoBehaviour
    {

        [Inject]
        private BoardService _boardService;
        
        public GridView GridView;

        public DragOnHandler BattleDragCatcher;

        private bool _dragTargetBattle = false;
        private Vector2? _dragTargetCell = null;
        private Vector2? _dragOriginCell = null;
        
        

        private void Start()
        {
            ReadOnlyCollection<CellView> cells = GridView.GetCells();
            foreach ( CellView cell in cells)
            {
                cell.OnStartDrag += OnStartDragUtil;
                cell.OnEndDrag += OnEndDragUtil;
                cell.DragOnHandler.OnEnterDrag += OnEnterDragCell;
                cell.DragOnHandler.OnExitDrag += OnExitDragCell;
            }
            BattleDragCatcher.OnEnterDrag += OnEnterCatcher;
            BattleDragCatcher.OnExitDrag += OnExitCatcher;

        }


        private void OnDestroy()
        {
            ReadOnlyCollection<CellView> cells = GridView.GetCells();
            foreach ( CellView cell in cells)
            {
                cell.OnStartDrag -= OnStartDragUtil;
                cell.OnEndDrag -= OnEndDragUtil;
                cell.DragOnHandler.OnEnterDrag -= OnEnterDragCell;
                cell.DragOnHandler.OnExitDrag -= OnExitDragCell;
            }
        }
        
        private void OnExitDragCell(DragOnHandler dragOnHandler)
        {
            CellView cellView = dragOnHandler.GetComponent<CellView>();
            if (cellView != null && _dragTargetCell != null && cellView.Position.Equals(_dragTargetCell))
                _dragTargetCell = null;
        }
        
        private void OnEnterDragCell(DragOnHandler dragOnHandler)
        {
            CellView cellView = dragOnHandler.GetComponent<CellView>();
            if (cellView != null)
            {
                _dragTargetBattle = false;
                _dragTargetCell = cellView.Position;
            }
        }

        private void OnExitCatcher(DragOnHandler obj)
        {
            _dragTargetBattle = false;
        }

        private void OnEnterCatcher(DragOnHandler obj)
        {
            _dragTargetBattle = true;
            _dragTargetCell = null;
        }

        private void OnStartDragUtil(CellView view)
        {
            _dragOriginCell = view.Position;
        }
        
        private void OnEndDragUtil(CellView view)
        {
            if (_dragTargetBattle && _dragOriginCell != null)
                OnEndDragToBattle(_dragOriginCell.Value);
 
            if (_dragTargetCell != null && _dragOriginCell != null)
                OnEndDrag(_dragOriginCell.Value, _dragTargetCell.Value);

            _dragTargetBattle = false;
            _dragOriginCell = null;
            _dragTargetCell = null;
        }
        
        
        private void OnEndDrag(Vector2 originCell, Vector2 targetCell)
        {
            // Debug.Log("dragged from " + originCell + " to " + targetCell);
            _boardService.CreateNewGridObjectDragToCellEvent(originCell, targetCell);
        }
        
        private void OnEndDragToBattle(Vector2 originCell)
        {
            // Debug.Log("dragged from " + originCell + " to battle");
            _boardService.CreateNewGridObjectDragToBattleEvent(originCell);
        }
        

    }
}
