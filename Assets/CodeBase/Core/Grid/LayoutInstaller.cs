using CodeBase.HexLib;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class LayoutInstaller : MonoInstaller
{
    public LayoutSettings _layoutSettings;

    public override void InstallBindings()
    {
        Container.Bind<ILayout>()
            .To<Layout>()
            .AsSingle()
            .WithArguments(OrentationType.Flat, _layoutSettings.Size, _layoutSettings.Origin)
            .NonLazy();
    }
}
