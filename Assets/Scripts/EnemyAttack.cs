using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;

    public void Attack()
    {
        GameObject bullet = ObjectPool.Instance.GetObjectFromPool(ObjectPool.Instance.EnemeyBulletConfig, ObjectPool.Instance.EnemeyBulletPool);
        bullet.GetComponent<ILouncheble>().Lounch(_firePoint);
    }
}
