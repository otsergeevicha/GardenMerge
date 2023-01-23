using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Field.GardenObserver
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(GardenerBaseTargets))]
    public class Gardener : MonoBehaviour
    {
        private WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();
        private GardenerBaseTargets _baseTargets;
        
        private NavMeshAgent _agent;
        private Coroutine _coroutine;
        private Vector3 _currentTarget;
        
        private bool _isWork = true;
        private bool _isFirstStep = true;

        private void OnEnable()
        {
            _baseTargets = GetComponent<GardenerBaseTargets>();
            _agent = GetComponent<NavMeshAgent>();
            
            _baseTargets.OnFirstStep += MakeFirstStep;
        }

        private void OnDisable()
        {
            _isWork = false;
            _baseTargets.OnFirstStep -= MakeFirstStep;

            if(_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private void MakeFirstStep() => 
            _coroutine = StartCoroutine(CuttingLeaves());

        private IEnumerator CuttingLeaves()
        {
            while(_isWork)
            {
                if(_isFirstStep)
                {
                    _isFirstStep = false;
                    _agent.SetDestination(_baseTargets.TryGetTarget());
                }

                _agent.SetDestination(_currentTarget);

                if(transform.position == _currentTarget)
                    _currentTarget = _baseTargets.TryGetTarget();

                yield return _waitForFixedUpdate;
            }
        }
    }
}