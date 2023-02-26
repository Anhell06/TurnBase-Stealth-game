using System;

namespace CodeBase.Core.TurnBaseSystem
{
    [Serializable]
    internal class TurnBaseModel
    {
        public int TurnNumder;
        public Phase CurrentPhase;

        public TurnBaseModel(int turnNumder, Phase currentPhase)
        {
            TurnNumder = turnNumder;
            CurrentPhase = currentPhase;
        }
    }
}