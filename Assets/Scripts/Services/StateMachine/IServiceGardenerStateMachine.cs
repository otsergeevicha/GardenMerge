using Field.GardenerLogic.StateMachine.States;

namespace Services.StateMachine
{
    public interface IServiceGardenerStateMachine : IService
    {
        public void Enter(GardenerState currentState);
        public void Exit(GardenerState currentState);
    }
}