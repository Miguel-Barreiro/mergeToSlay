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

		private IGroup<GameEntity> _pathGroup;

		public void Initialize() => _pathGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity playerEntity = _pathGroup.GetSingleEntity();
			if (!playerEntity.hasPlayer)
				return;

			
			foreach (GameEntity eventEntity in entities)
			{
				PlayerComponent player = playerEntity.player;
				int newHealth = player.Health + _gameConfigData.CampHealingAmount;
				newHealth = Math.Clamp(newHealth, 0, _gameConfigData.MaxHealth);
				playerEntity.ReplacePlayer(newHealth, player.Gold, player.DrawLevel);

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