using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone0CollisionScript : MonoBehaviour {

    private bool Zone1On;
    private bool Zone2On;
    private bool Zone3On;

    public ScoreScript scorer;

    //public SendtoSheetsScript sheets; 

  
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
        Debug.Log("In the Zone 0 script I have turned on Zone 1");
        Debug.Log("Value of Zone1On is " + Zone1On);
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
        //Zone1On = true;

        Debug.Log("Value of Zone1On is: " + Zone1On);


        if (collide.gameObject.tag == "TypeB" && Zone1On)
        {
            //Decrement score for not following the (new) rule
            scorer.ScoreDec();
            Debug.Log("I missed the Zone1 Rule");

            Destroy(collide.gameObject);
            //Debug.Log("I killed the thing");

            //play the incorrect sound
            incorrectAudioSource.PlayOneShot(incorrectSound, 1F);

            //update the score log string
            SendtoSheetsScript.scoreLogStorage.ScoreLogCollectLevel1("Z0");
        }
        else if (collide.gameObject.tag == "TypeC" && Zone2On)
        {
            //Decrement score for not following the (new) rule
            scorer.ScoreDec();
            Debug.Log("I missed the Zone2 Rule");

            Destroy(collide.gameObject);
            //Debug.Log("I killed the thing");

            //update the score log string
            SendtoSheetsScript.scoreLogStorage.ScoreLogCollectLevel1("Z0");

            //play the incorrect sound
            incorrectAudioSource.PlayOneShot(incorrectSound, 1F);
        }
        else if (collide.gameObject.tag == "TypeD" && Zone3On)
        {
            //Decrement score for not following the (new) rule
            scorer.ScoreDec();
            Debug.Log("I missed the Zone3 Rule");

            Destroy(collide.gameObject);
            //Debug.Log("I killed the thing");

            //update the score log string
            SendtoSheetsScript.scoreLogStorage.ScoreLogCollectLevel1("Z0");

            //play the incorrect sound
            incorrectAudioSource.PlayOneShot(incorrectSound, 1F);
        }
        else
        {
            //Increment score for following the (lack of) rule
            scorer.ScoreNullInc();
            Debug.Log("I didn't have a new rule to follow");

            Destroy(collide.gameObject);
            Debug.Log("z0: I made it to this if.  killed the thing");

            //update the score log string
            SendtoSheetsScript.scoreLogStorage.ScoreLogCollectLevel1("Z0");

            //play the correct sound
            correctAudioSource.PlayOneShot(correctSound, 1F);
        }

        //Destroy(collide.gameObject);
        //Debug.Log("I killed the thing");
    }


}
