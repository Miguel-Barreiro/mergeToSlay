using MergeToSlay.Core;
using MergeToSlay.Data;
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

        [SerializeField]
        private CardList CardListData;

        [SerializeField]
        private EnemyData DebugEnemyData;
        
        [SerializeField]
        private CardData DebugCardData;
        
        private GameObject _boardView;
        

        public override void InstallBindings()
        {

            Container.BindInstance<GameContext>(Contexts.sharedInstance.game);
            Container.BindInstance<InputContext>(Contexts.sharedInstance.input);
            
            Container.BindInterfacesAndSelfTo<FeaturesController>().AsSingle();

            InstallData();
            InstallGameServices();
            InstallViews();
            
            
            // this if for debug
            Container.BindInstance<CardData>(DebugCardData);
            Container.BindInstance<EnemyData>(DebugEnemyData);

        }

        private void InstallData()
        {
            Container.BindInstance<CardList>(CardListData);
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

            GridObjectService gridObjectService = Container.Instantiate<GridObjectService>();
            Container.BindInstance<GridObjectService>(gridObjectService);

        }
    }
}