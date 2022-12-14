using MergeToStay.Core;
using MergeToStay.Services;
using Zenject;

namespace MergeToStay.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance<GameContext>(Contexts.sharedInstance.game);
            Container.BindInstance<InputContext>(Contexts.sharedInstance.input);
            
            Container.BindInterfacesAndSelfTo<FeaturesController>().AsSingle();

            InstallGameServices();
        }


        private void InstallGameServices()
        {
            Container.BindInstance<BoardService>(new BoardService());

        }
    }
}