using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _characterRigidbody;
    [SerializeField] float _power;
    [SerializeField] float _stabilisatorSpeed;
    [SerializeField] private bool _isStabilisatorActive;
    void Start()
    {
        _characterRigidbody = GetComponent<Rigidbody2D>();
    }

    public void StabilisatorActivate()
    {
        _isStabilisatorActive = !_isStabilisatorActive;
    }

    public void MoveCharacter(float axisX, float axisY)
    {
        Vector2 moveDirection = new Vector2(axisX, axisY).normalized;
        Vector2 moveVelocity = moveDirection * _power;
        if(_isStabilisatorActive )
        {
            _characterRigidbody.velocity = moveVelocity * _stabilisatorSpeed;
        }
        else
        {
            _characterRigidbody.AddForce(moveVelocity);
        }
    }
}
