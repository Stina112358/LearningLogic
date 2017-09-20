using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone0ContraCollisionScript : MonoBehaviour
{

    private bool Zone1On;
    private bool Zone2On;
    private bool Zone3On;

    public ScoreScript scorer;

    

    //Gets the sound and the source for the sound (need both to play a sound) 
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    private AudioSource correctAudioSource;
    private AudioSource incorrectAudioSource;


    public void Awake()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        correctAudioSource = audioSources[0];
        incorrectAudioSource = audioSources[1];

        Zone1On = false;
        Debug.Log("Initial value of Zone1On in Z0 is : " + Zone1On);
        Zone2On = false;
        Zone3On = false;
    }

    public void Zone1TurnedOn()
    {
        Zone1On = true;
        //Debug.Log("Zone 1 On");
        //Debug.Log("In the Zone 0 script I have turned on Zone 1");
        //Debug.Log("Value of Zone1On is " + Zone1On);
    }
    public void Zone2TurnedOn()
    {
        Zone2On = true;
        //Debug.Log("Zone 2 On");
    }
    public void Zone3TurnedOn()
    {
        Zone3On = true;
        //Debug.Log("Zone 3 On");
    }



    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == "TypeA")
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
        SendtoSheetsScript.scoreLogStorage.ScoreLogCollectLevel1("CZ0");
    }


}
