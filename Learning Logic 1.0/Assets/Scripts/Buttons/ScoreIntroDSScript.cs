using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreIntroDSScript : MonoBehaviour
{

    public void OnClicked()
    {
        SceneManager.LoadScene("5_Direct_Symbolic");
    }
}