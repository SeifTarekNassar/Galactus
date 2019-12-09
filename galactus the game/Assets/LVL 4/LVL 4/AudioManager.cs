using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource efxSource;
    public AudioSource musicSource;
    public static AudioManager instance = null;
    public float lowpitchrange = .95f;
    public float highpitchrange = 1.05f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }


    public void randomizefs(params AudioClip[] clips)
    {
        int randomindex = Random.Range(0, clips.Length);
        float randompitch = Random.Range(lowpitchrange, highpitchrange);
        efxSource.pitch = randompitch;
        efxSource.clip = clips[randomindex];
        efxSource.Play();
    }
    public void PauseMusic()
    {
        efxSource.Pause();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
