using System;
using System.Collections.Generic;
using MergeToStay.Components.Combat.Battle;
using MergeToStay.Components.Player;
using MergeToStay.Core;
using MergeToStay.Data;
using MergeToStay.Data.Actions;
using MergeToStay.MonoBehaviours;
using UnityEngine;
using Zenject;

namespace MergeToStay.Services
{
	public class CombatService
	{
		[Inject] private GameConfigData _gameConfigData;
		[Inject] private GameContext _context;
		[Inject] private PrefabFactoryPool _prefabFactoryPool;

		public GameEntity CreateMergeEvent(Vector2 originCell, Vector2 targetCell)
		{
			GameEntity result = _context.CreateEntity();
			result.AddMergeEvent(originCell, targetCell);
			return result;
		}
		
		public GameEntity CreateBattleUseEvent(Vector2 originCell)
		{
			GameEntity result = _context.CreateEntity();
			result.AddGridObjectUseEvent(originCell);
			return result;
		}

		public GameEntity CreateDrawCardEvent(int howMany)
		{
			GameEntity result = _context.CreateEntity();
			result.AddDrawCardEvent(howMany);
			return result;
		}
		
		public GameEntity CreateGameStateChange(Battle.BattleState newState)
		{
			GameEntity result = _context.CreateEntity();
			result.AddChangeCombatStateEvent(newState);
			return result;
		}

		public GameEntity CreateCombatStartEvent(View type)
		{
			GameEntity result = _context.CreateEntity();
			result.AddStartCombatEvent(type);
			return result;
		}

		
		public bool SummonEnemy(GameEntity battleEntity, EnemyData enemyData, int position)
		{
			Battle battle = battleEntity.battle;
			
			if (battle.Enemies.Count > 2)
				return false;

			GameEntity newEnemy = _context.CreateEntity();
			GameObject enemyView = _prefabFactoryPool.NewEnemy(enemyData.Prefab);
			newEnemy.AddEnemy(enemyView, enemyData, enemyData.Hp, new TurnStats(), new Effects(), 0, 0 );

			battle.Enemies.Insert(position, newEnemy);

			ResetBattle(battleEntity);
			return true;
		}

		public void ResetBattle(GameEntity battleEntity)
		{
			Battle battle = battleEntity.battle;
			battleEntity.ReplaceBattle(battle.Enemies, battle.CardDrawLevel, battle.State, battle.PlayerCurrentTurnStats, battle.PlayerEffects);
		}

		public void ResetBattleTurnStats(GameEntity battleEntity)
		{
			Battle battle = battleEntity.battle;
			battle.PlayerCurrentTurnStats = new TurnStats();
			ResetBattle(battleEntity);
		}

		public void ResetFullBattleStats(GameEntity battleEntity, GameEntity playerEntity)
		{
			PlayerComponent player = playerEntity.player;
			Battle battle = battleEntity.battle;
			battle.PlayerCurrentTurnStats = new TurnStats();
			battle.PlayerEffects = new Effects();
			battle.CardDrawLevel = player.DrawLevel;
			ResetBattle(battleEntity);
		}

		public void AddPlayerDefense(GameEntity battleEntity, int value)
		{
			battleEntity.battle.PlayerCurrentTurnStats.Defense += value;
		}

		public List<GameEntity> GetEnemyTargets(GameEntity battleEntity, ActionsModel.CombatTargetsEnum combatTargets)
		{
			// NONE = 0, 
			// FORWARD = 1 << 1,
			// MIDDLE = 1 << 3,
			// BACK = 1 << 4,
			// SELF = 1 << 5,
			// ALL = FORWARD | MIDDLE | BACK | SELF 
			List<GameEntity> enemyTargets = new List<GameEntity>();
			bool isFoward = (combatTargets & ActionsModel.CombatTargetsEnum.FORWARD) != 0;
			bool isMiddle = (combatTargets & ActionsModel.CombatTargetsEnum.MIDDLE) != 0;
			bool isBack = (combatTargets & ActionsModel.CombatTargetsEnum.BACK) != 0;

			List<GameEntity> battleEnemies = battleEntity.battle.Enemies;
			int enemiesCount = battleEnemies.Count;
			switch (enemiesCount)
			{
				case 1:
					if (isFoward || isBack || isMiddle)
						enemyTargets.Add(battleEnemies[0]);
					break;
				case 2:
					if (isFoward)
						enemyTargets.Add(battleEnemies[0]);
					if (isMiddle || isBack)
						enemyTargets.Add(battleEnemies[1]);
					break;
				case 3:
					if (isFoward)
						enemyTargets.Add(battleEnemies[0]);
					if (isMiddle)
						enemyTargets.Add(battleEnemies[1]);
					if (isBack)
						enemyTargets.Add(battleEnemies[2]);
					break;
			}
			
			return enemyTargets;
		}
		
		public bool IsTargetSelf(ActionsModel.CombatTargetsEnum combatTargets)
		{
			// NONE = 0, 
			// FORWARD = 1 << 1,
			// MIDDLE = 1 << 3,
			// BACK = 1 << 4,
			// SELF = 1 << 5,
			// ALL = FORWARD | MIDDLE | BACK | SELF 
			return (combatTargets & ActionsModel.CombatTargetsEnum.SELF) != 0;
		}

		public void AddEnemyDefense(GameEntity enemyEntity, int armor)
		{
			enemyEntity.enemy.TurnStats.Defense += armor;
		}
		public void DamageEnemy(GameEntity enemyEntity, int damage)
		{
			enemyEntity.enemy.Hp -= damage;
		}

		public void DamagePlayer(GameEntity player, int damage)
		{
			player.player.Health -= damage;
		}

		public void HealPlayer(GameEntity playerEntity, int value)
		{
			int newHealth = playerEntity.player.Health + value;
			playerEntity.player.Health = Math.Clamp(newHealth, 0, _gameConfigData.MaxHealth);
		}

		public void HealEnemy(GameEntity enemyEntity, int value)
		{
			int newHealth = enemyEntity.enemy.Hp + value;
			enemyEntity.enemy.Hp = Math.Clamp(newHealth, 0, enemyEntity.enemy.EnemyData.Hp);
		}

		public void StunEnemy(GameEntity targetEnemyEntity, int turns)
		{
			targetEnemyEntity.enemy.Effects.StunTurns += turns;
		}


		public void BreakEnemyDefense(GameEntity targetEnemyEntity, int value)
		{
			targetEnemyEntity.enemy.TurnStats.Defense = Math.Max(0, targetEnemyEntity.enemy.TurnStats.Defense - value);
		}
		public void BreakPlayerDefense(GameEntity battleEntity, int value)
		{
			TurnStats battlePlayerCurrentTurnStats = battleEntity.battle.PlayerCurrentTurnStats;
			battlePlayerCurrentTurnStats.Defense = Math.Max(0, battlePlayerCurrentTurnStats.Defense - value);
		}
	}
}