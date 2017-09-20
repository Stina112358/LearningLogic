using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SendtoSheetsScript : MonoBehaviour {

    string levelLog = "Start,180,100,"; //This initializes the string for the current level. The strings are generated on every sprite death. 
                                        //The triple is (death area, time remaining in level, score after death). 
    string DIScoreLog; //this will store the score log triples string for level DI. It is what will be passed to the google form
    string CIScoreLog;
    string DAScoreLog;
    string CAScoreLog;
    string DSScoreLog;
    string CSScoreLog;
    string DCScoreLog;
    string CCScoreLog;

    public string orderLevels = "IASC"; //this will need to be altered for Phase II 

    public string participantID = "Phase I"; //this will need to be altered for Phase II 
    
    public static SendtoSheetsScript scoreLogStorage;

    public static string DIScore;
    public static string CIScore;
    public static string DAScore;
    public static string CAScore;
    public static string DSScore;
    public static string CSScore;
    public static string DCScore;
    public static string CCScore; 

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSckgrGGWirYCgxvsv4GTTiMojduGul1AUOk2FHfc7LDIRzuqg/formResponse"; 

    void  Awake()
    {
        if (scoreLogStorage == null)
        {
            DontDestroyOnLoad(gameObject);
            scoreLogStorage = this;
        }
        else if(scoreLogStorage != this)
        {
            Destroy(gameObject);
        }
    }
    
       
  
    public void ScoreLogCollectLevel1(string ZoneName) //this function collects all information for the ordered triple
    {
        GameObject scoreTimeManager = GameObject.Find("ScoreManager"); //gets the game object holding the score script
        ScoreScript scoreTime = scoreTimeManager.GetComponent<ScoreScript>(); //gets the score script reference

        float time = scoreTime.timer; //accesses the timer
        int score = scoreTime.score; //accesses the score

        ScoreLogUpdate(ZoneName, time, score); //calls the update function with all three pieces of info
        
    }

    void ScoreLogUpdate(string zone, float time, int score) //This is a running string with all sprite deaths for the level.
        //There is one giant string per level, which is separated by commas. This will then be parsed back out in a CSV. 
        //This passes the collected triple into the giant string. 
    {
        levelLog = levelLog + zone + "," + time + "," + score + ","; //concatenatees on the new information. 
        Debug.Log("Here is the current string: " + levelLog);
    }


    //These functions will indicate that the end of the level has been reached and the next scene has been called to load
    public void endDILevel() // direct intuitive
    {
        ScoreLogUpdate("END OF DI LEVEL", 0, 0);
        DIScoreLog = levelLog;
        levelLog = ""; 
    }

    public void endCILevel() // contra intuitive
    {
        ScoreLogUpdate("END OF CI LEVEL", 0, 0);
        CIScoreLog = levelLog;
        levelLog = "";
    }

    public void endDALevel() // direct abstract
    {
        ScoreLogUpdate("END OF DA LEVEL", 0, 0);
        DAScoreLog = levelLog;
        
        levelLog = "";
       
    }

    public void endCALevel() // contra abstract
    {
        ScoreLogUpdate("END OF CA LEVEL", 0, 0);
        CAScoreLog = levelLog;
        levelLog = "";
    }

    public void endDSLevel() // direct symbolic
    {
        ScoreLogUpdate("END OF DS LEVEL", 0, 0);
        DSScoreLog = levelLog;
        levelLog = "";
    }

    public void endCSLevel() // contra symbolic 
    {
        ScoreLogUpdate("END OF CS LEVEL", 0, 0);
        CSScoreLog = levelLog;
        levelLog = "";
    }

    public void endDCLevel() // direct counter
    {
        ScoreLogUpdate("END OF DC LEVEL", 0, 0);
        DCScoreLog = levelLog;
        levelLog = "";
    }

    public void endCCLevel() // contra counter
    {
        ScoreLogUpdate("END OF CC LEVEL", 0, 0);
        CCScoreLog = levelLog;
        levelLog = "";


        StartCoroutine(publishToGoogle(participantID, orderLevels, DIScoreLog, CIScoreLog, DAScoreLog, CAScoreLog, DSScoreLog, CSScoreLog, DCScoreLog, CCScoreLog));

        Debug.Log("DI " + DIScoreLog);
        Debug.Log("CI " + CIScoreLog);

        
    }


    public void DIScoreStore(int finalScore)
    {
        DIScore =  finalScore.ToString(); 

    }

    public void CIScoreStore(int finalScore)
    {
        CIScore = finalScore.ToString();

    }

    public void DAScoreStore(int finalScore)
    {
        DAScore = finalScore.ToString();

    }

    public void CAScoreStore(int finalScore)
    {
        CAScore = finalScore.ToString();

    }

    public void DSScoreStore(int finalScore)
    {
        DSScore = finalScore.ToString();

    }

    public void CSScoreStore(int finalScore)
    {
        CSScore = finalScore.ToString();

    }

    public void DCScoreStore(int finalScore)
    {
        DCScore = finalScore.ToString();

    }

    public void CCScoreStore(int finalScore)
    {
        CCScore = finalScore.ToString();

    }









    IEnumerator publishToGoogle(string IDNum, string order, string DI, string CI, string DA, string CA, string DS, string CS, string DC, string CC)
    {
       
        WWWForm googleForm = new WWWForm();

        googleForm.AddField("entry.168077649", IDNum);
        googleForm.AddField("entry.1324536078", order);
        googleForm.AddField("entry.26054621", DI);
        googleForm.AddField("entry.1225930362", CI);
        googleForm.AddField("entry.629721891", DA);
        googleForm.AddField("entry.2053158375", CA);
        googleForm.AddField("entry.1129833202", DS);
        googleForm.AddField("entry.1090790740", CS);
        googleForm.AddField("entry.1678311485", DC);
        googleForm.AddField("entry.773959135", CC); 



        byte[] rawData = googleForm.data;


        WWW webAddress = new WWW(BASE_URL, rawData);

        yield return webAddress; 
    
    }



}
