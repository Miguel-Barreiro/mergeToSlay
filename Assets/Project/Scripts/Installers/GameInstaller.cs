using MergeToStay.Core;
using MergeToStay.Data;
using MergeToStay.MonoBehaviours;
using MergeToStay.MonoBehaviours.Combat;
using MergeToStay.Services;
using UnityEngine;
using Zenject;

namespace MergeToStay.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private RootView RootView;

        [SerializeField]
        private GameObject BoardViewPrefab;

        [SerializeField]
        private GameConfigData GameConfigData;

        [SerializeField]
        private EnemyData DebugEnemyData;
        
        [SerializeField]
        private CardData DebugCardData;
        
        
        
        private GameObject _boardView;
        

        public override void InstallBindings()
        {

            Container.BindInstance<Contexts>(Contexts.sharedInstance);
            
            Container.BindInstance<RootView>(RootView);
            PrefabFactoryPool prefabFactoryPool = Container.Instantiate<PrefabFactoryPool>();
            Container.BindInstance<PrefabFactoryPool>(prefabFactoryPool);

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
            Container.BindInstance<CardList>(GameConfigData.CardListData);
            Container.BindInstance<GameConfigData>(GameConfigData);
        }

        private void InstallViews()
        {
            _boardView = Container.InstantiatePrefab(BoardViewPrefab, RootView.BoardRoot);
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