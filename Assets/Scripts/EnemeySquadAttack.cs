using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemeySquadAttack : MonoBehaviour
{
    [SerializeField] private EnemeySquad _enemeySquad;
    [SerializeField] private float _attackSpeed;
    private bool _isAttacking;

    public void SetAttackSpeed(float attackSpeed)
    {
        _attackSpeed = attackSpeed;
        StartCoroutine(SquadAttackCorutine());
    }
    private void Start()
    {
        _enemeySquad = GetComponent<EnemeySquad>();
    }

    IEnumerator SquadAttackCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_attackSpeed);
            if (_isAttacking)
            {
                if (_enemeySquad.EnemeisInSquad.Count > 0)
                {
                    int randomEnemey = Random.Range(0, _enemeySquad.EnemeisInSquad.Count);
                    _enemeySquad.EnemeisInSquad[randomEnemey].GetComponent<EnemyAttack>().Attack();
                }
            }
        }
    }

    public void EnterInGameZone()
    {
        _isAttacking = true;
    }

    public void LeaveGameZone()
    {
        _isAttacking = false;
    }
}
