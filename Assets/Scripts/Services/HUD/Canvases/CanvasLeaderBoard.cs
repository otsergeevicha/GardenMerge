using Agava.YandexGames;
using Services.HUD.Buttons;
using Services.HUD.Canvases.Leaderboard;
using UnityEngine;

namespace Services.HUD.Canvases
{
    enum RankPosition
    {
        FirstPlace = 1,
        TwoPlace = 2,
        ThreePlace = 3
    }
    
    public class CanvasLeaderBoard : MonoBehaviour
    {
        [SerializeField] private ButtonHolderMenu _buttonHolderMenu;
        [SerializeField] private PlayerRank[] _playerRanks;

        private const string LeaderboardName = "Leaderboard";
        private const string Anonymous = "Anonymous";

        private readonly int _topPlayersCount = 4;
        private readonly int _competingPlayersCount = 3;

        public void ToggleVisible(bool flag)
        {
            _buttonHolderMenu.gameObject.SetActive(flag);

            if (flag == false)
                Show();

            gameObject.SetActive(!flag);
        }

        private void Show()
        {
            ShowPlayer();
            ShowOtherPlayers();
        }

        private void ShowPlayer()
        {
            Agava.YandexGames.Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
                { if (result != null) SetPlace(result); });
        }

        private void ShowOtherPlayers()
        {
            Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, (result) =>
            {
                foreach (LeaderboardEntryResponse entry in result.entries) 
                    SetPlace(entry);
                
            }, null, _topPlayersCount, _competingPlayersCount);
        }


        private string NameCorrector(string name)
        {
            if (string.IsNullOrEmpty(name))
                name = Anonymous;

            return name;
        }

        private void SetPlace(LeaderboardEntryResponse result)
        {
            switch (result.rank)
            {
                case (int)RankPosition.FirstPlace:
                    _playerRanks[0].Init(result.rank, 
                        NameCorrector(result.player.publicName), result.score);
                    break;
                case (int)RankPosition.TwoPlace:
                    _playerRanks[1].Init(result.rank, 
                        NameCorrector(result.player.publicName), result.score);
                    break;
                case (int)RankPosition.ThreePlace:
                    _playerRanks[2].Init(result.rank, 
                        NameCorrector(result.player.publicName), result.score);
                    break;
                case > (int)RankPosition.ThreePlace:
                    _playerRanks[3].Init(result.rank, 
                        NameCorrector(result.player.publicName), result.score);
                    break;
            }
        }
    }
}