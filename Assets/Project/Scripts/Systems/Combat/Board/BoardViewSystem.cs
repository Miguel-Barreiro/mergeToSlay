using System.Collections.Generic;
using MergeToStay.Components.Combat;
using MergeToStay.MonoBehaviours.Combat;
using MergeToStay.Services;
using Zenject;
using Vector2 = UnityEngine.Vector2;

namespace MergeToStay.Systems.Combat.Board
{
	public class BoardViewSystem : BoardReactiveSystem
	{
		[Inject] private BoardView _boardView;
		[Inject] private GridObjectService _gridObjectService;
		
		protected override void React(GameEntity boardEntity)
		{

			foreach (KeyValuePair<Vector2, GridCell> valuePair in boardEntity.board.Cells)
			{
				Vector2 cellPosition = valuePair.Key;
				GridCell gridCell = valuePair.Value;

				if (_gridObjectService.IsValid(gridCell.GridObject) )
				{
					CellView cellView = _boardView.GridView.GetCellViewByPosition(cellPosition);
					gridCell.GridObject.gridObject.View.transform.position = cellView.transform.position;
				}
			}
			
			
		}
	}
}