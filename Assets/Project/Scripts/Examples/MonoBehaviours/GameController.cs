using MergeToStay.Examples.Features;
using UnityEngine;

namespace MergeToStay.Examples.MonoBehaviours
{
    public class GameController : MonoBehaviour
    {
        Entitas.Systems _systems;

        void Start()
        {
            // get a reference to the contexts
            var contexts = Contexts.sharedInstance;
        
            // create the systems by creating individual features
            _systems = new Feature("Features").Add(new TutorialFeature(contexts));

            // call Initialize() on all of the IInitializeSystems
            _systems.Initialize();
        }

        void Update()
        {
            // call Execute() on all the IExecuteSystems and 
            // ReactiveSystems that were triggered last frame
            _systems.Execute();

            // call cleanup() on all the ICleanupSystems
            _systems.Cleanup();
        }
    }

}
