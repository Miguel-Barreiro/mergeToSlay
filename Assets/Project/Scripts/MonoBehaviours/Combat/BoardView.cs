using System.Collections.ObjectModel;
using MergeToStay.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MergeToStay.MonoBehaviours.Combat
{
    public class BoardView : MonoBehaviour
    {
        [Inject] private BoardService _boardService;
        [Inject] private CombatService _combatService;

        public Button EndTurnButton;
        public GridView GridView;
        public DragOnHandler BattleDragCatcher;

        private bool _dragTargetBattle = false;
        private Vector2? _dragTargetCell = null;
        private Vector2? _dragOriginCell = null;
        private GameEntity _draggedEvent;
        private bool _isDragEnable = false;


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
            BattleDragCatcher.OnEnterDrag += OnEnterBattle;
            BattleDragCatcher.OnExitDrag += OnExitBattle;

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

        private void OnExitBattle(DragOnHandler obj)
        {
            _dragTargetBattle = false;
        }

        private void OnEnterBattle(DragOnHandler obj)
        {
            _dragTargetBattle = true;
            _dragTargetCell = null;
        }

        private void OnStartDragUtil(CellView view)
        {
            
            if (_draggedEvent != null && _draggedEvent.isEnabled)
                _draggedEvent.Destroy();
            
            _dragOriginCell = view.Position;

            if (!_isDragEnable)
                return;
            _draggedEvent = _boardService.CreateDragUpdateEvent(view.Position);
        }
        
        private void OnEndDragUtil(CellView view)
        {
            if (!_isDragEnable)
            {
                _dragTargetBattle = false;
                _dragOriginCell = null;
                _dragTargetCell = null;

                if (_draggedEvent != null && _draggedEvent.isEnabled)
                {
                    _draggedEvent.Destroy();
                    _draggedEvent = null;
                }
            
                return;
            }


            if (_dragTargetBattle && _dragOriginCell != null)
                OnEndToBattleDrag(_dragOriginCell.Value);
    
            else if (_dragTargetCell != null && _dragOriginCell != null)
                OnEndDrag(_dragOriginCell.Value, _dragTargetCell.Value);
            
            else if (_dragOriginCell != null)
                OnEndInvalidDrag(_dragOriginCell.Value);
            else
                OnEndInvalidDrag(Vector2.down);
            
            _dragTargetBattle = false;
            _dragOriginCell = null;
            _dragTargetCell = null;

            if (_draggedEvent != null && _draggedEvent.isEnabled)
            {
                _draggedEvent.Destroy();
                _draggedEvent = null;
            }

        }
        
        
        private void OnEndDrag(Vector2 originCell, Vector2 targetCell)
        {
            if (!_isDragEnable)
                return;

            // Debug.Log("dragged from " + originCell + " to " + targetCell);
            _boardService.CreateObjectGridDragToCellEvent(originCell, targetCell);
        }
        
        private void OnEndToBattleDrag(Vector2 originCell)
        {
            if (!_isDragEnable)
                return;
            // Debug.Log("dragged from " + originCell + " to battle");
            _combatService.CreateBattleUseEvent(originCell);
        }
        
        private void OnEndInvalidDrag(Vector2 originCell)
        {
            if (!_isDragEnable)
                return;
            // Debug.Log("dragged from " + originCell + " to battle");
            _boardService.CreateInvalidDragEvent(originCell);
        }


        public void EndTurnPressed()
        {
            _boardService.CreateEndTurnEvent();
        }

        public void ToggleDrag(bool toggle)
        {
            _isDragEnable = toggle;
        }
    }
}
