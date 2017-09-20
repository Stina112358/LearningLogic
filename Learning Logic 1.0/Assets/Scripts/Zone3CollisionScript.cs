using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone3CollisionScript : MonoBehaviour
{

    private bool Zone3On;
    public ScoreScript scorer;

    //Gets the sound and the source for the sound (need both to play a sound) 
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    private AudioSource correctAudioSource;
    private AudioSource incorrectAudioSource;

    //public SendtoSheetsScript sheets;

    public void Zone3TurnOn()
    {
        Zone3On = true;
        //Debug.Log("Zone 3 On");
    }

    public void Awake()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        correctAudioSource = audioSources[0];
        incorrectAudioSource = audioSources[1];
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == "TypeD" && Zone3On)
        {
            //Increment score for following the rule
            scorer.ScoreRuleInc();
            //Debug.Log("I followed the Zone3 Rule");

            //play the correct sound
            correctAudioSource.PlayOneShot(correctSound, 1F);

        }
        else
        {
            //Decrement score for not following the rule
            scorer.ScoreDec();
            //Debug.Log("I didn't follow the rules");

            //play the incorrect sound
            incorrectAudioSource.PlayOneShot(incorrectSound, 1F);
        }

        Destroy(collide.gameObject);
        //Debug.Log("I killed object typeD");

        //update the score log string
        SendtoSheetsScript.scoreLogStorage.ScoreLogCollectLevel1("Z3");
    }
}