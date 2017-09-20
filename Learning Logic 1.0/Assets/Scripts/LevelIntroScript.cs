using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelIntroScript : MonoBehaviour {

    public Transform[] background;
    //public Transform[] backgroundPoint;
    
    public Canvas levelCanvas;


    //public static LevelIntroScript introStorage;

    //void Awake()
    //{
    //    if (introStorage == null)
    //    {
    //        DontDestroyOnLoad(gameObject);
    //        introStorage = this;
    //    }
    //    else if (introStorage != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //    levelNumber++;
    //}
   
    // Use this for initialization
    void Start () {

        int levelNumber = LevelTransitionScript.nextLevelNumber;
        if (levelNumber == 0)
        {
            //levelNumber++;
            Instantiate(background[0]); //intuitive
        }
        else if (levelNumber == 1)
        {
            //levelNumber++;
            Instantiate(background[3]); //intuitive
            
        }
        else if (levelNumber == 2)
        {
            Instantiate(background[1]); //abstract
            levelNumber++;
        }
        else if (levelNumber == 3)
        {
            Instantiate(background[1]); //abstract
            levelNumber++;
        }
        else if (levelNumber == 4)
        {
            Instantiate(background[2]); //symbolic
            levelNumber++;
        }
        else if (levelNumber == 5)
        {
            Instantiate(background[2]); //symbolic
            levelNumber++;
        }
        else if (levelNumber == 6)
        {
            Instantiate(background[3]); //counter
            levelNumber++;
        }
        else if (levelNumber == 7)
        {
            Instantiate(background[3]); //counter
            levelNumber++;
        }
    }

    public void OnClicked()
    {
        int levelNumber = LevelTransitionScript.nextLevelNumber;
        //Generates sprite 0 at spawnpoint 0
        //Instantiate(spawnTypes[0], spawnPoints[0].position, spawnPoints[0].rotation);

        if (levelNumber == 1)
        {
            SceneManager.LoadScene("1_Direct_Intuitive");
        }
        else if (levelNumber == 2)
        {
            SceneManager.LoadScene("2_Contra_Intuitive");
        }
        else if (levelNumber == 3)
        {
            SceneManager.LoadScene("3_Direct_Abstract");
        }
        else if (levelNumber == 4)
        {
            SceneManager.LoadScene("4_Contra_Abstract");
        }
        else if (levelNumber == 5)
        {
            SceneManager.LoadScene("5_Direct_Symbloic");
        }
        else if (levelNumber == 6)
        {
            SceneManager.LoadScene("6_Contra_Symbloic");
        }
        else if (levelNumber == 7)
        {
            SceneManager.LoadScene("7_Direct_Counter");
        }
        else if (levelNumber == 8)
        {
            SceneManager.LoadScene("8_Contra_Counter");
        }
    }
}
