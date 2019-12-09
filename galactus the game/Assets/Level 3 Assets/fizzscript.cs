using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fizzscript : BaseEnemy
{

    // Use this for initialization
    public Slider healthUI;
    private SpriteRenderer Sr;
    private float flickertime = 0f;
    public float flickerduration = 0.1f;
    public bool isImmune = false;
    private float immunitytime = 3f;
    public float immunityDuration = 1.5f;
    public bool isfacingRight = true;
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




    public void flip()
    {
        isfacingRight = !isfacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);

    }

    void Start()
    {
        this.health = 200;
        T1 = this.transform;
        anim = this.GetComponent<Animator>();
        Sr = this.gameObject.GetComponent<SpriteRenderer>();
    }
    void flicker()
    {
        if (this.flickertime < this.flickerduration)
        {
            this.flickertime = this.flickertime + Time.deltaTime;
        }
        else if (this.flickertime >= this.flickerduration)
        {
            Sr.enabled = !(Sr.enabled);
            this.flickertime = 0;
        }
    }
     void takedamage(int damage)
    {
        if (this.isImmune == false)
        {
            this.health = this.health - damage;
            if (this.health < 0)
                this.health = 0;
            if (this.health == 0)
            {
                Die();
            }
        }
        this.isImmune = true;
        this.immunitytime = 0f;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.isfacingRight)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxspeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (!this.isfacingRight)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-(maxspeed), this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
   
    void Update()
    {
        if (minx > transform.position.x && !isfacingRight)
        {
            flip();
        }
        if (maxx < transform.position.x && isfacingRight)
        {
            flip();
        }

        anim.SetBool("Melee", melee);
        anim.SetBool("Firing", firing);

        StartCoroutine(Waiting());


        if (this.isImmune == true)
        {
            flicker();
            immunitytime = immunitytime + Time.deltaTime;
            if (immunitytime >= immunityDuration)
            {
                this.isImmune = false;
                this.Sr.enabled = true;
            }
        }
        healthUI.value = health;
    }


    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Time.time >= nextTimeHit)
            {

                melee = true;
                FindObjectOfType<PlayerStats>().takedamage(damage);
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
            if (melee == false)
            {
                if (Time.time >= nextTimeToFire)
                {

                    nextTimeToFire = Time.time + 2f;
                    firing = true;
                    Instantiate(SpikyBullet, firepoint.position, firepoint.rotation);

                }
            }
        }
    }

}