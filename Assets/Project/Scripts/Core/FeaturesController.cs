using MergeToStay.Features;
using Zenject;

namespace MergeToStay.Core
{
    public sealed class FeaturesController : IInitializable, ITickable
    {
        Entitas.Systems _systems;
        
        [Inject] 
        private DiContainer _container;
        
        public void Initialize()
        {
            // var contexts = Contexts.sharedInstance;
            // Contexts[] extraArgs = new[] {contexts};

            _systems = new Feature("Features");

            _systems.Add(_container.Instantiate<CombatFeature>().AddSystems());
            _systems.Add(_container.Instantiate<PathFeature>().AddSystems());
            _systems.Add(_container.Instantiate<SmallSystemsFeature>().AddSystems());

            // call Initialize() on all of the IInitializeSystems
            _systems.Initialize();
        }

        public void Tick()
        {
            // call Execute() on all the IExecuteSystems and 
            // ReactiveSystems that were triggered last frame
            _systems.Execute();

            // call cleanup() on all the ICleanupSystems
            _systems.Cleanup();
        }
    }

}
