using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    [SerializeField] private float _fireSpeed;
    private float _fireTime;

    void Update()
    {
        Shoot();
    }

    protected void Shoot()
    {
        if(_fireTime <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject bullet = ObjectPool.Instance.GetObjectFromPool(ObjectPool.Instance.BulletConfig, ObjectPool.Instance.BulletPool);
                bullet.GetComponent<ILouncheble>().Lounch(_firePoint);
                _fireTime = _fireSpeed;
            }
        }
        else
        {
            _fireTime -= Time.deltaTime;
        }
    }
}
