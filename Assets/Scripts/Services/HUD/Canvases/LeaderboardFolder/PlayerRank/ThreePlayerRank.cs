using TMPro;
using UnityEngine;

namespace Services.HUD.Canvases.LeaderboardFolder.PlayerRank
{
    public class ThreePlayerRank : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nickName;
        [SerializeField] private TMP_Text _score;

        public void Init(string nickName, int score)
        {
            _nickName.text = nickName;
            _score.text = score.ToString();
        }
    }
}