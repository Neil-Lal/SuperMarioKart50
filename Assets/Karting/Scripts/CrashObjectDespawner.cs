using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashObjectDespawner : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter (Collider collider) 
    {
        if (collider.gameObject.tag == "CrashObj")
        {
            Destroy(collider.gameObject);
        }
    }    
}
