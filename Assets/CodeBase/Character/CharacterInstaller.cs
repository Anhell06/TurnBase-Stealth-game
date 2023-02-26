using CodeBase.Character.Visability;
using UnityEngine;
using Zenject;

namespace CodeBase.Character
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField]
        private CahracterSetting _setting;

        public override void InstallBindings()
        {
            Container.Bind<CharacterModel>().AsSingle().NonLazy();
            Container.BindCharacterVisability(_setting.VisabilityFilter, _setting.VisabilityRange);
        }
    }
}
