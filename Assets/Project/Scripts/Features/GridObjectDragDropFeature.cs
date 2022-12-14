using MergeToSlay.Core;
using MergeToSlay.Systems;
using Zenject;

namespace MergeToSlay.Features
{
	public sealed class GridObjectDragDropFeature : Feature, ISystemInstaller<GridObjectDragDropFeature>
	{
		[Inject] 
		private DiContainer _container;

		private readonly Contexts _contexts;

		public GridObjectDragDropFeature(Contexts contexts) : base(nameof(GridObjectDragDropFeature))
		{
			_contexts = contexts;
		}
		
		public GridObjectDragDropFeature AddSystems() 
		{
			Contexts[] extraArgs = new[] {_contexts};
			Add(_container.Instantiate<GridObjectDragSystem>(extraArgs));
			Add(_container.Instantiate<DragGridObjectUpdateViewSystem>(extraArgs));
			return this;
		}
	}
}