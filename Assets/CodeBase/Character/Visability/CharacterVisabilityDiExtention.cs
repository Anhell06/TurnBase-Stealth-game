using CodeBase.Core.Grid;
using System.Collections.Generic;
using Zenject;

namespace CodeBase.Character.Visability
{
    public static class CharacterVisabilityDiExtention
    {
        public static void BindCharacterVisability(this DiContainer container, List<TileType> visabilityFilter, int visabilityRange)
        {
            container.Bind<ICharacterVisabilityController>().To<CharacterVisabilityController>().AsSingle().NonLazy();
            container.Bind<CharacterVisabilityView>().FromComponentInHierarchy().AsSingle();
            container.Bind<CharacterVisabilityModel>().AsSingle().WithArguments(visabilityFilter, visabilityRange);
        }
    }
}
