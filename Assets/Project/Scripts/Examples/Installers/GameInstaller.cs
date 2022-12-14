using MergeToStay.Examples.Controllers;
using Zenject;

namespace MergeToStay.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FeaturesController>().AsSingle();
        }
    }
}