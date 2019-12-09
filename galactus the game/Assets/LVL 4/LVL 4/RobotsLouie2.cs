using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotsLouie2 : MonoBehaviour {
	
	public bool isfacingRight = false;
    public float maxspeed;
    public int damage = 2;
	protected bool melee;
	private Animator anim;
	private float nextTimeHit = 0f;
	public float minx;
	public float maxx;
	public int health = 3;
	Transform T1;
	bool Dead;
	public void flip() 
	{
        isfacingRight = !isfacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);	
	}


	void Start () 
	{
		T1 = this.transform;
		anim = this.GetComponent<Animator>();
	}
	
	
	void Update ()
	{
		if(minx > transform.position.x && !isfacingRight)
		{
			flip();
		}
		if(maxx < transform.position.x && isfacingRight)
		{
			flip();
		}

		anim.SetBool("Melee",melee);
		anim.SetBool("Dead",Dead);
		StartCoroutine(Waiting());
	}


	void FixedUpdate()
	{
	    if (this.isfacingRight)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxspeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(!this.isfacingRight )
		{
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-(maxspeed), this.GetComponent<Rigidbody2D>().velocity.y);
        }	
		else if(melee == true)
		{
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag =="Player")
		{
			if(Time.time>= nextTimeHit)
			{
			melee = true;
			FindObjectOfType<PlayerStats>().takedamage(damage);	
			}			
		}
	}
	IEnumerator Waiting()
	{
		yield return new WaitForSeconds(5f);
		melee = false;	
	}
	IEnumerator DieIn()
	{
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}

	public void TakeDamage(int Damage) 
	{

            this.health = this.health - Damage;
            if (this.health < 0)
                this.health = 0;
            if (this.health == 0) 
			{
				Dead = true;
				if(Time.time>= nextTimeHit)
				{
                StartCoroutine(DieIn());
				}
			}
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if (other.gameObject.transform.position.x < T1.position.x && isfacingRight)
            {
                flip();
            }
            if (other.gameObject.transform.position.x > T1.position.x && !isfacingRight)
            {
                flip();

            }
        }
    }
}
