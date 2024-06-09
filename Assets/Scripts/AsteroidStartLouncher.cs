using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AsteroidStartLouncher : MonoBehaviour, IIncreasable
{
    [SerializeField] private Vector2 _gameZoneMin;
    [SerializeField] private Vector2 _gameZoneMax;
    [SerializeField] private Vector2 _target;
    [SerializeField] private float _minImpulsForse;
    [SerializeField] private float _maxImpulsForse;
    [SerializeField] private float _onLvlUpCoef;

    private void OnEnable()
    {
        GameDifficultyIncreser.OnAsteroidImpulseUp += IncreaceLVL;
    }

    private void OnDisable()
    {
        GameDifficultyIncreser.OnAsteroidImpulseUp -= IncreaceLVL;
    }

    private void Start()
    {
        FindGameZone();
    }

    private void FindGameZone() //ToDo
    {
        _gameZoneMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        _gameZoneMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    public void SetRandomTarget()
    {
        float x = Random.Range(_gameZoneMin.x, _gameZoneMax.x);
        float y = Random.Range(_gameZoneMin.y, _gameZoneMax.y);
        _target = new Vector2(x, y);
    }

    public void LounchAsteroid(GameObject asteroid)
    {
        SetRandomTarget();
        Vector2 startPosition = asteroid.transform.position;
        Vector2 direction = (_target - startPosition).normalized;
        float impuls = Random.Range(_minImpulsForse, _maxImpulsForse);
        asteroid.GetComponent<Rigidbody2D>().AddForce(direction * impuls, ForceMode2D.Impulse);
    }

    public void IncreaceLVL()
    {
        _maxImpulsForse += _onLvlUpCoef;
    }
}
