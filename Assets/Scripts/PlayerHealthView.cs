using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    public void UpdateHealthBar(float healthPercentage)
    {
        healthBar.fillAmount = healthPercentage;
    }

    public void OnDeath()
    {
        
    }
}
