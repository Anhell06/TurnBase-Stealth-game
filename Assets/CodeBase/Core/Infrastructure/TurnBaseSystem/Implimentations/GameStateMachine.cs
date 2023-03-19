using CodeBase.Core.Infrastructure.TurnBaseSystem.Abstrations;

namespace CodeBase.Core.Infrastructure.TurnBaseSystem.Implimentations
{
    internal class GameStateMachine : BaseMBStateMachine
    {
        private void Awake()
        {
            _states = new()
            {
                { typeof(PlayerTurnState), new PlayerTurnState(this) },
                { typeof(EnemyTurnState), new EnemyTurnState(this) }
            };
        }

        public override IState GetInitialState() => _states[typeof(PlayerTurnState)];
    }
}
