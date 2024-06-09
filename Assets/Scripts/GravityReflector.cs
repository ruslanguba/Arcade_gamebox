using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReflector : MonoBehaviour
{
    [SerializeField] private Transform _rotator;
   
    void FixedUpdate()
    {
        transform.position = _rotator.position;
        transform.rotation = _rotator.rotation;
    }
}
