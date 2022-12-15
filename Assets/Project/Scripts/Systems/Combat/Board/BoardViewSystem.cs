using System.Collections.Generic;
using MergeToStay.Components;
using MergeToStay.MonoBehaviours.Combat;
using Zenject;
using Vector2 = UnityEngine.Vector2;

namespace MergeToStay.Systems.Combat.Board
{
	public class BoardViewSystem : BoardReactiveSystem
	{
		[Inject]
		private BoardView _boardView;
		
		protected override void _execute(GameEntity boardEntity)
		{

			foreach (KeyValuePair<Vector2, GridCell> valuePair in boardEntity.board.Cells)
			{
				Vector2 cellPosition = valuePair.Key;
				GridCell gridCell = valuePair.Value;

				if (gridCell.GridObject != null)
				{
					CellView cellView = _boardView.GridView.GetCellViewByPosition(cellPosition);

					gridCell.GridObject.gridObject.View.transform.position = cellView.transform.position;
				}

			}
			
			
		}
	}
}