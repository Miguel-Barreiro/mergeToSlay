using System.Collections.Generic;
using Entitas;
using MergeToStay.Components.Combat;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.Combat.Board
{
	public class MergeSystem : ReactiveGameSystem, IInitializeSystem
	{
		[Inject]
		private BoardService _boardService;
		private IGroup<GameEntity> _boardGroup;

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity boardEntity = _boardGroup.GetSingleEntity();
			if (!boardEntity.hasBoard)
				return;

			foreach (GameEntity eventEntity in entities)
			{
				MergeEvent mergeEvent = eventEntity.mergeEvent;
				bool mergeComplete = _boardService.MergeGridObjects(boardEntity, mergeEvent.originCell, mergeEvent.targetCell);
				if (!mergeComplete)
					_boardService.ResetBoard(boardEntity);

				eventEntity.Destroy();
			}
			
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.MergeEvent);
		}
		protected override bool Filter(GameEntity entity) { return entity.hasMergeEvent; }

		public void Initialize()
		{
			_boardGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Board));
		}
	}
}