using Field.GardenerLogic.StateMachine.States;
using Field.Plants;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine.ConditionsStates
{
    public abstract class Transition : MonoBehaviour
    {
        private bool _isCollect;

        protected bool IsCollect =>
            _isCollect;

        public abstract GardenerState GetNextState();

        private void OnTriggerStay(Collider collision)
        {
            if (collision.TryGetComponent(out Vegetation vegetation))
            {
                if (vegetation.IsRipe())
                    _isCollect = true;

                _isCollect = false;
            }
        }
    }
}