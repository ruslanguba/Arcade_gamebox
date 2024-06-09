using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _mass;
    [SerializeField] private int _asteroidLVL;

    private void OnEnable()
    {
        GameDifficultyIncreser.OnAsteroidMaxSizeUp += IncreaceLVL;
    }

    private void OnDisable()
    {
        GameDifficultyIncreser.OnAsteroidMaxSizeUp -= IncreaceLVL;
    }

    public void RaandomAsteroidValues()
    {
        _radius = Random.Range(1, _asteroidLVL * 2);
        _mass = _radius * 10;
    }

    public GameObject CreatedAsteroid()
    {
        RaandomAsteroidValues();
        GameObject newAsteroid = ObjectPool.Instance.GetObjectFromPool(ObjectPool.Instance.AsteroidConfig, ObjectPool.Instance.AsteroidPool);
        newAsteroid.GetComponent<Asteroid>().SetStartStats(_radius, _mass);
        return newAsteroid;
    }

    private void IncreaceLVL()
    {
        _asteroidLVL++;
    }
}
