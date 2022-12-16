using System;
using System.Collections.Generic;
using MergeToStay.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MergeToStay.Data.Actions
{
	[CreateAssetMenu(fileName = "NEW_BreakDefense", menuName = "MergeToSlay.CARD/new BREAK DEFENSE action", order = 1)]
	public class BreakDefenseActionData : ActionBase
	{
		[Range(1, 100)]
		public int Value = 1;
		
		[Title("Targets")]
		[EnumToggleButtons]
		public ActionsModel.CombatTargetsEnum CombatTargets = ActionsModel.CombatTargetsEnum.FORWARD;
		
		override public void Execute(GameEntity battleEntity, GameEntity boardEntity, GameEntity playerEntity,
									CombatService combatService, BoardService boardService)
		{
			List<GameEntity> enemies = combatService.GetPlayerTargets(battleEntity, CombatTargets);
			foreach (GameEntity enemyEntity in enemies)
				combatService.BreakEnemyDefense(enemyEntity, Value);
			
			if (combatService.IsTargetSelf(CombatTargets))
				combatService.BreakPlayerDefense(battleEntity, Value);
		}

		public override void ExecuteEnemyBehaviour(GameEntity battleEntity, GameEntity boardEntity, 
													GameEntity enemyEntity, GameEntity playerEntity, 
													CombatService combatService, BoardService boardService)
		{
			if (combatService.IsTargetSelf(CombatTargets))
				combatService.BreakEnemyDefense(enemyEntity, Value);
			
			if (combatService.IsTargetFoward(CombatTargets))
				combatService.BreakPlayerDefense(battleEntity, Value);
			
		}
	}
}