using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRuleHighlightScript : MonoBehaviour {

    
    public PauseScript pauser;

   

    public void OnMouseDown()
    {
        
        pauser.Pause(false);
        

        GetComponent<Outline>().enabled = false;
        
        
    }
}
