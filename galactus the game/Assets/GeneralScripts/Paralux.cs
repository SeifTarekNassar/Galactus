using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralux : MonoBehaviour {
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
	// Use this for initialization
	void Start () {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        if (dist < 40)
        {
            transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        }
        if (dist > 40)
        {
            transform.position = new Vector3(startpos, transform.position.y, transform.position.z);
        }
           if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
	}
    void FixedUpdate()
    {
        
    }
}
