using System;

namespace CodeBase.Core.Infrastructure.TurnBaseSystem.Abstrations
{
    [Serializable]
    public class TurnBaseData
    {
        public int TurnNumder { get; private set; }
        internal IState CurrentState { get; set; }

        public event Action<int> OnTurnIncreasing;

        internal TurnBaseData(IState initState)
        {
            TurnNumder = 0;
            CurrentState = initState;
        }

        public void IncrementTurn()
        {
            TurnNumder++;
            OnTurnIncreasing?.Invoke(TurnNumder);
        }
    }
}