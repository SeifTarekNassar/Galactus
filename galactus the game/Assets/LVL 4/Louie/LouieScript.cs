using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LouieScript : MonoBehaviour {

	public bool isfacingRight = false;
    public float maxspeed;
    public int damage = 2;
	protected bool melee;
	protected bool firing;
	private Animator anim;
	private float nextTimeHit = 0f;
	public float minx;
	public float maxx;
	Transform T1;
	public Transform firepoint;
	public GameObject SpikyBullet;
	public float nextTimeToFire = 0f;
	public int health = 3;

	public void flip() 
	{
        isfacingRight = !isfacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		
	}


	void Start () {
		T1 = this.transform;
		anim = this.GetComponent<Animator>();
	}
	
	void FixedUpdate()
	{
	    if (this.isfacingRight && melee == false && firing == false)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxspeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(!this.isfacingRight && melee == false && firing == false)
		{
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-(maxspeed), this.GetComponent<Rigidbody2D>().velocity.y);
        }	
		else if(melee == true || firing == true)
		{
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
		}

	}


	// Update is called once per frame
	void Update () {
		if(minx > transform.position.x && !isfacingRight)
		{
			flip();
		}
		if(maxx < transform.position.x && isfacingRight)
		{
			flip();
		}
		anim.SetBool("Melee",melee);
		anim.SetBool("Firing",firing);

			StartCoroutine(Waiting());
	}
	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.name =="Player")
		{
			if(Time.time>= nextTimeHit)
			{
			
			melee = true;
			FindObjectOfType<takedamage>().takeDamage(damage);	
			}			
		}

	}
		IEnumerator Waiting()
		{
			yield return new WaitForSeconds(10f);

			firing = false;
			melee = false;
			
		}
	
	void OnTriggerStay2D(Collider2D other)
	{
					 
		if (other.name =="Player")
		{
			 if(other.gameObject.transform.position.x <  T1.position.x && isfacingRight)
			 {
				flip();
			 }
			if(other.gameObject.transform.position.x > T1.position.x && !isfacingRight)
			{
				 flip();
	
			}	
			if(melee == false)
			{
				if(Time.time>=nextTimeToFire)
				{
					
					nextTimeToFire = Time.time + 2f;
					firing = true;
					Instantiate(SpikyBullet, firepoint.position, firepoint.rotation);
	
				}
			} 
		}
	}
	

    public void takeDamage(int Damage) 
	{

            this.health = this.health - Damage;
            if (this.health < 0)
                this.health = 0;
            if (this.health == 0) 
                Destroy(gameObject);
    }
}
