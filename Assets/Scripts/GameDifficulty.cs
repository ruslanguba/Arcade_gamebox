using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    public static GameDifficulty Instance { get; private set; }

    private int difficulty;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetInitialDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }

    public int GetDifficulty()
    {
        return difficulty;
    }
}
