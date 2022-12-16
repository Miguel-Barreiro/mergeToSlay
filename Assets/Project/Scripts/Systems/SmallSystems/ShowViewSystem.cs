using System.Collections.Generic;
using Entitas;
using MergeToStay.Data;
using MergeToStay.MonoBehaviours;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Systems.SmallSystems
{
	public class ShowViewSystem : ReactiveGameSystem, IInitializeSystem
	{
		[Inject] private RootView _rootView;
		
		[Inject] private CombatService _combatService;
		[Inject] private GameConfigData _gameConfigData;

		public void Initialize() => _rootView.ShowView(View.Path);

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (GameEntity eventEntity in entities)
			{
				_rootView.ShowView(eventEntity.showViewEvent.View, eventEntity.showViewEvent.HideOpenedViews);
				if (eventEntity.showViewEvent.View == View.Battle || 
					eventEntity.showViewEvent.View == View.BossBattle ||
					eventEntity.showViewEvent.View == View.EliteBattle )
				{
					_combatService.CreateCombatStartEvent(eventEntity.showViewEvent.View);
				}
				
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