using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZoneActivator : MonoBehaviour
{
    [SerializeField] float padding = 1f;
    private void Start()
    {
        Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Vector2 size = new Vector2(screenSize.x * 2 - padding, screenSize.y * 2 - padding);

        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider != null)
        {
            boxCollider.size = size;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<AsteroidDestroy>() != null)
        {
            collision.GetComponent<AsteroidDestroy>().EnterToGameZone();
        }

        if(collision.GetComponent<EnemeySquadAttack>() != null)
        {
            collision.GetComponent<EnemeySquadAttack>().EnterInGameZone();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<IReturnToPool>() != null && collision.GetComponent<EnemyAttack>() == null)
        {
            collision.GetComponent<IReturnToPool>().ReturnToPool();
        }

        if (collision.GetComponent<EnemeySquadAttack>() != null)
        {
            collision.GetComponent<EnemeySquadAttack>().LeaveGameZone();
        }
    }

}
