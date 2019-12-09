using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue35 : MonoBehaviour {



    public TextMeshProUGUI testDisplay;
    private string[] dialoguesentences;
    public float typingSpeed;
    private int index = 0;
    public GameObject continueButton;
    public GameObject dialogueBox;
    public Rigidbody2D player;

    public KeyCode talk;

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
            player.constraints = RigidbodyConstraints2D.FreezeRotation;
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
                string[] dialogue = { "", "StangeMan:- Hello There, Welcome to our Planet outsider", "Rick:- I got no Time have you seen something fallen from the sky", "StrangeMan:- yeah it have been moved to the temple in this mountense" };
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
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
