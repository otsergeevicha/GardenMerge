using Infrastructure.SaveLoadLogic;
using Services.StateMachine;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine
{
    public abstract class State : MonoBehaviour, ISwitcherState
    {
        protected StateMachineGardener StateMachine;
        protected Animator Animator;
        protected SaveLoad SaveLoad;

        public void EnterBehavior() =>
            enabled = true;

        public void ExitBehavior() =>
            enabled = false;

        public void Init(StateMachineGardener stateMachine, Animator animator, SaveLoad saveLoad)
        {
            StateMachine = stateMachine;
            Animator = animator;
            SaveLoad = saveLoad;
        }
    }
}