using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYSHOTS : MonoBehaviour {

    public float speed;
    private fizzscript player;
	public int damage;
	// Use this for initialization
	void Start () 
	{
        player = FindObjectOfType<fizzscript>();
        if(player.transform.localScale.x > 0)
        {
            speed = -speed;
        }
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
       
	}
    void OnTriggerEnter2D(Collider2D other)
    {
     
        if(other.tag == "Enemy")
        {
            FindObjectOfType<fizzscript>().takedamage(damage);
            Destroy(gameObject);
        }

		if(other.tag == "Player")
		{
			FindObjectOfType<PlayerStats>().takedamage(damage);
			Destroy(gameObject);
		}
        
    }
}
