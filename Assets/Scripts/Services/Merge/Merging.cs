using System;
using Field.Plants;
using Infrastructure.Factory;
using Services.HUD.Canvases.Training;
using Services.Sound;
using UnityEngine;

namespace Services.Merge
{
    public class Merging : MonoBehaviour
    {
        [SerializeField] private OperatorFactory _plantsFactory;
        [SerializeField] private FXOperator _fxOperator;
        
        [SerializeField] private VibrationService _vibrationService;

        [SerializeField] private TrainingScenario _trainingScenario;
        private int _counterMerge;

        public event Action<int> Merged;
        
        public void Merge(Vegetation vegetationCollision, Vegetation vegetation)
        {
            if(vegetationCollision.GetLevel() == vegetation.GetLevel())
            {

                Vector3 placeMerge = vegetationCollision.transform.position;
                int levelMerge = vegetationCollision.GetLevel();
                levelMerge++;

                vegetationCollision.gameObject.SetActive(false);
                vegetation.gameObject.SetActive(false);
   
                foreach(var plant in _plantsFactory.GetAllPlants())
                {
                    if(plant.GetLevel() == levelMerge && plant.gameObject.activeInHierarchy == false)
                    {
                        plant.gameObject.transform.position = placeMerge;
                        plant.gameObject.SetActive(true);
                        _fxOperator.PlaySoundMerge();
                        _vibrationService.OnTick();
                        Merged?.Invoke(levelMerge);

                        if (_counterMerge == 0)
                        {
                            _trainingScenario.CompletedThreeStep();
                            _counterMerge++;
                        }

                        return;
                    }
                }
            }

            if(vegetationCollision.GetLevel() != vegetation.GetLevel())
            {
                Vector3 tempVarPoint = vegetationCollision.transform.position;
                vegetationCollision.InitPosition(vegetation.ReadFirstPosition());
                vegetation.InitPosition(tempVarPoint);
            }
        }
    }
}