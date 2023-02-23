using DG.Tweening;
using Field.Plants;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine
{
    public class MovementState : State
    {
        private const string IsRun = "IsRun";

        private readonly float _rateStepGardener = .5f;
        private readonly float _stoppingDistance = 1.35f;

        private Vegetation _currentVegetation;
        private float _distance;

        public void InitVegetation(Vegetation vegetation) =>
            _currentVegetation = vegetation;

        private void FixedUpdate()
        {
            if (isActiveAndEnabled == false)
            {
                Animator.SetBool(IsRun, false);
                return;
            }

            Animator.SetBool(IsRun, true);
            Move();
        }

        private void Move()
        {
            Vector3 ourPosition = transform.position;
            Vector3 positionVegetation = _currentVegetation.transform.position;

            transform.position = new Vector3(MovementAxis(ourPosition.x, positionVegetation.x),
                MovementAxis(ourPosition.y, positionVegetation.y),
                MovementAxis(ourPosition.z, positionVegetation.z));

            transform.DOLookAt(positionVegetation, .01f);

            if (_currentVegetation.IsRipe() == false)
            {
                Animator.SetBool(IsRun, false);
                StateMachine.EnterBehavior<SearchTargetState>();
            }

            _distance = Vector3.Distance(ourPosition, positionVegetation);

            if (_stoppingDistance >= _distance)
            {
                Animator.SetBool(IsRun, false);
                StateMachine.EnterBehavior<CollectState>();
            }
        }

        private float MovementAxis(float ourPosition, float targetPosition) =>
            Mathf.Lerp(ourPosition, targetPosition, _rateStepGardener * Time.deltaTime);
    }
}