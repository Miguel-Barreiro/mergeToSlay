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
			
			CardsModel.Deck deck = new CardsModel.Deck();
			foreach (CardsModel.Card card in gameConfigData.CardListData.Cards)
				deck.Cards.Add(card);

			entity.ReplacePlayer(gameConfigData.StartingHealth, gameConfigData.StartingGold, gameConfigData.StartingDrawLevel, deck);
		}

		protected override void Execute(List<GameEntity> entities) => Initialize();

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.RestartGameEvent);
		}

		protected override bool Filter(GameEntity entity) => entity.isRestartGameEvent;
	}
}