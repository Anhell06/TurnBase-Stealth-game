namespace CodeBase.Core.TurnBaseSystem
{
    public interface ITurnBaseController
    {
        void RunCycle();
        void Subscribe(Phase phase, PhaseEvent phaseEvent);
        void Unsubscribe(Phase phase, PhaseEvent phaseEvent);
    }
}