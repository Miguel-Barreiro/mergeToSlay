using MergeToSlay.Core;
using MergeToSlay.Systems;
using MergeToStay.Systems;
using Zenject;

namespace MergeToSlay.Features
{
	public sealed class CombatFeature : Feature, ISystemInstaller<CombatFeature>
	{
		[Inject] 
		private DiContainer _container;

		private readonly Contexts _contexts;

		public CombatFeature(Contexts contexts) : base(nameof(CombatFeature))
		{
			_contexts = contexts;
		}
		
		public CombatFeature AddSystems() 
		{
			Contexts[] extraArgs = new[] {_contexts};
			Add(_container.Instantiate<GridObjectDragSystem>(extraArgs));
			Add(_container.Instantiate<DragGridObjectUpdateViewSystem>(extraArgs));
			Add(_container.Instantiate<CombatInitSystem>(extraArgs));
			
			return this;
		}
	}
}