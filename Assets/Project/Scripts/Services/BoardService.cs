using System.Collections.Generic;
using MergeToStay.Components.Combat;
using MergeToStay.Components.Combat.Battle;
using MergeToStay.Core;
using UnityEngine;
using Zenject;

namespace MergeToStay.Services
{
	public sealed class BoardService
	{
		[Inject] private GameContext _context;
		[Inject] private GridObjectService _gridObjectService;
		[Inject] private PrefabFactoryPool _prefabFactoryPool;
		
		public GameEntity CreateNewBoard(int width, int height)
		{
			Dictionary<Vector2,GridCell> cells = new Dictionary<Vector2, GridCell>();
			
			for (int x = 0; x < width; x++)
				for (int y = 0; y < height; y++)
					cells.Add(new Vector2(x, y), new GridCell(new Vector2(x, y)));

			GameEntity result = _context.CreateEntity();
			result.AddBoard(cells);
			
			return result;
		}

		public void ClearBoard(GameEntity boardEntity)
		{

			foreach (GridCell gridCell in boardEntity.board.Cells.Values)
			{
				if (_gridObjectService.IsValid(gridCell.GridObject))
				{
					_prefabFactoryPool.Destroy(gridCell.GridObject.gridObject.View);
					gridCell.GridObject.Destroy(); 
				}

			}
			Dictionary<Vector2,GridCell> cells = new Dictionary<Vector2, GridCell>();
			
			for (int x = 0; x < 5; x++)
				for (int y = 0; y < 5; y++)
					cells.Add(new Vector2(x, y), new GridCell(new Vector2(x, y)));

			boardEntity.ReplaceBoard(cells);
		}


		public GameEntity CreateInvalidDragEvent(Vector2 draggedCell)
		{
			GameEntity result = _context.CreateEntity();
			result.AddDragGridObjectEvent(true, draggedCell, Vector2.negativeInfinity);
			return result;
		}

		public GameEntity CreateObjectGridDragToCellEvent(Vector2 draggedCell, Vector2 targetCell)
		{
			GameEntity result = _context.CreateEntity();
			result.AddDragGridObjectEvent(false, draggedCell, targetCell);
			return result;
		}

		public GameEntity CreateDragUpdateEvent(Vector2 originCell)
		{
			GameEntity result = _context.CreateEntity();
			result.AddDragGridObjectUpdate(originCell, null);
			return result;
		}
		
		public bool MoveGridObject(GameEntity boardEntity, GameEntity gridObject, Vector2 newPosition)
		{
			BoardComponent board = boardEntity.board;
			if ( _gridObjectService.IsValid(board.Cells[newPosition].GridObject))
				return false;
				
			if (gridObject.gridObject.GridPosition != null )
			{
				GridCell previousCell = board.Cells[gridObject.gridObject.GridPosition.Value];
				previousCell.GridObject = null;
			}

			gridObject.gridObject.GridPosition = newPosition;
			board.Cells[newPosition].GridObject = gridObject;

			boardEntity.ReplaceBoard(board.Cells);
			return true;
		}

		public GameEntity GetGridObjectAt(GameEntity boardEntity,Vector2 targetPosition)
		{
			BoardComponent board = boardEntity.board;
			GameEntity gridObjectAt = board.Cells[targetPosition].GridObject;
			if (_gridObjectService.IsValid(gridObjectAt))
				return gridObjectAt;

			return null;
		}

		public void RemoveGridObject(GameEntity boardEntity, Vector2 originCell)
		{
			BoardComponent board = boardEntity.board;
			GameEntity originGridObject = GetGridObjectAt(boardEntity, originCell);
			if ( _gridObjectService.IsValid(originGridObject))
			{
				board.Cells[originCell].GridObject = null;
					
				_prefabFactoryPool.Destroy(originGridObject.gridObject.View);

				originGridObject.Destroy();
					
				boardEntity.ReplaceBoard(board.Cells);
			}
		}
		

		public bool MergeGridObjects(GameEntity boardEntity, Vector2 originCell, Vector2 targetCell)
		{
			BoardComponent board = boardEntity.board;

			GameEntity originGridObject = GetGridObjectAt(boardEntity, originCell);
			GameEntity targetGridObject = GetGridObjectAt(boardEntity, targetCell);
			if ( _gridObjectService.IsValid(targetGridObject)  && _gridObjectService.IsValid(originGridObject))
			{
				bool sameType = originGridObject.gridObject.CardData.Type == targetGridObject.gridObject.CardData.Type;
				bool sameLevel = originGridObject.gridObject.Level == targetGridObject.gridObject.Level;
				if (sameLevel && sameType && originGridObject.gridObject.Level < 2)
				{
					GameEntity newGridObject = _gridObjectService.CreateNewGridObjectFromCard(targetGridObject.gridObject.CardData,
																							targetGridObject.gridObject.Level+1);
					
					board.Cells[originCell].GridObject = null;
					board.Cells[targetCell].GridObject = newGridObject;
					
					_prefabFactoryPool.Destroy(originGridObject.gridObject.View);
					_prefabFactoryPool.Destroy(targetGridObject.gridObject.View);

					originGridObject.Destroy();
					targetGridObject.Destroy();
					
					boardEntity.ReplaceBoard(board.Cells);
					return true;
				}
			}
			
			return false;
		}

		public void ResetBoardView(GameEntity boardEntity)
		{
			BoardComponent board = boardEntity.board;
			boardEntity.ReplaceBoard(board.Cells);
		}

		public Vector2? GetFirsEmptySpace(GameEntity boardEntity)
		{
			BoardComponent board = boardEntity.board;
			foreach (KeyValuePair<Vector2,GridCell> keyValuePair in board.Cells)
			{
				if ( !_gridObjectService.IsValid(keyValuePair.Value.GridObject) )
					return keyValuePair.Key;
			}

			return null;
		}

		public void CreateEndTurnEvent()
		{
			GameEntity result = _context.CreateEntity();
			result.AddChangeCombatStateEvent(Battle.BattleState.EnemyTurn);
		}

	}
}