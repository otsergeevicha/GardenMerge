using UnityEngine;

namespace Field.Tiles.Move
{
    public class TileMerge : Tile
    {
        public Vector3 GetPosition() => 
            transform.position;
    }
}