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
        if (other.name == "Player")
            FindObjectOfType<LevelManager34>().CurrentCheckPoint = this.gameObject;
    }
	
}
