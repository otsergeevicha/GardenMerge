using DG.Tweening;
using Field.GardenObserver;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine.States
{
    public class StateWalk : GardenerState
    {
        [SerializeField] private float _speed;
        [SerializeField] private OperatorTargets _operator;

        private Rigidbody _rigidbody;
                
        private void Start() => 
            Move();

        private void Move() =>
            _rigidbody.DOMove(_operator.TryGetTarget(), _speed * Time.deltaTime)
                .SetEase(Ease.Linear);
    }
}