using CodeBase.HexLib;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Inject]
    public LayoutSettings LayoutSettings { get; private set; }

    public override void InstallBindings()
    {
        Container.Bind<ILayout>().To<Layout>().AsSingle().WithArguments(OrentationType.Flat, LayoutSettings.Size, Vector2.zero).NonLazy();
    }
}
