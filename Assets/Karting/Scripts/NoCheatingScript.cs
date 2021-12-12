using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NoCheatingScript : MonoBehaviour
{
    public GameObject wall = null;

	void Start() {
		wall = GameObject.Find("NoCheating");
        wall.SetActive(false); 
	}

    void OnTriggerEnter (Collider collider) {
        if(collider.tag == "Player") {
            // Put up wall to stop backtracking!
            wall.SetActive(true);
        }
    }
}
