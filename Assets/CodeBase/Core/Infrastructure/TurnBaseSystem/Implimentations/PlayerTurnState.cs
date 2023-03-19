using CodeBase.Core.Infrastructure.TurnBaseSystem.Abstrations;

namespace CodeBase.Core.Infrastructure.TurnBaseSystem.Implimentations
{
    internal class PlayerTurnState : IState, IPlayerState
    {
        private readonly IStateMachine _sm;

        public PlayerTurnState(IStateMachine sm) => _sm = sm;

        public void EndState()
        { }

        public void EndTurn() => _sm.ChangeState(typeof(EnemyTurnState));

        public void Enter() => _sm.Data.IncrementTurn();

        public void Exit()
        { }

        public void Update()
        { }
    }
}