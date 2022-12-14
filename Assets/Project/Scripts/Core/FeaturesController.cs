using MergeToStay.Examples.Features;
using Zenject;

namespace MergeToStay.Core
{
    public class FeaturesController : IInitializable, ITickable
    {
        Entitas.Systems _systems;

        public void Initialize()
        {
            // get a reference to the contexts
            var contexts = Contexts.sharedInstance;
        
            // create the systems by creating individual features
            _systems = new Feature("Features").Add(new TutorialFeature(contexts));

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
