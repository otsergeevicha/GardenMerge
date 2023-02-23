using Field.Plants;
using Infrastructure.Factory;
using UnityEngine;

namespace Services.Merge
{
    public class Merging : MonoBehaviour

    {
        [SerializeField] private OperatorFactory _plantsFactory;

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