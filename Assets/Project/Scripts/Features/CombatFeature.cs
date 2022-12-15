using MergeToStay.Core;
using MergeToStay.Systems;
using MergeToStay.Systems.Combat;
using MergeToStay.Systems.Combat.Board;
using Zenject;

namespace MergeToStay.Features
{
	public sealed class CombatFeature : Feature, ISystemInstaller<CombatFeature>
	{
		[Inject] 
		private DiContainer _container;

		[Inject]
		private Contexts _contexts;

		public CombatFeature() : base(nameof(CombatFeature)) { }
		
		public CombatFeature AddSystems() 
		{
			Add(_container.Instantiate<GridObjectDragSystem>());
			Add(_container.Instantiate<DragGridObjectUpdateViewSystem>());
			Add(_container.Instantiate<CombatInitSystem>());
			Add(_container.Instantiate<BoardViewSystem>());
			Add(_container.Instantiate<MergeSystem>());
			
			return this;
		}
	}
}