using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreIntroCSScript : MonoBehaviour
{



    public void OnClicked()
    {
        SceneManager.LoadScene("6_Contra_Symbolic");
    }
}