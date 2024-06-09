using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }

    public ObjectPoolConfig EnemeyConfig;
    public ObjectPoolConfig BulletConfig;
    public ObjectPoolConfig AsteroidConfig;
    public ObjectPoolConfig EnemeyBulletConfig;

    private List<GameObject> _enemyPool = new List<GameObject>();
    private List<GameObject> _bulletPool = new List<GameObject>();
    private List<GameObject> _asteroidPool = new List<GameObject>();
    private List<GameObject> _enemeyBulletPool = new List<GameObject>();

    public List<GameObject> EnemyPool { get { return _enemyPool;} }
    public List<GameObject> BulletPool { get { return _bulletPool; } }
    public List<GameObject> AsteroidPool { get { return _asteroidPool; } }
    public List<GameObject> EnemeyBulletPool { get { return _enemeyBulletPool; } }

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

    private void Start()
    {
        CreatePool(EnemeyConfig, _enemyPool);
        CreatePool(BulletConfig, _bulletPool);
        CreatePool(AsteroidConfig, _asteroidPool);
        CreatePool(EnemeyBulletConfig, _enemeyBulletPool);
    }

    private void CreatePool(ObjectPoolConfig config, List<GameObject> pool)
    {
        for (int i = 0; i < config.initialPoolSize; i++)
        {
            GameObject obj = Instantiate(config.prefab);
            obj.transform.parent = transform;
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    private void AddObjectsToPool(ObjectPoolConfig config, List<GameObject> pool)
    {
        for (int i = 0; i < config.poolIncrement; i++)
        {
            GameObject obj = Instantiate(config.prefab);
            obj.transform.parent = transform;
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool(ObjectPoolConfig config, List<GameObject> pool)
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                obj.transform.parent = null;
                return obj;
            }
        }

        AddObjectsToPool(config, pool);
        return GetObjectFromPool(config, pool); 
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        StartCoroutine(ReturnToPoolCoroutine(obj));
    }

    private IEnumerator ReturnToPoolCoroutine(GameObject obj)
    {
        yield return new WaitForEndOfFrame();
        obj.transform.parent = transform;
        obj.SetActive(false);
    }
}
