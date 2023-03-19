using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Core.Infrastructure.TurnBaseSystem.Abstrations
{
    internal abstract class BaseMBStateMachine : MonoBehaviour, IStateMachine
    {
        public TurnBaseData Data { get; protected set; }
        public event Action OnStateChanged;

        protected Dictionary<Type, IState> _states;

        public abstract IState GetInitialState();

        public virtual void ChangeState(Type stateType)
        {
            Data.CurrentState?.Exit();

            Data.CurrentState = _states.TryGetValue(stateType, out var newState)
                ? newState
                : throw new KeyNotFoundException($"The state with the type {stateType} does not exist or it is not added to the list of available states");

            OnStateChanged?.Invoke();

            Data.CurrentState.Enter();
        }

        public virtual void Start()
        {
            Data = new(GetInitialState());
            ChangeState(Data.CurrentState.GetType());
        }

        public virtual void Update()
            => Data?.CurrentState.Update();
    }
}