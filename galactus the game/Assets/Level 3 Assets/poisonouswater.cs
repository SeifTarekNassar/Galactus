using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonouswater : MonoBehaviour {

    // Use this for initialization
    public int damage;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            FindObjectOfType<PlayerStats>().takedamage(damage);
    }
}
