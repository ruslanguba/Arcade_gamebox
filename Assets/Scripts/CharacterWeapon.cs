using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 5f;
    public void LookToTarget(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        direction.z = 0;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    public void SetRotaionSpeed(float holdObjectMass)
    {

    }
}
