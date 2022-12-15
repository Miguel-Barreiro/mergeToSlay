using Entitas;
using MergeToStay.Data;
using MergeToStay.Services;
using UnityEngine;
using Zenject;

namespace MergeToStay.Systems.Combat
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
			GameEntity gridObjectView = _gridObjectService.CreateNewGridObjectFromCard(_debugCardData);
			_boardService.MoveGridObject(newBoard, gridObjectView, Vector2.zero);
			
			gridObjectView = _gridObjectService.CreateNewGridObjectFromCard(_debugCardData);
			_boardService.MoveGridObject(newBoard, gridObjectView, Vector2.one);
		}
	}
}