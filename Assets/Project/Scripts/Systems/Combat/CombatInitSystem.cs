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
		
		public void Initialize()
		{
			GameEntity newBoard = _boardService.CreateNewBoard(5, 5);
		}
	}
}