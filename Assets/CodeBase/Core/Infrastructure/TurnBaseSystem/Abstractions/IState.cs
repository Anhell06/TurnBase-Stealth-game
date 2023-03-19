namespace CodeBase.Core.Infrastructure.TurnBaseSystem.Abstrations
{
    internal interface IState
    {
        void Enter();
        void Update();
        void Exit();
    }
}
