using MergeToStay.Data;
using UnityEngine;
using Zenject;

namespace MergeToStay.MonoBehaviours.Debug
{
	public class SummonEnemyAction : MonoBehaviour
	{
		[Inject] private GameContext _context;
		[Inject] private EnemyData _defaultEnemyData;

		public void SummonEnemyDebug()
		{
			GameEntity result = _context.CreateEntity();
			result.AddSummonEnemyEvent(_defaultEnemyData, 0);
		}

	}
}