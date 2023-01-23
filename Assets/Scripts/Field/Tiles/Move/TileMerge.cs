using System.Linq;
using Field.Plants;
using Field.Tiles.SpawnSeedLogic;
using Infrastructure.Factory;
using UnityEngine;

namespace Field.Tiles.Move
{
    public class TileMerge : Tile
    {
        [SerializeField] private PlantsFactory _factory;
        [SerializeField] private CheckingChanceSpawn _checkingChanceSpawn;
        
        private const int LevelSpawn = 1;

        private void OnEnable() => 
            _checkingChanceSpawn.OnAllowed += OnVisibleNewSeed;

        private void OnDisable() =>
            _checkingChanceSpawn.OnAllowed -= OnVisibleNewSeed;

        private void OnVisibleNewSeed(Vector3 spawnPoint)
        {
            Vegetation vegetation = _factory.GetAllPlants()
                .FirstOrDefault(plant => 
                    plant.GetLevel() == LevelSpawn);

            vegetation.gameObject.SetActive(true);
            vegetation.InitPosition(spawnPoint);
        }
    }
}