using System.Collections.Generic;
using Entitas;
using MergeToStay.Data;
using MergeToStay.Services;
using UnityEngine;
using Zenject;

namespace MergeToStay.Systems.Combat
{
	public class DrawCardSystem : ReactiveGameSystem, IInitializeSystem
	{

		[Inject] private GridObjectService _gridObjectService;
		[Inject] private BoardService _boardService;
		[Inject] private GameConfigData _gameConfig;

		[Inject] private CardData _debugCardData;

		private IGroup<GameEntity> _boardGroup;
		private IGroup<GameEntity> _playerGroup;

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity playerEntity = _playerGroup.GetSingleEntity();
			GameEntity boardEntity = _boardGroup.GetSingleEntity();
			if (!boardEntity.hasBoard)
				return;

			foreach (GameEntity eventEntity in entities)
			{
				for (int i = 0; i < eventEntity.drawCardEvent.HowMany; i++)
				{
					Vector2? emptyCell = _boardService.GetFirsEmptySpace(boardEntity);
					if (emptyCell == null)
						continue;

					CardsModel.Card card = GetCardFromDeck(playerEntity);
					GameEntity gridObjectView = _gridObjectService.CreateNewGridObjectFromCard(card.CardData, card.Level);
					_boardService.MoveGridObject(boardEntity, gridObjectView, emptyCell.Value);
				}
				eventEntity.Destroy();
			}
		}

		private static CardsModel.Card GetCardFromDeck(GameEntity playerEntity)
		{
			List<CardsModel.Card> cards = playerEntity.player.Deck.Cards;
			return cards[Random.Range(0, cards.Count)];
		}


		public void Initialize()
		{
			_playerGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
			_boardGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Board));
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.DrawCardEvent);
		}

		protected override bool Filter(GameEntity entity) { return entity.hasDrawCardEvent; }
	}
}