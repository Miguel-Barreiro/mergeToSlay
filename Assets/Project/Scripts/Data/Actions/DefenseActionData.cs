using System.Collections.Generic;
using MergeToStay.Services;
using UnityEngine;

namespace MergeToStay.Data.Actions
{
	[CreateAssetMenu(fileName = "NEW_DEFENSE", menuName = "MergeToSlay.CARD/new DEFENSE action", order = 1)]
	public class DefenseActionData : ActionBase
	{
		[Range(1, 100)]
		public int Value = 1;

		override public void Execute(GameEntity battleEntity, GameEntity boardEntity, GameEntity playerEntity,
									CombatService combatService, BoardService boardService)
		{
			combatService.AddPlayerDefense(battleEntity, Value);
		}


		virtual public void ExecuteEnemyBehaviour(GameEntity battleEntity, GameEntity boardEntity,
												GameEntity enemyEntity, GameEntity playerEntity,
												CombatService combatService, BoardService boardService)
		{
			combatService.AddEnemyDefense(battleEntity, Value);
			
		}

	}
}