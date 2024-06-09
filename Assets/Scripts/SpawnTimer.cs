using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    [SerializeField] private float _timeToEnemeySquadSpawn;
    [SerializeField] private float _timeToAsteroidSpown;
    private EnemeySpowner _enemeySpowner;
    private EnemeySquadCreator _enemeySquadCreator;
    private AsteroidCreator _asteroidCreator;
    private AsteroidStartLouncher _asteroidStartLouncher;

    private void OnEnable()
    {
        GameDifficultyIncreser.OnEnemeyRespawnTimeUp += EnemeyTimerUp;
        GameDifficultyIncreser.OnAsteroidRespawnTimeUp += AsteroidTimerUp;

    }

    private void OnDisable()
    {
        GameDifficultyIncreser.OnEnemeyCountUp -= EnemeyTimerUp;
        GameDifficultyIncreser.OnEnemeyCountUp -= AsteroidTimerUp;

    }
    private void Start()
    {
        _enemeySpowner = GetComponent<EnemeySpowner>();
        _enemeySquadCreator = GetComponent<EnemeySquadCreator>();
        _asteroidCreator = GetComponent<AsteroidCreator>();
        _asteroidStartLouncher = GetComponent<AsteroidStartLouncher>();

        StartCoroutine(EnemeySpawnTimer());
        StartCoroutine(AsteroidSpawnTimer());
        
    }

    private void AsteroidTimerUp()
    {
        if(_timeToAsteroidSpown > 2)
        _timeToAsteroidSpown--;
    }

    private void EnemeyTimerUp()
    {
        if(_timeToEnemeySquadSpawn > 10)
        _timeToEnemeySquadSpawn--;
    }

    IEnumerator EnemeySpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToEnemeySquadSpawn);
            GameObject objectToSpawn = _enemeySquadCreator.SquadToSpown();
            _enemeySpowner.FindPlaceToSpawn(objectToSpawn);
        }
    }

    IEnumerator AsteroidSpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToAsteroidSpown);
            GameObject objectToSpawn = _asteroidCreator.CreatedAsteroid();
            _enemeySpowner.FindPlaceToSpawn(objectToSpawn);
            _asteroidStartLouncher.LounchAsteroid(objectToSpawn);
        }
    }
}
