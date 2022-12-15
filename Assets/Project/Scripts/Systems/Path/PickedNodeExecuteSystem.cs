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
		[Inject] private RootView _rootView;

		private IGroup<GameEntity> _pathGroup;

		public void Initialize()
		{
			_pathGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Path));

			_rootView.ShowPathView();
		}

		protected override void Execute(List<GameEntity> entities)
		{
			GameEntity pathEntity = _pathGroup.GetSingleEntity();
			if (!pathEntity.hasPath)
				return;
			
			foreach (GameEntity eventEntity in entities)
			{
				_pathService.SetCurrentNodeId(pathEntity, eventEntity.nodeEnterEvent.PickedNodeId);

				switch (eventEntity.nodeEnterEvent.NodeType)
				{
					case NodeType.Battle:
					case NodeType.EliteBattle:
					case NodeType.BossBattle:
						_rootView.ShowBattleView();
						break;
					case NodeType.Camp:
						_rootView.ShowCampView();
						break;
					case NodeType.Shop:
						_rootView.ShowShopView();
						break;
				}

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