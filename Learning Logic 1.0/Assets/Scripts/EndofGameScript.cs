using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EndofGameScript : MonoBehaviour
{
    string DIScore;
    string CIScore;
    string DAScore;
    string CAScore;
    string DSScore;
    string CSScore;
    string DCScore;
    string CCScore;

    // Use this for initialization
    void Awake ()
    {
        DIScore = SendtoSheetsScript.DIScore;
        CIScore = SendtoSheetsScript.CIScore;
        DAScore = SendtoSheetsScript.DAScore;
        CAScore = SendtoSheetsScript.CAScore;
        DSScore = SendtoSheetsScript.DSScore;
        CSScore = SendtoSheetsScript.CSScore;
        DCScore = SendtoSheetsScript.DCScore;
        CCScore = SendtoSheetsScript.CCScore;

        GameObject.Find("InstructionsText").GetComponent<Text>().text = "Congrats! You have reached the end of the game! \n Direct Intuitive Score: " + DIScore + "\n Contrapositive Intuitive Score: " + CIScore + "\n Direct Abstract Score: " + DAScore + "\n Contrapostive Abstract Score: " + CAScore + "\n Direct Symbolic Score: " + DSScore + "\n Contrapositive Symbolic Score: " + CSScore + "\n Direct Counterintuitive Score: " + DCScore + "\n Contrapositive Counterintuitive Score: " + CCScore; 
    
       
    }


}