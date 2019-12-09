using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RickTakingDamage34 : MonoBehaviour {
	


	public int health = 100;
    public int lives = 3;
    private float flickertime = 0f;
    public float flickerduration = 0.1f;

	public bool isImmune = false;
    private float immunitytime = 0f;
    public float immunityDuration = 1.5f;

	private SpriteRenderer Sr;

	 void flicker() {
        if (this.flickertime < this.flickerduration)
        {
            this.flickertime = this.flickertime + Time.deltaTime;
        }
        else if (this.flickertime >= this.flickerduration) {
            Sr.enabled = !(Sr.enabled);
            this.flickertime = 0;
        }
    }

    public void TakeDamage(int Damage) {
        if (this.isImmune == false) {
            this.health = this.health - Damage;
            if (this.health < 0)
                this.health = 0;
            if (this.lives > 0 && this.health == 0) {
                FindObjectOfType<LevelManager34>().RespawnPlayer();
                this.health = 100;
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
        {
                Debug.Log("Game Over");
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health:" + this.health.ToString());
            Debug.Log("Player Lives:" + this.lives.ToString());
        }
        this.isImmune=true;
        this.immunitytime = 0f;
        }


	void Start ()
	{
		Sr = this.gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
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

	}
}
