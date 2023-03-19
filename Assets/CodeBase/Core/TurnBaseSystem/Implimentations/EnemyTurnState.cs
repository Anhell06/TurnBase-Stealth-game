using CodeBase.Core.Infrastructure.TurnBaseSystem.Abstrations;

namespace CodeBase.Core.Infrastructure.TurnBaseSystem.Implimentations
{
    internal class EnemyTurnState : IState
    {
        private IStateMachine _turnStateMachine;

        public EnemyTurnState(IStateMachine turnStateMachine) => _turnStateMachine = turnStateMachine;

        public void Enter()
        {
            // throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            // throw new System.NotImplementedException();
        }
    }
}