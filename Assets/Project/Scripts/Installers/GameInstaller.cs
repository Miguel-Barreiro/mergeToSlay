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
        private GameObject PathViewPrefab;

        [SerializeField]
        private GameObject BoardViewPrefab;

        [SerializeField]
        private GameObject BattleViewPrefab;
        
        [SerializeField]
        private GameConfigData GameConfigData;

        [SerializeField]
        private EnemyData DebugEnemyData;
        
        [SerializeField]
        private CardData DebugCardData;
        
        
        private GameObject _pathView;
        
        private GameObject _boardView;
        private GameObject _battleView;


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
            _pathView = BindView<PathView>(PathViewPrefab, RootView.PathRoot);
            _boardView = BindView<BoardView>(BoardViewPrefab, RootView.BoardRoot);
            _battleView = BindView<BattleView>(BattleViewPrefab, RootView.BattleRoot);
        }

        private GameObject BindView<T>(GameObject prefab, RectTransform root)
        {
            GameObject view = Container.InstantiatePrefab(prefab, root);
            Container.BindInstance(view.GetComponent<T>());

            return view;
        }


        private void InstallGameServices()
        {
            Container.BindInstance<PathService>(Container.Instantiate<PathService>());
            Container.BindInstance<GridObjectService>(Container.Instantiate<GridObjectService>());
            Container.BindInstance<BoardService>(Container.Instantiate<BoardService>());
            Container.BindInstance<CombatService>(Container.Instantiate<CombatService>());
            
        }
    }
}