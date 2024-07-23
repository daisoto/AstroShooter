using Common;
using UnityEngine;
using View;
using Zenject;

namespace Field
{
    public class GameFieldInstaller: MonoInstaller<GameFieldInstaller>
    {
        [SerializeField] 
        private GameField _gameField;

        [SerializeField] 
        private CollisionProcessor _collisionProcessor;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<GameField>()
                .FromInstance(_gameField)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<FieldDamageReceiver>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<CollisionProcessor>()
                .FromInstance(_collisionProcessor)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<HealthBarPresenter>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<FieldResetter>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<HealthComponent>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<FieldDeathProcessor>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<LifeController>()
                .AsSingle()
                .NonLazy();
        }
    }
}