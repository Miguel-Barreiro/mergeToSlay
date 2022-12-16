using System;
using System.Collections.Generic;
using Entitas;
using MergeToStay.Components.Player;
using MergeToStay.Data;
using MergeToStay.MonoBehaviours;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.Combat
{
	public class RestSystem : ReactiveGameSystem, IInitializeSystem
	{
		[Inject] private ViewService _viewService;
		[Inject] private GameConfigData _gameConfigData;
		[Inject] private CombatService _combatService;

		private IGroup<GameEntity> _playerGroup;

		public void Initialize() => _playerGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity playerEntity = _playerGroup.GetSingleEntity();
			if (!playerEntity.hasPlayer)
				return;

			foreach (GameEntity eventEntity in entities)
			{
				PlayerComponent player = playerEntity.player;
				_combatService.HealPlayer(playerEntity, _gameConfigData.CampHealingAmount);
				playerEntity.ReplacePlayer(player.Health, player.Gold, player.DrawLevel, player.Deck);
				
				_viewService.CreateShowViewEvent(View.Path);

				eventEntity.Destroy();
			}
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.RestEvent);
		}

		protected override bool Filter(GameEntity entity) => entity.isRestEvent;
	}
}