using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaySceneStarter : MonoBehaviour
{
    [SerializeField] GameObject _world;
    [SerializeField] GameObject _character;
    [SerializeField] float _cameraSize; 

    private void Awake()
    {
        Camera.main.orthographicSize = _cameraSize;
    }

    private void Start()
    {
        Instantiate(_world);
        Instantiate(_character);
    }
}
