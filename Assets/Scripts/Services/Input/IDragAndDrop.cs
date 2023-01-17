using UnityEngine;

namespace Services.Input
{
    public interface IDragAndDrop
    {
        public void Up();
        public void Drag(Vector3 newPosition);
        public void Drop();
    }
}