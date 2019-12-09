using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControler34 : MonoBehaviour {

	public float speed;
    private Controller34 Player;

	private CloseRange34 Close;
	public int damage ;

	void Start () 
	{
		Player = FindObjectOfType<Controller34>();

        if(Player.transform.localScale.x < 0)
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
       //Seq 1 Enemys

        if (other.name == "frame_apngframe0_0 (9)")
        {
            FindObjectOfType<Seq1Enemy5>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.name == "frame_apngframe0_0 (3)")
        {
            FindObjectOfType<Seq1Enemy2>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.name == "frame_apngframe0_0 (5)")
        {
            FindObjectOfType<Seq1Enemy3>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.name == "frame_apngframe0_0 (7)")
        {
            FindObjectOfType<Seq1Enemy4>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.name == "frame_apngframe0_0")
        {
            FindObjectOfType<Seq1Enemy1>().TakeDamage(damage);
            Destroy(gameObject);
        }

        //Seq 2 Enemys
        if (other.name == "Blue1")
        {
            FindObjectOfType<Seq2Enemy6>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.name == "Blue2")
        {
            FindObjectOfType<Seq2Enemy2>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.name == "Blue3")
        {
            FindObjectOfType<Seq2Enemy3>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.name == "PC Computer - Captain Claw - Cutthroat_9")
        {
            FindObjectOfType<Seq2Enemy1>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.name == "PC Computer - Captain Claw - Cutthroat_9 (2)")
        {
            FindObjectOfType<Seq2Enemy4>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.name == "PC Computer - Captain Claw - Cutthroat_9 (3)")
        {
            FindObjectOfType<Seq2Enemy5>().TakeDamage(damage);
            Destroy(gameObject);
        }

        //Seq 3 Enemys
        if (other.name == "Idle (1)")
        {
            FindObjectOfType<RobotsLouie>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.name == "Idle (2)")
        {
            FindObjectOfType<RobotsLouie1>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.name == "Idle (3)")
        {
            FindObjectOfType<RobotsLouie2>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.name == "Idle (4)")
        {
            FindObjectOfType<Robots4>().TakeDamage(damage);
            Destroy(gameObject);
        }

        //Boss Louie
        if (other.tag == "Louie")
        {
            FindObjectOfType<LouieScript>().TakeDamage(damage);
			Destroy(gameObject);
        }
        
        //Player
		if(other.tag == "Player")
		{		
			FindObjectOfType<RickTakingDamage34>().TakeDamage(damage);
			Destroy(gameObject);	
		}
        
    }
}
