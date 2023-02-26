using CodeBase.HexLib;
using UnityEngine;
using Zenject;

namespace CodeBase.Core.Grid
{
    public class GridInstaller : MonoInstaller
    {
        [SerializeField]
        private LayoutSettings _layoutSettings;

        public override void InstallBindings()
        {
            Container.Bind<ILayout>()
                .To<Layout>()
                .AsSingle()
                .WithArguments(OrentationType.Flat, _layoutSettings.Size, _layoutSettings.Origin)
                .NonLazy();

            Container.Bind<IHexGrid>().To<HexGrid>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}