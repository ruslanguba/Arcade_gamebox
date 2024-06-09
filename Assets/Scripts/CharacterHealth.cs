using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IDamagable
{
    PlayerHealthController controller;

    public void TakeDamage(float damage)
    {
        controller.TakeDamage(damage);
    }

    private void Start()
    {
        controller = FindObjectOfType<PlayerHealthController>();
    }
}
