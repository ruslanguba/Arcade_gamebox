using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text _livesText;

    private LivesCounter _livesManager;

    private void Start()
    {
        _livesManager = GetComponent<LivesCounter>();

        _livesManager.OnLivesChanged += UpdateLivesText;

        UpdateLivesText(_livesManager.CurrentLives);
    }

    private void OnDestroy()
    {
        _livesManager.OnLivesChanged -= UpdateLivesText;
    }

    private void UpdateLivesText(int lives)
    {
        _livesText.text = "Lives: " + lives;
    }
}
