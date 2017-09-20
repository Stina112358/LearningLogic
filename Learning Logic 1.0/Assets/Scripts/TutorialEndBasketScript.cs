using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEndBasketScript : MonoBehaviour {

    public AudioClip correctSound;
    private AudioSource audioSource;



    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == "TutorialGB")
        {
            Destroy(collide.gameObject);
            //Debug.Log("I killed the penguin, but I did not kill the deputy.");

            //GameObject.Find("InstructionsText").GetComponent<Text>().text = "That's it! The penguin satisfies the hypothesis, so we drag it into the box to meet the conclusion. Let's try something a bit harder.";

            InstructionsScript.catchEmStorage.CatchEm();

            //play the correct sound
            audioSource.PlayOneShot(correctSound, 1F);
            //GameObject.Find("NextInstructionButton").GetComponent<Button>().interactable = true;



        }

    }
}