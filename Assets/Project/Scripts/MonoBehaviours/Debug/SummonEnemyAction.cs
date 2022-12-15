using MergeToStay.Data;
using MergeToStay.Services;
using UnityEngine;
using Zenject;

namespace MergeToStay.MonoBehaviours.Debug
{
	public class SummonEnemyAction : MonoBehaviour
	{
		[Inject] private CombatService _combatService;
		[Inject] private EnemyData _defaultEnemyData;

		public void SummonEnemyDebug()
		{
			_combatService.SummonEnemy(_defaultEnemyData, 0);
		}

	}
}