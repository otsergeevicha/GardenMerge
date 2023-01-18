using UnityEngine;

namespace Services.Move
{
    public interface IServiceDragAndDrop
    {
        public void Up();
        public void Drag(Vector3 newPosition);
        public void Drop();
    }
}