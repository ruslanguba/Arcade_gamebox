using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroy : MonoBehaviour, IReturnToPool
{
    [SerializeField] private bool _isInGame;

    public void EnterToGameZone()
    {
        _isInGame = true;
    }

    public void ReturnToPool()
    {
        ObjectPool.Instance.ReturnObjectToPool(this.gameObject);
        if (_isInGame)
        {
            _isInGame = false;
            ObjectPool.Instance.ReturnObjectToPool(this.gameObject);
        }
    }

}
