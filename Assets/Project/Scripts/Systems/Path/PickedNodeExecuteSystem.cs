using System;
using System.Collections.Generic;
using Entitas;
using MergeToStay.MonoBehaviours;
using MergeToStay.MonoBehaviours.Path;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.Combat
{
	public class PickedNodeExecuteSystem : ReactiveGameSystem, IInitializeSystem
	{
		[Inject] private PathService _pathService;
		[Inject] private ViewService _viewService;

		private IGroup<GameEntity> _pathGroup;

		public void Initialize() => _pathGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Path));

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity pathEntity = _pathGroup.GetSingleEntity();
			if (!pathEntity.hasPath)
				return;
			
			foreach (GameEntity eventEntity in entities)
			{
				_pathService.SetCurrentNodeId(pathEntity, eventEntity.nodeEnterEvent.PickedNodeId);

				string nodeTypeName = Enum.GetName(typeof(NodeType), eventEntity.nodeEnterEvent.NodeType);
				View view = (View) Enum.Parse(typeof(View), nodeTypeName);
				_viewService.CreateShowViewEvent(view);

				eventEntity.Destroy();
			}
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.NodeEnterEvent);
		}

		protected override bool Filter(GameEntity entity) => entity.hasNodeEnterEvent;
	}
}