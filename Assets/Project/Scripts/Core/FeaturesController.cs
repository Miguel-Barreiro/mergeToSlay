using MergeToSlay.Examples.Features;
using MergeToSlay.Features;
using MergeToStay.Systems;
using Zenject;

namespace MergeToSlay.Core
{
    public sealed class FeaturesController : IInitializable, ITickable
    {
        Entitas.Systems _systems;
        
        [Inject] 
        private DiContainer _container;
        
        public void Initialize()
        {
            // get a reference to the contexts
            var contexts = Contexts.sharedInstance;
            Contexts[] extraArgs = new[] {contexts};

            // create the systems by creating individual features
            _systems = new Feature("Features");

            // Add(new TutorialFeature(contexts)).
            _systems.Add(_container.Instantiate<CombatFeature>(extraArgs).AddSystems());

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
