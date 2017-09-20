using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone1ContraCollisionScript : MonoBehaviour
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
        //Debug.Log("Zone 1 On");
    }

    public void Awake()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        correctAudioSource = audioSources[0];
        incorrectAudioSource = audioSources[1];
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == "TypeB")
        {
            //Decrement score for not following the contrapositive of the rule
            scorer.ScoreDec();
            //Debug.Log("I not followed the Zone1 Rule");

            //play the correct sound
            correctAudioSource.PlayOneShot(incorrectSound, 1F);

        }
        else
        {
            //Decrement score for following the contrapositive of the rule
            scorer.ScoreRuleInc();
            //Debug.Log("I follow the rules");

            //play the incorrect sound
            incorrectAudioSource.PlayOneShot(correctSound, 1F);
        }

        Destroy(collide.gameObject);


        //update the score log string
        SendtoSheetsScript.scoreLogStorage.ScoreLogCollectLevel1("CZ1");
    }
}