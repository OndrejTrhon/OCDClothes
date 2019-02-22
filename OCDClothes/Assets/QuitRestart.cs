﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class QuitRestart : MonoBehaviour
{

    public GameObject ScoreScreen;
    public GameObject Outro1;
    public GameObject Outro2;
    public GameObject Score_pct_texts;


  public void QuitGame () {
      ShowOutro1();
      Invoke("ShowOutro2",6);
      Invoke("Quit",9);
    
}
    public void RestartGame() {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

    }

    public void ShowOutro1() {
        ScoreScreen.SetActive(false);
        Score_pct_texts.SetActive(false);
        Outro1.SetActive(true);
                    
    }

    public void ShowOutro2() {
        Outro1.SetActive(false);
        Outro2.SetActive(true);
                    
    }

    public void Quit() {
         Application.Quit ();
             Debug.Log("Game is exiting");
    }

}
