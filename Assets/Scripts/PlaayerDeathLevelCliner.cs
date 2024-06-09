using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaayerDeathLevelCliner : MonoBehaviour
{
    private PlayerHealthModel _healthModel;

    private void OnEnable()
    {
        _healthModel = FindObjectOfType<PlayerHealthModel>();
        _healthModel.OnDeath += CleanZone;
        _healthModel.OnDeath += RespownCharacter;
    }

    private void OnDisable()
    {
        _healthModel.OnDeath -= CleanZone;
        _healthModel.OnDeath += RespownCharacter;
    }

    private void RespownCharacter()
    {
        transform.position = Vector2.zero;
    }

    private void CleanZone()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(Vector2.zero, new Vector2(100, 100), 0);

        List<IReturnToPool> interfaceObjects = new List<IReturnToPool>();

        foreach (var collider in colliders)
        {
            MonoBehaviour monoBehaviour = collider.GetComponent<MonoBehaviour>();

            if (monoBehaviour != null)
            {
                IReturnToPool myInterface = monoBehaviour as IReturnToPool;
                if (myInterface != null)
                {
                    interfaceObjects.Add(myInterface);
                }
            }
        }

        foreach (var collider in interfaceObjects)
        {
            collider.ReturnToPool();
        }
    }
}
