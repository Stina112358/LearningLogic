using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone1CollisionScript : MonoBehaviour
{
    private bool Zone1On;
    public ScoreScript scorer;

    //Gets the sound and the source for the sound (need both to play a sound) 
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    private AudioSource correctAudioSource;
    private AudioSource incorrectAudioSource;

    //public SendtoSheetsScript sheets;

    public void Zone1TurnOn()
    {
        Zone1On = true;
        Debug.Log("z1: Zone 1" + Zone1On);
    }

    public void Awake()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        correctAudioSource = audioSources[0];
        incorrectAudioSource = audioSources[1];
        Zone1On = false;
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        Debug.Log("We have a Zone1 collision");
        if (collide.gameObject.tag == "TypeB" && Zone1On)
        {
            //Increment score for following the rule
            scorer.ScoreRuleInc(); 
            Debug.Log("I followed the Zone1 Rule");

            //play the correct sound
            correctAudioSource.PlayOneShot(correctSound, 1F);

            
        }
        else
        {
            //Decrement score for not following the rule
            scorer.ScoreDec();
            Debug.Log("I didn't follow the zone 1 rule");

            //play the incorrect sound
            incorrectAudioSource.PlayOneShot(incorrectSound, 1F);

        }

        Destroy(collide.gameObject);
        //Debug.Log("I killed the thing");


        //update the score log string
        SendtoSheetsScript.scoreLogStorage.ScoreLogCollectLevel1("Z1");
    }
}