using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControlLouie : MonoBehaviour {
		public float speed;
		private LouieScript  Louie;
		public int damage ;
	void Start () 
	{
		Louie = FindObjectOfType<LouieScript>();
		if(Louie.transform.localScale.x < 0)
		{
		speed = -speed;
		}

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		 GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "EnemyLong")
        {
            FindObjectOfType<CloseRange34>().TakeDamage(damage);
			Destroy(gameObject);
        }
		if(other.tag == "Louie")
        {
            FindObjectOfType<LouieScript>().TakeDamage(damage);
			Destroy(gameObject);
        }
		if(other.tag == "Player")
		{		
			FindObjectOfType<RickTakingDamage34>().TakeDamage(damage);
			Destroy(gameObject);
			
		}
    }
}
