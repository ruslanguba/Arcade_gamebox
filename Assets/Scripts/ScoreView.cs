using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _panelScoreText2;

    public void Initialize(ScoreModel scoreModel)
    {
        scoreModel.OnScoreChanged += UpdateScore;
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score.ToString();
        _panelScoreText2.text = "Score: " + score.ToString();
    }
}
