using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectPoolConfig", menuName = "ScriptableObjects/ObjectPoolConfig", order = 1)]
public class ObjectPoolConfig : ScriptableObject
{
    public GameObject prefab;
    public int initialPoolSize;
    public int poolIncrement = 10; // Количество объектов для добавления при нехватке
}
