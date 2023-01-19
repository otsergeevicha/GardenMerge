using System.Collections;
using System.Linq;
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
            while(_isWork)
            {
                _agent.Move(SelectedTarget());
                _agent.ResetPath();
                yield return new WaitForFixedUpdate();
            }
        }
    }
}