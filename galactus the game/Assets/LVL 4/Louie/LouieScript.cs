using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Slider healthUI2;
    public Slider healthUI;
    Transform T1;

	public Transform firepoint;
	public GameObject LaserBullet;

	private float nextTimeToFire = 0f;

	public int health = 100;
    public int health2 = 100;

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

        healthUI.value = health;
        healthUI2.value = health2;
        if (minx > transform.position.x && !isfacingRight)
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
		if (other.gameObject.tag =="Player")
		{
			if(Time.time>= nextTimeHit)
			{
			
			melee = true;
<<<<<<< HEAD
			FindObjectOfType<PlayerStats>().takedamage(damage);	
=======
			FindObjectOfType<RickTakingDamage34>().TakeDamage(damage);	
>>>>>>> LEVEL-4
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
					 
		if (other.tag =="Player")
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
					Instantiate(LaserBullet, firepoint.position, firepoint.rotation);
	
				}
			} 
		}
	}
	

    public void TakeDamage(int Damage) 
	{ 
           this.health = this.health - Damage;
            if (this.health < 0)
            {
                this.health = 0;
            }
            if (this.health == 0)
            {
                this.health2 = this.health2 - Damage;
                if (this.health2 < 0)
                {
                    this.health2 = 0;
                }
                if (health2 == 0)
                {
                    Destroy(this.gameObject);
                }

            } 
                
    }
}
