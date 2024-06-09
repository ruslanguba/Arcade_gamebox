using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour, IInteractable, IDamagable
{
    AsteroidDestroy _asteroidDestroy => GetComponent<AsteroidDestroy>();
    private Rigidbody2D _rigidbody;
    private float _mass;
    private float _size;
    [SerializeField] private float _sizeReduction;
    [SerializeField] private bool _isInteracted = false;

    public void Interract()
    {
        _isInteracted = true;
    }

    public void SetStartStats(float size, float mass)
    {
        _size = size;
        _mass =  mass;
        transform.localScale = Vector3.one * _size;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.mass = _mass;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.GetComponent<IDamagable>() != null)
        {
            collision.gameObject.GetComponent<IDamagable>().TakeDamage(20);
            if (_isInteracted)
            {
                ScoreController.Instance.AddScore(100);
            }
        }
    }

    public void TakeDamage(float _damage)
    {
        _size -= _sizeReduction;
        _mass -= _sizeReduction * 10;
        transform.localScale = Vector3.one * _size;
        _rigidbody.mass = _mass;
        CheckIfActive();
    }

    private void CheckIfActive()
    {
        if (_size <= 0.5)
        {
            _asteroidDestroy.ReturnToPool();
        }
    }
}
