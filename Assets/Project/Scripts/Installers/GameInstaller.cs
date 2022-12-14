using MergeToStay.Core;
using MergeToStay.MonoBehaviours.Combat;
using MergeToStay.Services;
using UnityEngine;
using Zenject;

namespace MergeToStay.Installers
{
    public class GameInstaller : MonoInstaller
    {
        
        [SerializeField]
        private BoardView BoardView;
        
        public override void InstallBindings()
        {
            Container.BindInstance<GameContext>(Contexts.sharedInstance.game);
            Container.BindInstance<InputContext>(Contexts.sharedInstance.input);
            
            Container.BindInterfacesAndSelfTo<FeaturesController>().AsSingle();

            InstallGameServices();
        }

        private void InstallViews()
        {
            Container.BindInstance<BoardView>(BoardView);

        }


        private void InstallGameServices()
        {
            Container.BindInstance<BoardService>(new BoardService());

        }
    }
}