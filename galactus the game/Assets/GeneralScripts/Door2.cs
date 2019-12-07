using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour {
    private Animator anim2;
	// Use this for initialization
	void Start () {
        anim2 = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            //anim.SetTrigger("Open");
            //  anim.ResetTrigger("Open");
            anim2.Play("DoorOpen1");
        }

    }
}
