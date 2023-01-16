using UnityEngine;

namespace Services.Input
{
    public interface IInputService
    {
        Vector2 Axis{get;}
    }

    public class InputService : IInputService
    {
        public Vector2 Axis => new Vector2();
    }
}