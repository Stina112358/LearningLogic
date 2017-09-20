using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreIntroCIScript : MonoBehaviour
{



    public void OnClicked()
    {
        SceneManager.LoadScene("2_Contra_Intuitive");
    }
}