using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelActivator : MonoBehaviour
{
    LivesCounter _livesCounter;
    private string pauseText = "Pause";
    private string defiatText = "Defeat";
    [SerializeField] private Text panelText;
    [SerializeField] private GameObject _pausePanel;

    private void Start()
    {
        _livesCounter = GetComponentInParent<LivesCounter>();
        _livesCounter.OnDefeat += Defeat;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
        panelText.text = pauseText;
 
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }

    public void Defeat()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
        panelText.text = defiatText;
        _pausePanel.GetComponent<Image>().color = Color.red;
    }
}
