using System.Collections.Generic;
using Entitas;
using MergeToStay.Services;
using UnityEngine;
using Zenject;

namespace MergeToStay.Systems.Combat
{
	public class PickedNodeExecuteSystem : ReactiveGameSystem, IInitializeSystem
	{
		[Inject] private PathService _pathService;
		
		private IGroup<GameEntity> _pathGroup;

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity pathEntity = _pathGroup.GetSingleEntity();
			if (!pathEntity.hasPath)
				return;
			
			foreach (GameEntity eventEntity in entities)
			{
				_pathService.SetCurrentNodeId(pathEntity, eventEntity.nodeEnterEvent.PickedNodeId);
				Debug.Log($"NodeExecuteSystem: {eventEntity.nodeEnterEvent.PickedNodeId}");
				eventEntity.Destroy();
			}

		}

		public void Initialize()
		{
			_pathGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Path));
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.NodeEnterEvent);
		}

		protected override bool Filter(GameEntity entity) => entity.hasNodeEnterEvent;
	}
}