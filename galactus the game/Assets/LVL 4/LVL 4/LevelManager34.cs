using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager34 : MonoBehaviour {

	public GameObject CurrentCheckPoint;

	public void RespawnPlayer()
	{
		 FindObjectOfType<Controller34>().transform.position = CurrentCheckPoint.transform.position; 
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
