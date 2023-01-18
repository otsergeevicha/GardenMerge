using UnityEngine;

namespace Field.Vegetation.Seeds
{
    public abstract class Seed : Vegetation
    {
        private Vector3 _firstPosition;

        public abstract int GetLevel();

        public Vector3 ReadFirstPosition() =>
            _firstPosition;

        public void RecordFirstPosition(Vector3 firstPosition) =>
            _firstPosition = firstPosition;

        public void InitPosition(Vector3 newPosition) =>
            transform.position = newPosition;
    }
}