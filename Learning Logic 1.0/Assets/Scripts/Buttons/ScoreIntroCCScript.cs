﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreIntroCCScript : MonoBehaviour
{



    public void OnClicked()
    {
        SceneManager.LoadScene("8_Contra_Counter");
    }
}