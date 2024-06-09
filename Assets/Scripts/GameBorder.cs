using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBorder : MonoBehaviour
{
    [SerializeField] private Transform _up;
    [SerializeField] private Transform _down;
    [SerializeField] private Transform _left;
    [SerializeField] private Transform _right;
    [SerializeField] private float _offset;

    private void Start()
    {
        Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        _up.position = new Vector3(0, screenSize.y + _offset, 0);
        _up.localScale = new Vector3(screenSize.x * 2, 1, 0);

        _down.position = new Vector3(0, -screenSize.y - _offset, 0);
        _down.localScale = new Vector3(screenSize.x * 2, 1, 0);

        _right.position = new Vector3(screenSize.x + _offset, 0, 0);
        _right.localScale = new Vector3(1, screenSize.y * 2, 0);

        _left.position = new Vector3(-screenSize.x - _offset, 0, 0);
        _left.localScale = new Vector3(1, screenSize.y * 2, 0);
    }
}
