using System.Collections.Generic;
using MergeToStay.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MergeToStay.Data.Actions
{
	[CreateAssetMenu(fileName = "NEW_STUN", menuName = "MergeToSlay.CARD/new STUN action", order = 1)]
	public class StunActionData : ActionBase
	{

		[Range(1, 5)]
		public int Turns = 1;
		
		[Title("Targets")]
		[EnumToggleButtons]
		public ActionsModel.CombatTargetsEnum CombatTargets = ActionsModel.CombatTargetsEnum.FORWARD;
		
		
		
		override public void Execute(GameEntity battleEntity, GameEntity boardEntity, GameEntity playerEntity,
									CombatService combatService, BoardService boardService)
		{
			List<GameEntity> enemies = combatService.GetPlayerTargets(battleEntity, CombatTargets);
			foreach (GameEntity enemyEntity in enemies)
				combatService.StunEnemy(enemyEntity, Turns);
		}

		public override void ExecuteEnemyBehaviour(GameEntity battleEntity, GameEntity boardEntity, 
													GameEntity enemyEntity, GameEntity playerEntity, 
													CombatService combatService, BoardService boardService)
		{

			if (combatService.IsTargetSelf(CombatTargets))
				combatService.StunEnemy(enemyEntity, Turns);
			
		}
	}
}
