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

		protected override void Execute(List<GameEntity> entities)
		{

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
					
					GameEntity gridObjectView = _gridObjectService.CreateNewGridObjectFromCard(_debugCardData);
					_boardService.MoveGridObject(boardEntity, gridObjectView, emptyCell.Value);
				}
				eventEntity.Destroy();
			}
		}


		public void Initialize()
		{
			_boardGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Board));
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.DrawCardEvent);
		}

		protected override bool Filter(GameEntity entity) { return entity.hasDrawCardEvent; }
	}
}