using System.Collections.Generic;
using Entitas;
using MergeToStay.Data;
using Zenject;

namespace MergeToStay.Systems.SmallSystems
{
	public class GameSystem : ReactiveGameSystem, IInitializeSystem
	{
		[Inject] GameContext gameContext;
		[Inject] GameConfigData gameConfigData;

		public void Initialize()
		{
			GameEntity entity = gameContext.CreateEntity();
			entity.AddPlayer(gameConfigData.StartingHealth, gameConfigData.StartingGold, gameConfigData.StartingDrawLevel);
		}

		protected override void Execute(List<GameEntity> entities) => Initialize();

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.RestartGameEvent);
		}

		protected override bool Filter(GameEntity entity) => entity.isRestartGameEvent;
	}
}