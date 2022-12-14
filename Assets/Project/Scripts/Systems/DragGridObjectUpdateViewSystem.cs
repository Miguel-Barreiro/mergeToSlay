using System.Collections.Generic;
using Entitas;
using MergeToSlay.Services;
using Zenject;

namespace MergeToSlay.Systems
{
	public class DragGridObjectUpdateViewSystem : ReactiveSystem<GameEntity>
	{
		[Inject]
		private BoardService _boardService;
		
		public DragGridObjectUpdateViewSystem(Contexts contexts) : base(contexts.game) { }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Board);
		}
		protected override bool Filter(GameEntity entity) { return true; }
		protected override void Execute(List<GameEntity> entities) {  }
	}
}