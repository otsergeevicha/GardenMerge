using System.Collections.Generic;
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

        private Queue<Vegetation> _queueSpawnSeeds = new Queue<Vegetation>();
        private bool _firstInitQueue = false;

        private const int LevelSpawn = 1;

        private void OnEnable() =>
            _checkingChanceSpawn.OnAllowed += OnVisibleNewSeed;

        private void OnDisable() =>
            _checkingChanceSpawn.OnAllowed -= OnVisibleNewSeed;

        private void OnVisibleNewSeed(Vector3 spawnPoint)
        {
            if(_firstInitQueue == false) 
                FirstInitQueue();

            var checkVar = _queueSpawnSeeds.Peek();
            
            if(checkVar.isActiveAndEnabled == false)
            {
                _queueSpawnSeeds.Enqueue(_queueSpawnSeeds.Peek());
                var currentSeed = _queueSpawnSeeds.Dequeue();
                currentSeed.gameObject.SetActive(true);
                currentSeed.InitPosition(spawnPoint);
            }
        }

        private void FirstInitQueue()
        {
            foreach(Vegetation vegetation in _factory.GetAllPlants())
            {
                if(vegetation.GetLevel() == LevelSpawn)
                {
                    _queueSpawnSeeds.Enqueue(vegetation);
                }
            }

            _firstInitQueue = true;
        }
    }
}