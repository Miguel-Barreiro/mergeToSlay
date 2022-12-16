using System.Collections.Generic;
using MergeToStay.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MergeToStay.Data.Actions
{
	[CreateAssetMenu(fileName = "NEW_HEAL", menuName = "MergeToSlay.CARD/new HEAL action", order = 1)]
	public class HealActionData : ActionBase
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
				combatService.HealEnemy(enemyEntity, Value);

			if (combatService.IsTargetSelf(CombatTargets))
				combatService.HealPlayer(playerEntity, Value);
		}

		public override void ExecuteEnemyBehaviour(GameEntity battleEntity, GameEntity boardEntity, 
													GameEntity enemyEntity, GameEntity playerEntity, 
													CombatService combatService, BoardService boardService)
		{
			List<GameEntity> enemies = combatService.GetPlayerTargets(battleEntity, CombatTargets);
			foreach (GameEntity targetEnemyEntity in enemies)
				combatService.HealEnemy(targetEnemyEntity, Value);

			if (combatService.IsTargetSelf(CombatTargets))
				combatService.HealEnemy(enemyEntity, Value);

		}
		
	}
}