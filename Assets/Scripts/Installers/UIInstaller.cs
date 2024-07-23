using UnityEngine;
using View;
using Zenject;

namespace Installers
{
    public class UIInstaller: MonoInstaller<UIInstaller>
    {
        [SerializeField] 
        private HealthView _healthPrefab;
        
        [SerializeField] 
        private HealthBarView _healthBar;

        [Space, SerializeField] 
        private MenuView _menuView;
        
        public override void InstallBindings()
        {
            InstallHealthView();
            InstallMenu();
        }

        private void InstallHealthView()
        {
            Container
                .BindMemoryPool<HealthView, HealthView.Pool>()
                .FromNewComponentOnNewPrefab(_healthPrefab)
                .NonLazy();
            
            Container
                .Bind<IMemoryPool<Transform, HealthView>>()
                .To<HealthView.Pool>()
                .FromResolve();

            Container
                .Bind<HealthBarView>()
                .FromInstance(_healthBar)
                .AsSingle()
                .NonLazy();
        }

        private void InstallMenu()
        {
            Container
                .Bind<MenuView>()
                .FromInstance(_menuView)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<MenuPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}