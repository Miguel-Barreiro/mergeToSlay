using System.Collections.Generic;
using Entitas;
using MergeToStay.MonoBehaviours;
using MergeToStay.MonoBehaviours.Path;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.Combat
{
	public class NodeCompleteSystem : ReactiveGameSystem, IInitializeSystem
	{
		[Inject] private RootView _rootView;

		private IGroup<GameEntity> _pathGroup;

		public void Initialize() => _pathGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Path));

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity pathEntity = _pathGroup.GetSingleEntity();
			if (!pathEntity.hasPath)
				return;
			
			_rootView.ShowView(View.Path);
			
			foreach (GameEntity eventEntity in entities)
				eventEntity.Destroy();
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.NodeExitEvent);
		}

		protected override bool Filter(GameEntity entity) => entity.hasNodeExitEvent;
	}
}