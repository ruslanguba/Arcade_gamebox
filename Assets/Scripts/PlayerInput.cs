using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Character _character;
    private Camera _camera;
    public Action MouseClick;

    public Vector2 MousePosition;

    void Start()
    {
        _character = FindObjectOfType<Character>();
        _camera = Camera.main;
    }

    void Update()
    {
        CheckMoveDirection();
        CheckLooKDirection();
    }

    public void CheckMoveDirection()
    {
        float _moveDirectionX = Input.GetAxis("Horizontal");
        float _moveDirectionY = Input.GetAxis("Vertical");
        if(_character != null)
        {
            _character.MoveCharacter(_moveDirectionX, _moveDirectionY);
        }
    }

    public void CheckLooKDirection()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (_character != null)
        {
            _character.LookToTarget(MousePosition);
        }
    }
}
