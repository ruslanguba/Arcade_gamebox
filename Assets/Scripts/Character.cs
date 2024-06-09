using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterMove _characterMove;
    private CharacterWeapon _characterWeapon;

    private void Start()
    {
        _characterMove = GetComponent<CharacterMove>();
        _characterWeapon = GetComponentInChildren<CharacterWeapon>();
    }

    public void MoveCharacter(float axisX, float axisY)
    {
        _characterMove.MoveCharacter(axisX, axisY);
    }

    public void LookToTarget(Vector3 target)
    {
        _characterWeapon.LookToTarget(target);
    }
}
