using UnityEngine;
using Zenject;

public class CharacterInstaller : MonoInstaller
{
    [SerializeField]
    private CahracterSetting _setting;

    public override void InstallBindings()
    {
        Container.Bind<CharacterModel>().AsSingle().NonLazy();
        Container.Bind<CharacterVisabilityController>().AsSingle().NonLazy();
        Container.Bind<CharacterVisabilityView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CharacterVisabilityModel>().AsSingle().WithArguments(_setting.VisabilityFilter, _setting.VisabilityRange);
    }
}
