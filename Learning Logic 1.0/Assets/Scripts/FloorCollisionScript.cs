using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollisionScript : MonoBehaviour {

    public ScoreScript scorer;

    public AudioClip deadSound;
    private AudioSource deadAudioSource;

    public SendtoSheetsScript sheets;

    void Awake()
    {
        deadAudioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        scorer.ScoreDec();
        Debug.Log("I hit the floor");

        //play the incorrect sound
        deadAudioSource.PlayOneShot(deadSound, 1F);

        Destroy(collide.gameObject);
        //Debug.Log("I killed the thing");

        //update the score log string
        SendtoSheetsScript.scoreLogStorage.ScoreLogCollectLevel1("F");
    }

}
