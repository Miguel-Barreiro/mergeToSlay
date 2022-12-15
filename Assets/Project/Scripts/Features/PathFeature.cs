using MergeToStay.Core;
using MergeToStay.Systems.Combat;
using MergeToStay.Systems.Combat.Board;
using Zenject;

namespace MergeToStay.Features
{
	public sealed class PathFeature : Feature, ISystemInstaller<PathFeature>
	{
		[Inject] 
		private DiContainer _container;

		public PathFeature() : base(nameof(PathFeature)) { }
		
		public PathFeature AddSystems() 
		{
			Add(_container.Instantiate<PathInitSystem>());
			Add(_container.Instantiate<PickedNodeExecuteSystem>());
			Add(_container.Instantiate<PathViewSystem>());

			return this;
		}
	}
}