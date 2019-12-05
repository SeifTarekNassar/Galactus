using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienCoinPickup : MonoBehaviour {
    public AudioClip coin1, coin2;
	
	void Start () {
		
	}
	
	
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Main character")
        {
           // AudioManager.instance.RandomizeSfx(coin1, coin2);
            //FindObjectOfType<Controller>().totalcoin +=coin_value;
            Destroy(this.gameObject);
        }
    }
}
