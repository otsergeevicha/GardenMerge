using System.Collections;
using System.Linq;
using Field.Plants;
using Infrastructure.Factory;
using UnityEngine;
using UnityEngine.AI;

namespace Field.GardenObserver
{
    public class Gardener : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private OperatorFactory _factory;

        private bool _isWork;
        private Coroutine _coroutine;
        private Vegetation _plant;

        private void Start()
        {
            _isWork = true;
            _coroutine = StartCoroutine(CuttingLeaves());
        }

        private void OnDisable()
        {
            _isWork = false;

            if(_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private Vector3 SelectedTarget()
        {
            if(_factory.GetAllPlants() != null)
                foreach(var plant in _factory.GetAllPlants()
                            .Where(plant =>
                                plant.IsRipe()))
                    return plant.transform.position;

            return Vector3.zero;
        }

        private IEnumerator CuttingLeaves()
        {
            var waitForFixedUpdate = new WaitForFixedUpdate();

            while(_isWork)
            {
                _agent.SetDestination(SelectedTarget());
                
                if(_agent.isPathStale) 
                    _agent.ResetPath();
                yield return waitForFixedUpdate;
            }
        }
    }
}