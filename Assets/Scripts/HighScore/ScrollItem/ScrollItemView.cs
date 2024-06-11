using TMPro;
using UnityEngine;

namespace HighScore
{
    public class ScrollItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playerNameText;
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void SetPlayer(string playerName, int score)
        {
            _playerNameText.text = playerName;
            _scoreText.text = score.ToString();
        }
    }
}