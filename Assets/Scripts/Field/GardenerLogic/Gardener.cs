using Field.GardenObserver;
using UnityEngine;
using UnityEngine.AI;

namespace Field.GardenerLogic
{
    public class Gardener : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private OperatorTargets _targets;

        private void Update() => 
            TryGetPath();

        private void TryGetPath()
        {
            Vector3 currentPath = _targets.TryGetTarget();

            if (transform.position != currentPath) 
                _agent.SetDestination(currentPath);
        }
    }
}