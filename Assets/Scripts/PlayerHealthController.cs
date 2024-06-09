using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private PlayerHealthView healthView;
    private PlayerHealthModel healthModel;

    private void Start()
    {
        healthModel = GetComponent<PlayerHealthModel>();
        healthView = GetComponentInChildren<PlayerHealthView>();
        healthModel.OnHealthChanged += healthView.UpdateHealthBar;
        healthModel.OnDeath += healthView.OnDeath;
    }

    public void TakeDamage(float damage)
    {
        healthModel.TakeDamage(damage);
    }
}
