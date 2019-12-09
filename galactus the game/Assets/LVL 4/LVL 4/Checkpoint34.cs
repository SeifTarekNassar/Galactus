using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint34 : MonoBehaviour {

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
            FindObjectOfType<LvlManager>().CurrentCheckpoint = this.gameObject;
    }
	
}
