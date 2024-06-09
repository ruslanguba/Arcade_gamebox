using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAdvise : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Destroy(gameObject, 2);
        }
    }
}
