using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashObjectSpawner : MonoBehaviour
{
    public GameObject spawnObject;
    public float spawnTimeMax;
    public float spawnTimeMin;

    // Start is called before the first frame update
    void Start()
    {
        // Start Crash Object Spawning
        Invoke("Spawn", 3.0f);
    }

    // Update is called once per frame
    public void Spawn()
    {
        // Spawn new Crash Object
        GameObject obj = Instantiate<GameObject>(spawnObject, transform.position, transform.rotation);
        obj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0.75f, 9f);

        // Recall Spawn with random spawn timer
        Invoke("Spawn", UnityEngine.Random.Range(spawnTimeMin, spawnTimeMax));
    }
}
