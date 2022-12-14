using Entitas;
using MergeToSlay.Data;
using MergeToSlay.Services;
using UnityEngine;
using Zenject;

namespace MergeToStay.Systems
{
	public class CombatInitSystem : ISystem, IInitializeSystem
	{
		[Inject] private BoardService _boardService;
		[Inject] private GridObjectService _gridObjectService;

		[Inject] private CardData _debugCardData;
		
		public void Initialize()
		{
			GameEntity newBoard = _boardService.CreateNewBoard(5, 5);

			// lets fill with an object for debug
			GameEntity gridObject = _gridObjectService.CreateNewGridObjectFromCard(_debugCardData);

			_boardService.MoveGridObject(newBoard.board, gridObject, Vector2.one);
		}
	}
}