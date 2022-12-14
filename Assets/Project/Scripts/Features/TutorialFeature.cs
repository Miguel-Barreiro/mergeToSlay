using MergeToSlay.Examples.Systems;
using MergeToSlay.Systems;

namespace MergeToSlay.Examples.Features
{
    public class TutorialFeature : Feature
    {
        public TutorialFeature(Contexts contexts) : base(nameof(TutorialFeature))
        {
            Add(new HelloWorldSystem(contexts));
            Add(new DebugMessageSystem(contexts));
        }
    }
}
