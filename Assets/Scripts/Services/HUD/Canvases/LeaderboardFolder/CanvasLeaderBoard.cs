using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases.LeaderboardFolder.PlayerRank;
using UnityEngine;

namespace Services.HUD.Canvases.LeaderboardFolder
{
    enum RankPosition
    {
        FirstPlace = 1,
        TwoPlace = 2,
        ThreePlace = 3
    }

    public class CanvasLeaderBoard : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;
        
        [SerializeField] private OnePlayerRank _onePlayer;
        [SerializeField] private TwoPlayerRank _twoPlayer;
        [SerializeField] private ThreePlayerRank _threePlayer;
        [SerializeField] private FourPlayerRank _fourPlayer;
        
        private const string LeaderboardName = "Leaderboard";
        private const string Anonymous = "Anonymous";
        
        private readonly int _topPlayersCount = 4;

        private void OnEnable()
        {
            if (PlayerAccount.IsAuthorized) 
                Leaderboard.SetScore(LeaderboardName, _saveLoad.ReadScore());
        }

        public void OnVisible()
        {
            if (PlayerAccount.IsAuthorized) 
                Leaderboard.SetScore(LeaderboardName, _saveLoad.ReadScore());
            
            if (PlayerAccount.IsAuthorized) 
                PlayerAccount.RequestPersonalProfileDataPermission(OnSuccessCallback);

            if (PlayerAccount.IsAuthorized == false)
            {
                SetData();
                gameObject.SetActive(true);
                PlayerAccount.Authorize();
            }
        }

        public void OffVisible() => 
            gameObject.SetActive(false);

        private void OnSuccessCallback()
        {
            SetData();
            gameObject.SetActive(true);
        }

        private void SetData()
        {
            PlayerPlace();
            OtherPlayerPlace();
        }

        private void PlayerPlace()
        {
            Leaderboard.GetPlayerEntry(LeaderboardName, (player) =>
            {
                if (player != null)
                    SetPlace(player);
            });
        }

        private void SetPlace(LeaderboardEntryResponse member)
        {
            switch (member.rank)
            {
                case (int)RankPosition.FirstPlace:
                    _onePlayer.Init(NameCorrector(member.player.publicName), member.score);
                    break;
                case (int)RankPosition.TwoPlace:
                    _twoPlayer.Init(NameCorrector(member.player.publicName), member.score);
                    break;
                case (int)RankPosition.ThreePlace:
                    _threePlayer.Init(NameCorrector(member.player.publicName), member.score);
                    break;
                case > (int)RankPosition.ThreePlace:
                    _fourPlayer.Init(member.rank,
                        NameCorrector(member.player.publicName), member.score);
                    break;
            }
        }

        private void OtherPlayerPlace()
        {
            Leaderboard.GetEntries(LeaderboardName, (arrayLeaderboardPlayers) =>
            {
                foreach (LeaderboardEntryResponse otherPlayer in arrayLeaderboardPlayers.entries) 
                    SetPlace(otherPlayer);
            }, null, _topPlayersCount, 0);
        }

        private string NameCorrector(string name)
        {
            if (string.IsNullOrEmpty(name))
                name = Anonymous;

            return name;
        }
    }
}