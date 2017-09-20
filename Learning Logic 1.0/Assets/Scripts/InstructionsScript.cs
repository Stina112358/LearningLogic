using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsScript : MonoBehaviour {

    
    int instructionCounter; //keep track of what instruction step we are on
    public Transform[] spawnTypes;
    public Transform[] spawnPoints;
    public Canvas instructionsCanvas;

    //Things I will destroy! 
    GameObject boxObj;
    GameObject rule1;
    GameObject contraRule1; 
    GameObject teachRule;
    GameObject teachContraRule;
    GameObject basketObj; 


    public int catchEmAll;

    public static InstructionsScript catchEmStorage;


    void Awake()
    {
       
            catchEmStorage = this;
        
    }

    //When the Next button is clicked
    public void NextClicked()
    {
        instructionCounter++;
        UpdateInstructionsPage(instructionCounter);
    }

    //When the Back button is clicked
    public void BackClicked()
    {
        if (instructionCounter >= 0)
        {
            instructionCounter--;
            UpdateInstructionsPage(instructionCounter);
        }
        
    }

    
    
    //Which page of instructions to display based on instructionCoutner

    void UpdateInstructionsPage (int instructionCounter)
    {

        if (instructionCounter <= 0)
        {
            SceneManager.LoadScene("0_MainMenu");
           
        //}

        //if (instructionCounter == 0) // Back to Main Menu
        //{
         //   GameObject.Find("InstructionsText").GetComponent<Text>().text = "Welcome to the Learning Logic App! The purpose of this app is to...learn logic.That is, you will be learning how to reason about a conditional statement such as: 'If..., then...' \n Let's start!";
        }

        if (instructionCounter == 1)
        {
            GameObject.Find("InstructionsText").GetComponent<Text>().text = "<i><b>If...</b></i> represents the hypothesis to be satisfied. <i><b>then...</b></i> represents the conclusion that will follow after we satisfy the hypothesis. \n \n Let's Start!";

        }
        if (instructionCounter == 2) // Page 1 instructions
       
        {

            GameObject.Find("InstructionsText").GetComponent<Text>().text = "First, we're going to learn to sort a penguin. Follow this conditional:";
            
            //Generates sprite 0 at spawnpoint 0
            Instantiate(spawnTypes[0], spawnPoints[0].position, spawnPoints[0].rotation); //makes the penguin
            Instantiate(spawnTypes[1], spawnPoints[1].position, spawnPoints[1].rotation); //makes the carbodard box
            var instructText = Instantiate(spawnTypes[2], spawnPoints[2].position, spawnPoints[2].rotation); //makes the conditional 
            instructText.transform.SetParent(GameObject.FindGameObjectWithTag("instructionsCanvas").transform, false); //makes the conditional a child of the Canvas 
            GameObject.Find("NextInstructionButton").GetComponent<Button>().interactable = false;
        }
        if (instructionCounter == 3) // Page 2 instructions
        {
          
            boxObj = GameObject.Find("cardboardBox(Clone)");

            Destroy(boxObj);
            //for (var i = 0; i < gameObjects.Length; i++)
            //{
            //    Destroy(gameObjects[i]);
            //}

            rule1 = GameObject.Find("TutorialRuleText(Clone)");
            Destroy(rule1);


            GameObject.Find("InstructionsText").GetComponent<Text>().text = "When we have a rule like this:";
            var instructText = Instantiate(spawnTypes[4], spawnPoints[4].position, spawnPoints[4].rotation); //makes the conditional 
            instructText.transform.SetParent(GameObject.FindGameObjectWithTag("instructionsCanvas").transform, false); //makes the conditional a child of the Canvas 

        }
        if (instructionCounter == 4)
        {
            GameObject.Find("InstructionsText").GetComponent<Text>().text = "The <i>contrapositive</i> of the rule is: ";
            var instructText = Instantiate(spawnTypes[5], spawnPoints[5].position, spawnPoints[5].rotation); //makes the conditional 
            instructText.transform.SetParent(GameObject.FindGameObjectWithTag("instructionsCanvas").transform, false); //makes the conditional a child of the Canvas 

        }
        if(instructionCounter == 5)
        {
            GameObject.Find("InstructionsText").GetComponent<Text>().text = "In other words, we negate the conclusion, and the negation of the hypothesis follows.";
        }

        if (instructionCounter == 6) // 
        {
            teachRule = GameObject.Find("TeachRuleText(Clone)");
            Destroy(teachRule);

            teachContraRule = GameObject.Find("TeachContraRuleText(Clone)");
            Destroy(teachContraRule);


            GameObject.Find("InstructionsText").GetComponent<Text>().text = "Here is our rule again:";
            var instructText = Instantiate(spawnTypes[2], spawnPoints[4].position, spawnPoints[4].rotation); //makes the conditional 
            instructText.transform.SetParent(GameObject.FindGameObjectWithTag("instructionsCanvas").transform, false); //makes the conditional a child of the Canvas 

        }
        
        if (instructionCounter == 7)
        {
            GameObject.Find("InstructionsText").GetComponent<Text>().text = "And here is the contrapositive of our rule: ";

            var instructText = Instantiate(spawnTypes[3], spawnPoints[5].position, spawnPoints[5].rotation); //makes the contra conditional 
            instructText.transform.SetParent(GameObject.FindGameObjectWithTag("instructionsCanvas").transform, false); //makes the contra conditional a child of the Canvas 

            
        }
        
        if (instructionCounter == 8)
        {
            GameObject.Find("InstructionsText").GetComponent<Text>().text = "This means that we still drag the penguin into the box, but non-penguins must go somewhere else. (How about that basket?)";


            Instantiate(spawnTypes[0], spawnPoints[0].position, spawnPoints[0].rotation); //makes the penguin
            Instantiate(spawnTypes[6], spawnPoints[1].position, spawnPoints[1].rotation); //makes the end game carbodard box

            Instantiate(spawnTypes[9], spawnPoints[8].position, spawnPoints[8].rotation); //makes the basket

            Instantiate(spawnTypes[7], spawnPoints[6].position, spawnPoints[6].rotation); //makes the bear
            Instantiate(spawnTypes[8], spawnPoints[7].position, spawnPoints[7].rotation); //makes the giraffe
        

            GameObject.Find("NextInstructionButton").GetComponent<Button>().interactable = false; //greys out the next button so the collision will have to advance things. 

        }
        if (instructionCounter == 9)
        {
            rule1 = GameObject.Find("TutorialRuleText(Clone)");
            Destroy(rule1);

            contraRule1 = GameObject.Find("ContraTutorialRuleText(Clone)");
            Destroy(contraRule1);

            boxObj = GameObject.Find("cardboardBoxEnd(Clone)");
            Destroy(boxObj);

            basketObj = GameObject.Find("basketEnd(Clone)");
            Destroy(basketObj);


            basketObj = GameObject.Find("InstructionsText");
            Destroy(basketObj);
            //GameObject.Find("InstructionsText").GetComponent<Text>().text = "Excellent! Level one will have rules that are intuitive to you. You will see characters (like the penguin) falling from the top of the screen that satisfy the hypothesis to be sorted into their habitats on the right. New rules will appear on the left as the game progresses. Tap the new rule to make the game continue.";
            Instantiate(spawnTypes[10], spawnPoints[9].position, spawnPoints[9].rotation); //direct intuitive level


        }
        if (instructionCounter == 10)
        {
            basketObj = GameObject.Find("DirectIntuitiveLevelShot(Clone)");
            Instantiate(spawnTypes[11], spawnPoints[9].position, spawnPoints[9].rotation); //makes the giraffe
        }
        
            if (instructionCounter > 10)
        {
            
            SceneManager.LoadScene("ScoreIntro1DI"); //Let's play already!! 
        }
    }

    public void CatchEm()
    {
        catchEmAll++;

        Debug.Log("The current catchEm is: " + catchEmAll);
        
        if (catchEmAll == 3)
        {
            GameObject.Find("NextInstructionButton").GetComponent<Button>().interactable = true;
        }
    }



}
