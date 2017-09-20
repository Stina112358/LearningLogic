using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	public bool paused;
    

    public void PauseStart()
    {
        
        paused = false; //This sets the intial state to going 
        
    }
    public void Pause(bool paused)
    {
        
            
        
        if (paused) //paused = true then we stop 
        {
            Time.timeScale = 0; //rate at which time is passing is 0 (everything time based is stopped)
            Debug.Log("PS I am stopped");
        }
        else if (!paused) //paused = false then we go 
        {
            Time.timeScale = 1; //rate at which time is passing is normal (1x speed)
            Debug.Log("PS I am starting");
        }

        
    }
}
