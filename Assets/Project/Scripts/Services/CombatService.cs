using MergeToStay.Components.Combat.Battle;
using MergeToStay.Core;
using MergeToStay.Data;
using UnityEngine;
using Zenject;

namespace MergeToStay.Services
{
	public class CombatService
	{
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

		public bool SummonEnemy(GameEntity battleEntity, EnemyData enemyData, int position)
		{
			Battle battle = battleEntity.battle;
			
			if (battle.Enemies.Count > 2)
				return false;

			GameEntity newEnemy = _context.CreateEntity();
			GameObject enemyView = _prefabFactoryPool.NewEnemy(enemyData.Prefab);
			newEnemy.AddEnemy(enemyView, enemyData, enemyData.Hp, 0, 0, 0 );

			battle.Enemies.Insert(position, newEnemy);

			battleEntity.ReplaceBattle(battle.Enemies, battle.CardDrawLevel);
			return true;
		}

	}
}