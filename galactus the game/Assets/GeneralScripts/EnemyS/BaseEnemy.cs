using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {
    public int health = 50;
    public GameObject deatheffect;
		
    void Start () {
		
	}

    public void takedamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }

     
    }
    void Die()
    {
        Instantiate(deatheffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
