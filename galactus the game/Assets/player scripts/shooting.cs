using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {
    public Transform firepoint;
   // public GameObject impacteffect;
    public int damage = 30;
    public LineRenderer line;

    AudioClip firesound;
    bool shot;
    private Animator anim;
   
	void Start () {
        anim = GetComponent<Animator>();
       
	}
	
	
	void Update () {
        shot = false;
        anim.SetBool("Shoot", shot);
        if (Input.GetButtonDown("Fire1") )
        {
            
            StartCoroutine(MyCoroutine());
            AudioManager.instance.RandomizeSfx(firesound, firesound);
     

        }
       
        if (Input.GetButtonDown("Fire1") && Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) >0.1 )
        {
            StartCoroutine( shoot());
        }


	}
    IEnumerator shoot()
    {
        RaycastHit2D hitinfo =Physics2D.Raycast(firepoint.position, firepoint.right);
        if (hitinfo)
        {
            Debug.Log(hitinfo.transform.name);
       
       //Instantiate(impacteffect, hitinfo.point, Quaternion.identity);
        line.SetPosition(0,firepoint.position);
        line.SetPosition(1, hitinfo.point);
        }
        else
        {
            line.SetPosition(0,firepoint.position);
        line.SetPosition(1,firepoint.position + firepoint.right * 100);
        }
        line.enabled = true;
        yield return 0;
        line.enabled = false;
    }

    IEnumerator MyCoroutine()
    {
        //This is a coroutine

        shot = true;
        anim.SetBool("Shoot", shot);
        yield return 0;    //Wait one frame
        yield return 0; 
        StartCoroutine(shoot());
        yield return 0; 
    }
}
