using CodeBase.Character.Visability;
using CodeBase.Core.HUD;
using CodeBase.Core.Infrastructure.TurnBaseSystem.Abstrations;
using CodeBase.Core.Infrastructure.TurnBaseSystem.Implimentations;
using UnityEngine;
using Zenject;

namespace CodeBase.Character
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private CahracterSetting _setting;

        public override void InstallBindings()
        {
            Container.Bind<CharacterModel>().AsSingle().NonLazy();
            Container.BindCharacterVisability(_setting.VisabilityFilter, _setting.VisabilityRange);
            Container.Bind<HudController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IStateMachine>().To<GameStateMachine>().FromComponentInHierarchy().AsSingle();
        }
    }
}
