using System.Collections.Generic;
using MergeToStay.Components.Combat;
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

		public GameEntity CreateNewGridObjectDragToCellEvent(Vector2 draggedCell, Vector2 targetCell)
		{
			GameEntity result = _context.CreateEntity();
			result.AddDragGridObjectEvent(draggedCell, targetCell);
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
			if (board.Cells[newPosition].GridObject != null)
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

		public GameEntity GetGridObjectAt(GameEntity boardEntity, Vector2 targetPosition)
		{
			BoardComponent board = boardEntity.board;
			return board.Cells[targetPosition].GridObject;
		}

		public bool MergeGridObjects(GameEntity boardEntity, Vector2 originCell, Vector2 targetCell)
		{
			BoardComponent board = boardEntity.board;

			GameEntity originGridObject = GetGridObjectAt(boardEntity, originCell);
			GameEntity targetGridObject = GetGridObjectAt(boardEntity, targetCell);
			if ( _gridObjectService.IsValid(targetGridObject)  && _gridObjectService.IsValid(originGridObject))
			{
				bool sameType = originGridObject.gridObject.CardData == targetGridObject.gridObject.CardData;
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
	}
}