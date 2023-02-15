using Services.StateMachineGardener;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine
{
    public abstract class State : MonoBehaviour, ISwitcherState
    {
        protected StateMachineGardener StateMachine;
        protected Animator Animator;

        public void EnterBehavior() =>
            enabled = true;

        public void ExitBehavior() =>
            enabled = false;

        public void Init(StateMachineGardener stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }
    }
}