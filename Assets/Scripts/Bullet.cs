using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IReturnToPool, ILouncheble
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _startImpulse;
    [SerializeField] private float _damage;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(_damage);
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        ObjectPool.Instance.ReturnObjectToPool(this.gameObject);
    }

    public void Lounch(Transform firepoint)
    {
        transform.position = firepoint.position;
        transform.rotation = firepoint.rotation;
        _rigidbody.AddForce(firepoint.right * _startImpulse, ForceMode2D.Impulse);
    }
}

       
