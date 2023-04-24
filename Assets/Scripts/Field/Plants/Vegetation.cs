using UnityEngine;

namespace Field.Plants
{
    public abstract class Vegetation : MonoBehaviour
    {
        private Vector3 _firstPosition;

        public abstract void Wipe();
        
        public abstract bool IsRipe();

        public abstract int GetLevel();
        public abstract float GetTimeCollect();
        public abstract float GetFloweringPeriod();

        public Vector3 ReadFirstPosition() =>
            _firstPosition;

        public void RecordFirstPosition(Vector3 firstPosition) =>
            _firstPosition = firstPosition;

        public void InitPosition(Vector3 newPosition) =>
            transform.position = newPosition;

        public abstract void Collect();

        public abstract int PriceCollect();
    }
}