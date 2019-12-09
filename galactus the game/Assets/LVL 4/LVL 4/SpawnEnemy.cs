using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	public GameObject Enemy;
    public Transform PositionSpawn;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        for(int i = 0; i < 5; i ++)
        if(other.tag == "Player")
        Instantiate(Enemy, PositionSpawn.position, PositionSpawn.rotation);
    }
}
