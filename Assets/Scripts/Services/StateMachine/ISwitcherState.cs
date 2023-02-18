using Field.GardenerLogic.StateMachine;
using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.StateMachine
{
    public interface ISwitcherState
    {
        public void EnterBehavior();
        public void ExitBehavior();
        public void Init(StateMachineGardener stateMachineGardener, Animator animator, SaveLoad saveLoad);
    }
}