using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBoss : MonoBehaviour {

    public AudioClip fight;
    public AudioSource Main;
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManagerlvl4.instance.randomizefs(fight);
            Main.Pause();
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManagerlvl4.instance.PauseMusic();
            Main.Play();
        }
    }
}
