using MergeToStay.Core;
using MergeToStay.Systems.SmallSystems;
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
			Add(_container.Instantiate<GameSystem>());
			Add(_container.Instantiate<ShowViewSystem>());
			Add(_container.Instantiate<PlayerUiSystem>());

			return this;
		}
	}
}