using Services.StateMachine;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine.States
{
    public abstract class GardenerState : MonoBehaviour, IServiceGardenerStateMachine
    {
        public void Enter(GardenerState currentState)
        {
            if (currentState != null) currentState.enabled = true;
        }

        public void Exit(GardenerState currentState)
        {
            if (currentState != null) currentState.enabled = false;
        }
    }
}