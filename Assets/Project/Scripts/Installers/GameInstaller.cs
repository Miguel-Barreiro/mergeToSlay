using MergeToSlay.Core;
using MergeToSlay.MonoBehaviours.Combat;
using MergeToSlay.Services;
using UnityEngine;
using Zenject;

namespace MergeToSlay.Installers
{
    public class GameInstaller : MonoInstaller
    {

        [SerializeField]
        private RectTransform BoardCanvas;

        [SerializeField]
        private GameObject BoardViewPrefab;

        private GameObject _boardView;

        private void Awake()
        {
        }

        public override void InstallBindings()
        {

            Container.BindInstance<GameContext>(Contexts.sharedInstance.game);
            Container.BindInstance<InputContext>(Contexts.sharedInstance.input);
            
            Container.BindInterfacesAndSelfTo<FeaturesController>().AsSingle();

            InstallGameServices();
            InstallViews();
        }

        private void InstallViews()
        {
            _boardView = Container.InstantiatePrefab(BoardViewPrefab, BoardCanvas);
            Container.BindInstance<BoardView>(_boardView.GetComponent<BoardView>());
        }


        private void InstallGameServices()
        {
            BoardService boardService = Container.Instantiate<BoardService>();
            Container.BindInstance<BoardService>(boardService);

        }
    }
}