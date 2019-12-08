using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    public Slider HealthUI;
    public Text coinsUI;

	 public int health = 100;
    public int lives = 4;
    private float flikertime = 0f;
    private float flickerduration = 0.1f;
        private SpriteRenderer spriteRenderer;
    public bool isImune = false;
    private float imunitytime = 0f;
    public float imnunityduration = 1.5f;
        public int coinscollected = 0;

    //    public AudioClip GameOverSound;

	void Start () {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
	}

    void spriteflicker() {
        if (this.flikertime < this.flickerduration) {
            this.flikertime = Time.deltaTime;
        }
        else if (this.flikertime >= this.flickerduration) ;
        { spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flikertime = 0;
        }
    }
    void playhitreaction()
    {
        this.isImune = true;
        this.imunitytime = 0f;
    }
    public void takedamage(int damage)
    {

        if(this.isImune == false)
        {

            this.health = this.health - damage;
            if (this.health < 0)
                this.health = 0;
            if(this.lives > 0 && this.health == 0)
            {
                FindObjectOfType<LvlManager>().RespawnPlayer();
                this.health = 6;
                this.lives--;
            }
            else if(this.lives ==0 && this.health == 0)
            {
                Debug.Log("Game Over =(");
              //  AudioManager.instance.PlaySingle(GameOverSound);
              //  AudioManager.instance.musicSource.Stop();
              //  Destroy(this.gameObject);

            }
            Debug.Log("player health:" + this.health.ToString());
            Debug.Log("player lives:" + this.lives.ToString());
        }
        playhitreaction();
    }

	
	void Update () {
        HealthUI.value = health;
        coinsUI.text ="" +coinscollected;
		if(this.isImune == true)
        {
            spriteflicker();
            imunitytime = imunitytime + Time.deltaTime;
            if(imunitytime >= imnunityduration)
            {
                this.isImune = false;
                this.spriteRenderer.enabled = true;
                Debug.Log("Imunity Has Ended");
            }

        }

	}
}

