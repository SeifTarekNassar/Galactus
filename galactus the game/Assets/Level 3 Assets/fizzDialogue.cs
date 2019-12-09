using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fizzDialogue : MonoBehaviour {

    public dialogue dialogueManager;
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
        {
            string[] talking = { "press countinue to talk" };
            dialogueManager.SetSentences(talking);
            dialogueManager.StartCoroutine(dialogueManager.TalkDialogue());
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            dialogueManager.CloseEverything();
        }
    }
}
