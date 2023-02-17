using Field.GardenerLogic;
using Field.Plants.Seeds;
using Field.Tiles.Move;
using UnityEngine;

namespace Services.Buttons
{
    public class ButtonSeed : MonoBehaviour
    {
        [SerializeField] private TileMerge[] _tileMerges;
        
        [SerializeField] private Gardener _gardener;
        [SerializeField] private SeedBronze _seed;
        
        [SerializeField] private SaveLoad _saveLoad;
        
        private int _currentPrice = 5;

        private void Start() => 
            _currentPrice = _saveLoad.ReadPriceSeed();

        public void Buy()
        {
            if (_gardener.CheckAmountMoney(_currentPrice) && TryFreePlace())
            {
                _currentPrice++;
                _saveLoad.SaveNewPriceSeed(_currentPrice);
                _gardener.BuySeed(_currentPrice);
            }
        }

        private bool TryFreePlace()
        {
            foreach (TileMerge tile in _tileMerges)
            {
                if (!Physics.Raycast(tile.transform.position, Vector3.up, 50f))
                {
                    Instantiate(_seed, tile.transform.position, Quaternion.identity);
                    return true;
                }
            }

            return false;
        }
    }
}