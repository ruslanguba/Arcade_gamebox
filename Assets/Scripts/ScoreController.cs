using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    private ScoreModel _scoreModel;
    private static ScoreController _instance;
    public static ScoreController Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject scoreControllerObject = new GameObject("ScoreController");
                _instance = scoreControllerObject.AddComponent<ScoreController>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject); 
            return;
        }
        _instance = this;
    }
    private void Start()
    {
        _scoreView = GetComponent<ScoreView>();
        _scoreModel = new ScoreModel();
        _scoreModel.OnScoreChanged += UpdateScoreView;
        _scoreView.Initialize(_scoreModel);
    }

    private void UpdateScoreView(int score)
    {
        _scoreView.UpdateScore(score);
    }

    public void AddScore(int value)
    {
        _scoreModel.AddScore(value);
    }
}
