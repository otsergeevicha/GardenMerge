using Agava.YandexGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases.LeaderboardFolder.PlayerRank;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] private CanvasMenu _canvasMenu;

        [SerializeField] private CanvasAuthorization _canvasAuthorization;

        [SerializeField] private Image _imageBgL;
        [SerializeField] private Image _imageBgR;

        [SerializeField] private OnePlayerRank _onePlayer;
        [SerializeField] private TwoPlayerRank _twoPlayer;
        [SerializeField] private ThreePlayerRank _threePlayer;
        [SerializeField] private FourPlayerRank _fourPlayer;

        private const string LeaderboardMerge = "LeaderboardMerge";
        private const string LeaderboardCollect = "LeaderboardCollect";
        private const string Anonymous = "Anonymous";

        private readonly int _topPlayersCount = 3;

        private void Start() => 
            SetScore();

        private void OnDisable() => 
            SetScore();

        public void OnVisible()
        {
            SetScore();
            OnMergeBoard();
        }
        
        private void SetScore()
        {
            if (PlayerAccount.IsAuthorized)
            {
                Leaderboard.SetScore(LeaderboardMerge, _saveLoad.ReadScoreMerge());
                Leaderboard.SetScore(LeaderboardCollect, _saveLoad.ReadScoreCollect());
            }
        }

        public void OnMergeBoard()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:Leaderboard:MergeBoard");
            
            _imageBgL.enabled = true;
            _imageBgR.enabled = false;

            if (PlayerAccount.IsAuthorized)
            {
                SetData(LeaderboardMerge);
                gameObject.SetActive(true);
            }

            if (PlayerAccount.IsAuthorized == false)
                _canvasAuthorization.OnVisible();
        }

        public void OnCollectBoard()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:Leaderboard:CollectBoard");
            
            _imageBgL.enabled = false;
            _imageBgR.enabled = true;

            if (PlayerAccount.IsAuthorized)
            {
                SetData(LeaderboardCollect);
                gameObject.SetActive(true);
            }
            
            if (PlayerAccount.IsAuthorized == false) 
                _canvasAuthorization.OnVisible();
        }

        public void OffVisible()
        {
            _canvasMenu.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        private void SetData(string nameBoard)
        {
            PlayerPlace(nameBoard);
            OtherPlayerPlace(nameBoard);

            ReRenderCanvas();
        }

        private void PlayerPlace(string nameBoard)
        {
            Leaderboard.GetPlayerEntry(nameBoard, (player) =>
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

        private void OtherPlayerPlace(string nameBoard)
        {
            Leaderboard.GetEntries(nameBoard, (arrayLeaderboardPlayers) =>
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

        private void ReRenderCanvas()
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}