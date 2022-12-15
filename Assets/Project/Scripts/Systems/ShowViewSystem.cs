using System.Collections.Generic;
using Entitas;
using MergeToStay.MonoBehaviours;
using Zenject;

namespace MergeToStay.Systems.Combat
{
	public class ShowViewSystem : ReactiveGameSystem, IInitializeSystem
	{
		[Inject] private RootView _rootView;

		public void Initialize() => _rootView.ShowView(View.Path);

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (GameEntity eventEntity in entities)
			{
				_rootView.ShowView(eventEntity.showViewEvent.View);

				eventEntity.Destroy();
			}
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.ShowViewEvent);
		}

		protected override bool Filter(GameEntity entity) => entity.hasShowViewEvent;
	}
}