using System.Collections;
using UnityEngine;

namespace Services.Collect
{
    public interface IServiceCollect
    {
        public static IEnumerator WorkWithPlants(float requiredTime)
        {
            bool isWork = true;
            
            while(isWork)
            {
                yield return new WaitForSeconds(requiredTime);
                isWork = false;
            }
        }
    }
}