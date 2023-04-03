using TMPro;
using UnityEngine;

namespace Services.HUD.Canvases.LeaderboardFolder.PlayerRank
{
    public class FourPlayerRank : MonoBehaviour
    {
        [SerializeField] private TMP_Text _place;
        [SerializeField] private TMP_Text _nickName;
        [SerializeField] private TMP_Text _score;

        public void Init(int place, string nickName, int score)
        {
            _place.text = place.ToString();
            _nickName.text = nickName;
            _score.text = score.ToString();
        }
    }
}