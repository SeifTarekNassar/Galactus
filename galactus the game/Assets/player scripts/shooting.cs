using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {
    public Transform firepoint;
   // public GameObject impacteffect;
    public int damage = 30;
    public LineRenderer line;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
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
       
       // Instantiate(impacteffect, hitinfo.point, Quaternion.identity);
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
}
