using MergeToStay.Services;
using UnityEngine;

namespace MergeToStay.Data.Actions
{
	[CreateAssetMenu(fileName = "NEW_DISCARD", menuName = "MergeToSlay.CARD/new DISCARD action", order = 1)]
	public class DiscardActionData: ActionBase
	{
		[Range(1, 5)]
		public int Value = 1;
		
		
		
		override public void Execute(GameEntity battleEntity, GameEntity boardEntity, GameEntity playerEntity,
									CombatService combatService, BoardService boardService)
		{
			boardService.DiscardGridObjects(boardEntity, Value);
		}

		public override void ExecuteEnemyBehaviour(GameEntity battleEntity, GameEntity boardEntity, 
													GameEntity enemyEntity, GameEntity playerEntity, 
													CombatService combatService, BoardService boardService)
		{
			boardService.DiscardGridObjects(boardEntity, Value);
		}

	}
}

