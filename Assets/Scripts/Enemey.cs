using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemey : MonoBehaviour, IReturnToPool
{
    [SerializeField] private ParticleSystem _particleSystem;
    private EnemeySquad _enemeySquad;

    private void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _enemeySquad = GetComponentInParent<EnemeySquad>();
    }
    public void Death()
    {
        StartCoroutine(DEathCorutine()); 
    }

    IEnumerator DEathCorutine()
    {
        _particleSystem.Play();
        _enemeySquad.EnemeisInSquad.Remove(this);
        yield return new WaitForSeconds(_particleSystem.main.duration);
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        ObjectPool.Instance.ReturnObjectToPool(this.gameObject);
    }
}
