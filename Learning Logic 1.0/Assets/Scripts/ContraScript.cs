using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContraScript : MonoBehaviour
{

    int RuleSpawnCounter = 0; // keeps track of which rule we are about to display
    public Transform[] Rules; // array containing the rule UI elements (these are prefabs) 
    public Canvas rulesCanvas; //creates a canvas instantiation to hold the reference to the rules canvas that is already on scene
    public float ruleSpawnTime; // length of time between rule spawns (can be adjusted in the inspector) 

    public PauseScript pauser; // instance of the pause script to be able to reference/control it

    public float spriteSpawnTime; //length of time between sprite spawns (can be adjusted in the inspector)
    public Transform[] spawnPoints; //places on the screen where sprites can spawn 
    public Transform[] spawnTypes; //types of sprites spawaning (drag the prefab sprite into the inspector) 

    public Zone1ContraCollisionScript zone1On;
    public Zone2ContraCollisionScript zone2On;
    public Zone3ContraCollisionScript zone3On;
    public Zone0ContraCollisionScript zone0Update;

    void Start()
    {
        InvokeRepeating("SpawnRule", 0f, ruleSpawnTime); //starts the rule spawning as soon as the scene starts

        pauser.PauseStart(); //starts time in game world

        InvokeRepeating("SpawnSprite", 0f, spriteSpawnTime); //starts the sprite spawning as soon as the scene starts (but the paused time will not have gravity affect them yet)


    }


    void SpawnRule() //This function spawns the rules in the form of UI text components (these are prefabs)
    {

        pauser.Pause(true); //stops time in game world 

        Debug.Log("DIS Rule count is:" + RuleSpawnCounter);


        var ruleText = Instantiate(Rules[RuleSpawnCounter], Rules[RuleSpawnCounter].position, Rules[RuleSpawnCounter].rotation); //instantiates the rule UI text component prefab and gives it a variable name to be referenced
        ruleText.transform.SetParent(GameObject.FindGameObjectWithTag("rulesCanvas").transform, false); // places the UI text component as a child of the Rules Canvas (already on scene)


        if (RuleSpawnCounter == 1)
        {
            Debug.Log("Turn on Zone 1 in Z1 Script");
            zone1On.Zone1TurnOn();
            Debug.Log("Turn on Zone 1 in Z0 Script");
            zone0Update.Zone1TurnedOn();
        }
        else if (RuleSpawnCounter == 2)
        {
            zone2On.Zone2TurnOn();
            zone0Update.Zone2TurnedOn();
        }
        else if (RuleSpawnCounter == 3)
        {
            zone3On.Zone3TurnOn();
            zone0Update.Zone3TurnedOn();
        }

        RuleSpawnCounter++;


        if (RuleSpawnCounter > Rules.Length - 1) //stops the rule spawning once it is out of rules
        {
            CancelInvoke("SpawnRule"); //Cancels this specific invocation 
            //Debug.Log("Stop it with all of these rules!");
        }

    }

    void SpawnSprite() //This function spawns the sprites that will be sorted! 
    {
        //Debug.Log("Let the sprites rain!");

        //Find a random index between zero and one less than the number of possible types/points
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int spawnTypeIndex = Random.Range(0, spawnTypes.Length);

        //Test: pulls first spawn point and type
        //Instantiate(spawnTypes[0], spawnPoints[0].position, spawnPoints[0].rotation);

        //Creates an instance of the randomly chosen spawnType at the randomly chosen spawnPoint
        Instantiate(spawnTypes[spawnTypeIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }


}
