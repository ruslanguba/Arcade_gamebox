using System.Collections.Generic;
using UnityEngine;

public class EnemeySquadCreator : MonoBehaviour
{
    [SerializeField] private GameObject _enemeySquadParent;
    [SerializeField] private EnemeyFormation _enemeyFormation;
    [SerializeField] private int _enemeyCount = 3;
    [SerializeField] private int _increaseCoef; // вот тут зависимость от выбора сложности
    [SerializeField] private FormationType _formationType;
    [SerializeField] private float _sqaudAttackSpeed; // это надо вынести куда-то
    [SerializeField] private float _attackSpeedIncreaceCoef; // это надо вынести куда-то

    private void OnEnable()
    {
        GameDifficultyIncreser.OnEnemeyCountUp += IncreaceEnemeyCount;
        GameDifficultyIncreser.OnEnemeyCountUp += IncreaseAttackSpeed;

    }

    private void OnDisable()
    {
        GameDifficultyIncreser.OnEnemeyCountUp -= IncreaceEnemeyCount;
        GameDifficultyIncreser.OnEnemeyCountUp -= IncreaseAttackSpeed;
    }

    void Start()
    {
        _enemeyFormation = GetComponent<EnemeyFormation>();
    }

    private void RandomFormationType()
    {
        int rnd = Random.Range(0, 2);
        switch (rnd)
        {
            case 0:
                _formationType = FormationType.Triangle; break;
            case 1:
                _formationType = FormationType.Square; break;
        }
    }
    public GameObject SquadToSpown()
    {
        RandomFormationType();
        int positionsCount = _enemeyFormation.GenerateFormationPositions(transform.position, _formationType, _enemeyCount).Count;
        List<Vector2> spawnPositions = _enemeyFormation.GenerateFormationPositions(transform.position, _formationType, _enemeyCount);

        GameObject newEnemeySquad = Instantiate(_enemeySquadParent, Vector2.zero, Quaternion.identity);
        newEnemeySquad.GetComponent<EnemeySquadAttack>().SetAttackSpeed(_sqaudAttackSpeed); // это надо вынести куда-то
        newEnemeySquad.transform.position = CalculateCentroid(spawnPositions);
        for (int i = 0; i < positionsCount; i++)
        {
            GameObject newEnemey = ObjectPool.Instance.GetObjectFromPool(ObjectPool.Instance.EnemeyConfig, ObjectPool.Instance.EnemyPool);
            newEnemey.transform.position = spawnPositions[i];
            newEnemey.transform.parent = newEnemeySquad.transform;
            newEnemeySquad.GetComponent<EnemeySquad>().AddEnemey(newEnemey.GetComponent<Enemey>());
        }
        return newEnemeySquad;
    }

    private Vector2 CalculateCentroid(List<Vector2> positions)
    {
        Vector2 sum = Vector2.zero;
        foreach (var pos in positions)
        {
            sum += pos;
        }
        return sum / positions.Count;
    }

    public void IncreaceEnemeyCount()
    {
        _increaseCoef++;
        _enemeyCount = _increaseCoef * (_increaseCoef + 1) / 2;
    }

    public void IncreaseAttackSpeed()
    {
        _sqaudAttackSpeed = _sqaudAttackSpeed / _attackSpeedIncreaceCoef;
    }
}
