using MergeToStay.Examples.Systems;

namespace MergeToStay.Examples.Features
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
