using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienCoinPickup : MonoBehaviour {
    public AudioClip coin1, coin2;
    public int coin_value = 1;
	void Start () {
		
	}
	
	
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.RandomizeSfx(coin1, coin2);
            FindObjectOfType<PlayerStats>().coinscollected +=coin_value;
            Destroy(this.gameObject);
        }
    }
}
