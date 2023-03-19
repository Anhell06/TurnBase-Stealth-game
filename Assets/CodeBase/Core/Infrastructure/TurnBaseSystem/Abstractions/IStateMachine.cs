using System;

namespace CodeBase.Core.Infrastructure.TurnBaseSystem.Abstrations
{
    public interface IStateMachine
    {
        event Action OnStateChanged;
        TurnBaseData Data { get; }
        void ChangeState(Type stateType);
    }
}