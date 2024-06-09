using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] float _health;

    public void TakeDamage(float _damage)
    {
        _health -= _damage;
        ScoreController.Instance.AddScore((int)_damage);
        if (_health < 0 )
        {
            GetComponent<Enemey>().Death();
        }
    }

}
