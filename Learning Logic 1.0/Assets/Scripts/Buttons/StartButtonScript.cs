using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{

    //public GameObject Sprites and SpawnPoints
    public Transform[] spawnTypes;
    public Transform[] spawnPoints; 


	// Use this for clicked the button
	public void OnClicked () {

        //Generates sprite 0 at spawnpoint 0
        //Instantiate(spawnTypes[0], spawnPoints[0].position, spawnPoints[0].rotation);


        SceneManager.LoadScene("0_Instructions");
    }

	
}
