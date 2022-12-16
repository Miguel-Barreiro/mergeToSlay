using System.Collections.Generic;
using MergeToStay.Services;
using UnityEngine;

namespace MergeToStay.Data.Actions
{
	[CreateAssetMenu(fileName = "NEW_DRAW", menuName = "MergeToSlay.CARD/new DRAW action", order = 1)]
	public class DrawActionData : ActionBase
	{
		[Range(1, 5)]
		public int Value = 1;
		
		
		override public void Execute(GameEntity battleEntity, GameEntity boardEntity, GameEntity playerEntity,
									CombatService combatService, BoardService boardService)
		{
			combatService.CreateDrawCardEvent(Value);
		}

		public override void ExecuteEnemyBehaviour(GameEntity battleEntity, GameEntity boardEntity, 
													GameEntity enemyEntity, GameEntity playerEntity, 
													CombatService combatService, BoardService boardService)
		{
			combatService.CreateDrawCardEvent(Value);
		}
	}
}



