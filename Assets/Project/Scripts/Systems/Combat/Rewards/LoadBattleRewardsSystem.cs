using System.Collections.Generic;
using Entitas;
using MergeToStay.Core;
using MergeToStay.Data;
using MergeToStay.Data.Rewards;
using MergeToStay.MonoBehaviours.Camp;
using MergeToStay.MonoBehaviours.Combat;
using MergeToStay.Services;
using UnityEngine;
using Zenject;

namespace MergeToStay.Systems.Combat
{
	public class LoadBattleRewardsSystem : ReactiveGameSystem, IInitializeSystem
	{
		[Inject] private BattleRewardsView _battleRewardsView;
		[Inject] private PrefabFactoryPool _prefabFactoryPool;
		[Inject] private GameConfigData _gameConfigData;
		[Inject] private BattleRewardsService _battleRewardsService;

		private IGroup<GameEntity> _battleGroup;

		public void Initialize()
		{
			_battleGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Battle));
		}

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity battleEntity = _battleGroup.GetSingleEntity();
			if (!battleEntity.hasBattle)
				return;

			for (int i = 0; i < battleEntity.battle.CombatData.Rewards.Count; i++)
			{
				RewardBase reward = battleEntity.battle.CombatData.Rewards[i];
				GameObject view = reward.GetView(_battleRewardsService);
				_battleRewardsView.AddReward(view.transform);
			}
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.LoadBattleRewardsEvent);
		}

		protected override bool Filter(GameEntity entity) => entity.isLoadBattleRewardsEvent;
	}
}