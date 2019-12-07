using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour {
    public GameObject Door;
    public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	 
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter2D(Collider2D other){
       
        if(other.gameObject.tag =="Player"){

        }
    }
    IEnumerator Teleport()
{
    target = GameObject.FindGameObjectWithTag("Player");   //Make sure your pl     
        yield  return new WaitForSeconds(2);
       target.transform.position = new Vector2(Door.transform.position.x,Door.transform.position.y);
}
}
