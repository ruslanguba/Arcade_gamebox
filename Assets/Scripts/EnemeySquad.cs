using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeySquad : MonoBehaviour
{
    [SerializeField] private List<Enemey> _enemeisInSquad;

    public List<Enemey> EnemeisInSquad => _enemeisInSquad; 

    public void AddEnemey(Enemey enemey)
    {
        _enemeisInSquad.Add(enemey);
    }

}
