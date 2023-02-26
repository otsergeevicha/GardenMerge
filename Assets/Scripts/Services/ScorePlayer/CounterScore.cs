using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using Services.Merge;
using UnityEngine;

namespace Services.ScorePlayer
{
    public class CounterScore : MonoBehaviour
    {
        [SerializeField] private Merging _merging;
        [SerializeField] private SaveLoad _saveLoad;

        private const string LeaderboardName = "Leaderboard";
        
        private void OnEnable() => 
            _merging.Merged += SavePoint;

        private void OnDisable() => 
            _merging.Merged -= SavePoint;

        private void SavePoint(int amountPoints)
        {
            _saveLoad.SavePoint(amountPoints);
            
            Leaderboard.SetScore(LeaderboardName, _saveLoad.ReadScore());
        }
    }
}