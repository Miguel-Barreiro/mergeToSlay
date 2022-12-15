using MergeToStay.Core;
using MergeToStay.Systems.Combat;
using Zenject;

namespace MergeToStay.Features
{
	public sealed class SmallSystemsFeature : Feature, ISystemInstaller<SmallSystemsFeature>
	{
		[Inject] 
		private DiContainer _container;

		public SmallSystemsFeature() : base(nameof(SmallSystemsFeature)) { }
		
		public SmallSystemsFeature AddSystems()
		{
			Add(_container.Instantiate<ShowViewSystem>());

			return this;
		}
	}
}