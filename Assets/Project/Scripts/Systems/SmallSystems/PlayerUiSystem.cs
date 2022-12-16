using System.Collections.Generic;
using Entitas;
using MergeToStay.Data;
using MergeToStay.MonoBehaviours;
using MergeToStay.MonoBehaviours.UI;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.SmallSystems
{
	public class PlayerUiSystem : ReactiveGameSystem, IInitializeSystem
	{
		[Inject] GameContext gameContext;
		[Inject] GameConfigData gameConfigData;
		[Inject] PlayerUiView playerUiView;
		[Inject] ViewService viewService;
		

		public void Initialize()
		{
			GameEntity entity = gameContext.CreateEntity();
			entity.AddPlayer(gameConfigData.StartingHealth, gameConfigData.StartingGold, gameConfigData.StartingDrawLevel);

			viewService.CreateShowViewEvent(View.PlayerUi, false);
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (GameEntity entity in entities)
			{
				playerUiView.SetHealth(entity.player.Health);
				playerUiView.SetGold(entity.player.Gold);
				playerUiView.SetDrawLevel(entity.player.DrawLevel);
			}
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Player);
		}

		protected override bool Filter(GameEntity entity) => entity.hasPlayer;
	}
}