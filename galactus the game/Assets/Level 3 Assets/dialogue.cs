using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogue : MonoBehaviour {

    public fizzDialogue s;
    public TextMeshProUGUI testDisplay;
    private string[] dialoguesentences;
    public float typingSpeed;
    private int index = 0;
    public GameObject continueButton;
    public GameObject dialogueBox;
    public Rigidbody2D player; 
    public Rigidbody2D Fizz;

    // Use this for initialization
    void Start()
    {
        dialogueBox.SetActive(false);
        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update() { }

    public IEnumerator TypeDialogue()
    {
        dialogueBox.SetActive(true);
        player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        Fizz.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        foreach (char letter in dialoguesentences[index].ToCharArray())
        {
            testDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            if (testDisplay.text == dialoguesentences[index])
            {
                continueButton.SetActive(true);
            }
        }
    }
    public void SetSentences(string[] sentences)
    {
        this.dialoguesentences = sentences;
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < dialoguesentences.Length - 1)
        {
            index++;
            testDisplay.text = "";
            StartCoroutine(TypeDialogue());
        }
        else
        {
            testDisplay.text = "";
            continueButton.SetActive(false);
            dialogueBox.SetActive(false);
            this.dialoguesentences = null;
            index = 0;
            player.constraints = RigidbodyConstraints2D.None;
            Fizz.constraints = RigidbodyConstraints2D.None;
            player.constraints = RigidbodyConstraints2D.FreezeRotation;
            Fizz.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }


    public IEnumerator TalkDialogue()
    {
        dialogueBox.SetActive(true);
        foreach (char letter in dialoguesentences[index].ToCharArray())
        {
            testDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            if (testDisplay.text == dialoguesentences[index])
            {
                string[] dialogue = { "", "Fizz: How did you reach my place", "Reck: so you are the king of the oceans and species in this planet?", "Fizz: Yes, i'm Fizz, get out of my planet or you will suffer", "Reck: i will get the 2 parts no matter what", "Fizz: You're boring. Then I'll show you a watery grave" };
                SetSentences(dialogue);

                continueButton.SetActive(true);
            }
        }
    }
    public void CloseEverything()
    {
        testDisplay.text = "";
        continueButton.SetActive(false);
        dialogueBox.SetActive(false);
        this.dialoguesentences = null;
        index = 0;
        player.constraints = RigidbodyConstraints2D.None;
        Fizz.constraints = RigidbodyConstraints2D.None;
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        Fizz.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
