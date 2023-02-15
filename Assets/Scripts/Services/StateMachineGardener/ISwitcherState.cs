using Field.GardenerLogic.StateMachine;
using UnityEngine;

namespace Services.StateMachineGardener
{
    public interface ISwitcherState
    {
        public void EnterBehavior();
        public void ExitBehavior();
        public void Init(Field.GardenerLogic.StateMachine.StateMachineGardener stateMachineGardener, Animator animator);
    }
}