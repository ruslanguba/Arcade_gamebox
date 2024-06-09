using System;

public class ScoreModel
{
    private int _score;

    public event Action<int> OnScoreChanged;

    public int Score
    {
        get { return _score; }
        private set
        {
            _score = value;
            OnScoreChanged?.Invoke(_score);
        }
    }

    public void AddScore(int value)
    {
        Score += value;
    }
}
