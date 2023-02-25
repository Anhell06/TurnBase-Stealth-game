using CodeBase.HexLib;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class LayoutInstaller : MonoInstaller
{
    [SerializeField]
    private LayoutSettings _layoutSettings;
    public HexGrid _grid;

    public override void InstallBindings()
    {
        Container.Bind<ILayout>()
            .To<Layout>()
            .AsSingle()
            .WithArguments(OrentationType.Flat, _layoutSettings.Size, _layoutSettings.Origin)
            .NonLazy();

        Container.Bind<HexGrid>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}
