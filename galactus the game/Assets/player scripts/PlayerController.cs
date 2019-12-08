using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float MoveSpeed = 6f;
    public float jumphight = 4f;
    bool isFacingRight;
    public KeyCode Space;
    public KeyCode L;
    public KeyCode R;
    public bool grounded;
    


    public Transform groundcheck;
    public float groundcheckRadius;
    public LayerMask whatsGround;
    private Animator anim;

    public AudioClip jump1;
    public AudioClip jump2;
    public AudioClip walk;
    public AudioClip walk2;
 
	void Start () {
        anim = GetComponent<Animator>();
        isFacingRight = true;
	}
	
	
	void Update () {
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
       anim.SetBool("Ground", grounded);
      // anim.SetBool("Jump", Input.GetKey(Space));
      
        if (Input.GetKeyDown(Space) && grounded)
        {
            jump();
        }
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            AudioManager.instance.RandomizeSfx(walk, walk2);
            if (isFacingRight)
            {
                flip();
                isFacingRight = false;
            }
        }
        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            AudioManager.instance.RandomizeSfx(walk, walk2);
            if (!isFacingRight)
            {
                flip();
                isFacingRight = true;
            }
        }
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, whatsGround);
    }
    // flip function
    void flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
   // jump function
    void jump()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up *jumphight;
        AudioManager.instance.RandomizeSfx(jump1, jump2);
    }

}
