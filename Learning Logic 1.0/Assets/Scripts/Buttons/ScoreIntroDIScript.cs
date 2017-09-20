using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreIntroDIScript : MonoBehaviour
{

    public void OnClicked()
    {
        Destroy(GameObject.Find("sumMusicController"));
        SceneManager.LoadScene("1_Direct_Intuitive");
    }
}