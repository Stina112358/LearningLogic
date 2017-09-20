﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPenguinCollision : MonoBehaviour {

    //GameObject InstructMan = GameObject.Find("InstructionsManager");
    //InstructionsScript instructScript = InstructMan.GetComponent(typeof(InstructionsScript)); //holds a reference to the instructions script so that I can influence the instructions displayed
    //Component instructString = InstructMan.GetComponent(typeof(InstructionsScript));

    public AudioClip correctSound;
    private AudioSource audioSource;


    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == "TutorialPenguin")
        {
            Destroy(collide.gameObject);
            //Debug.Log("I killed the penguin, but I did not kill the deputy.");

            GameObject.Find("InstructionsText").GetComponent<Text>().text = "That's it! The penguin satisfies the hypothesis, so we drag it into the box to meet the conclusion. Let's try something a bit harder.";

            //play the correct sound
            audioSource.PlayOneShot(correctSound, 1F);
            GameObject.Find("NextInstructionButton").GetComponent<Button>().interactable = true;

        }

    }
}