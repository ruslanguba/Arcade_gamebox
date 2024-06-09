using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficultyIncreser : MonoBehaviour
{
    public static event Action OnEnemeyAttackSpeedUp;
    public static event Action OnEnemeyCountUp;
    public static event Action OnEnemeyRespawnTimeUp;
    public static event Action OnAsteroidRespawnTimeUp;
    public static event Action OnAsteroidMaxSizeUp;
    public static event Action OnAsteroidImpulseUp;

    [SerializeField] private float _timeEnemeyAttackSpeed;
    [SerializeField] private float _timeEnemeyCount;
    [SerializeField] private float _timeEnemeyRespawnTime;
    [SerializeField] private float _timeAsteroidRespawnTime;
    [SerializeField] private float _timeAsteroidMaxSize;
    [SerializeField] private float _timeAsteroidImpulse;

    private int currentLevel = 1;

    void Start()
    {
        StartIncreaseDifficultyTimer(_timeEnemeyAttackSpeed, OnEnemeyAttackSpeedUp);
        StartIncreaseDifficultyTimer(_timeEnemeyCount, OnEnemeyCountUp);
        StartIncreaseDifficultyTimer(_timeEnemeyRespawnTime, OnEnemeyRespawnTimeUp);
        StartIncreaseDifficultyTimer(_timeAsteroidRespawnTime, OnAsteroidRespawnTimeUp);
        StartIncreaseDifficultyTimer(_timeAsteroidMaxSize, OnAsteroidMaxSizeUp);
        StartIncreaseDifficultyTimer(_timeAsteroidImpulse, OnAsteroidImpulseUp);
    }

    private void StartIncreaseDifficultyTimer(float interval, Action onLevelUpAction)
    {
        StartCoroutine(IncreaseDifficultyOverTime(interval, onLevelUpAction));
    }

    private IEnumerator IncreaseDifficultyOverTime(float interval, Action onLevelUpAction)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            onLevelUpAction?.Invoke();
        }
    }
}
