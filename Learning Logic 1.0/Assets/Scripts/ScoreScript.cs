using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {

    public int score;
    public Canvas ScoreCanvas;
    public float timer = 100f;


    //public float spriteSpawnTime = 2; 

    //public int speedUpTime;





    //public SendtoSheetsScript sheets;

    //public DirectIntuitiveScript manager;
    //public bool speedOn;

    public void Awake()
    {
        score = 100; 
        GameObject.Find("ScoreText").GetComponent<Text>().text = "SCORE " + score;
        GameObject.Find("TimerText").GetComponent<Text>().text = "TIME " + Mathf.Floor(timer);

        //speedOn = true;


        
    }

    public void Update() //this will need to be altered for phase II 
    {

      

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            GameObject.Find("TimerText").GetComponent<Text>().text = "TIME " + Mathf.Floor(timer);
        }
        else if (timer < 0)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string currentSceneName = currentScene.name;

            //if (currentSceneName == "8_Contra_Counter")
            //{
            //    SendtoSheetsScript.scoreLogStorage.endCCLevel();

            //        SceneManager.LoadScene("9_End_of_Game");
            //}
            //else
            //{
            //    SceneManager.LoadScene("Level_Introduction");
            //}


            if (currentSceneName == "1_Direct_Intuitive")
            {
                SendtoSheetsScript.scoreLogStorage.endDILevel();
                SendtoSheetsScript.scoreLogStorage.DIScoreStore(score);

                SceneManager.LoadScene("ScoreIntro2CI");
            }

            //if (currentSceneName == "1_Direct_Intuitive")
            //{
            //    SendtoSheetsScript.scoreLogStorage.endDILevel();

            //    SceneManager.LoadScene("2_Contra_Intuitive");
            //}

            else if (currentSceneName == "2_Contra_Intuitive")
            {
                SendtoSheetsScript.scoreLogStorage.endCILevel();
                SendtoSheetsScript.scoreLogStorage.CIScoreStore(score);

                SceneManager.LoadScene("ScoreIntro3DA");
            }

            else if (currentSceneName == "3_Direct_Abstract")
            {
                SendtoSheetsScript.scoreLogStorage.endDALevel();
                SendtoSheetsScript.scoreLogStorage.DAScoreStore(score);

                SceneManager.LoadScene("ScoreIntro4CA");
            }

            else if (currentSceneName == "4_Contra_Abstract")
            {
                SendtoSheetsScript.scoreLogStorage.endCALevel();
                SendtoSheetsScript.scoreLogStorage.CAScoreStore(score);

                SceneManager.LoadScene("ScoreIntro5DS");
            }

            else if (currentSceneName == "5_Direct_Symbolic")
            {
                SendtoSheetsScript.scoreLogStorage.endDSLevel();
                SendtoSheetsScript.scoreLogStorage.DSScoreStore(score);

                SceneManager.LoadScene("ScoreIntro6CS");
            }

            else if (currentSceneName == "6_Contra_Symbolic")
            {
                SendtoSheetsScript.scoreLogStorage.endCSLevel();
                SendtoSheetsScript.scoreLogStorage.CSScoreStore(score);

                SceneManager.LoadScene("ScoreIntro7DC");
            }

            else if (currentSceneName == "7_Direct_Counter")
            {
                SendtoSheetsScript.scoreLogStorage.endDCLevel();
                SendtoSheetsScript.scoreLogStorage.DCScoreStore(score);

                SceneManager.LoadScene("ScoreIntro8CC");
            }

            else if (currentSceneName == "8_Contra_Counter")
            {
                SendtoSheetsScript.scoreLogStorage.endCCLevel();
                SendtoSheetsScript.scoreLogStorage.CCScoreStore(score);

                SceneManager.LoadScene("9_End_of_Game");
            }

        }

        //if (score >= speedUpTime && speedOn)
        //{
        //    //GameObject manager = GameObject.FindGameObjectWithTag("Manager"); 
            
        //    Debug.Log("I tried to change the speed to faster");
        //    speedOn = false; 
        //}
    }
    


    public void ScoreRuleInc()
    {
        score = score + 20;

        //updates score in the canvas UI score text 
        GameObject.Find("ScoreText").GetComponent<Text>().text = "SCORE " + score;

        
    }

    public void ScoreNullInc()
    {
        score = score + 10;

        Debug.Log("Increased the score by 10 for Zone 0 null");
        //updates score in the canvas UI score text 
        GameObject.Find("ScoreText").GetComponent<Text>().text = "SCORE " + score;
    }

    public void ScoreDec()
    {
        score = score - 20;

        //updates score in the canvas UI score text 
        GameObject.Find("ScoreText").GetComponent<Text>().text = "SCORE " + score;
    }

    



}
