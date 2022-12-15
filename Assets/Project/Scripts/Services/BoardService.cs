using System.Collections.Generic;
using MergeToStay.Components;
using UnityEngine;
using Zenject;

namespace MergeToStay.Services
{
	public sealed class BoardService
	{
		[Inject]
		private GameContext _context;
		
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

		public void CreateNewGridObjectDragToCellEvent(Vector2 draggedCell, Vector2 targetCell)
		{
			GameEntity result = _context.CreateEntity();
			result.AddDragGridObjectEvent(draggedCell, targetCell, false);
		}

		public void CreateNewGridObjectDragToBattleEvent(Vector2 draggedCell)
		{
			GameEntity result = _context.CreateEntity();
			result.AddDragGridObjectEvent(draggedCell,null, true);
		}

		
		public bool MoveGridObject(BoardComponent board, GameEntity gridObject, Vector2 newPosition)
		{
			if (board.Cells[newPosition].GridObject != null)
				return false;
				
			if (gridObject.gridObject.GridPosition != null )
			{
				GridCell previousCell = board.Cells[gridObject.gridObject.GridPosition.Value];
				previousCell.GridObject = null;
			}

			gridObject.gridObject.GridPosition = newPosition;
			board.Cells[newPosition].GridObject = gridObject;

			return true;
		}

		public GameEntity GetGridObjectAt(BoardComponent board, Vector2 targetPosition)
		{
			return board.Cells[targetPosition].GridObject;
		}

	}
}