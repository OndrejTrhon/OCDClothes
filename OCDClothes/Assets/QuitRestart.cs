using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class QuitRestart : MonoBehaviour
{
  public void QuitGame () {
            Application.Quit ();
             Debug.Log("Game is exiting");
            //Just to make sure its working
    
}
    public void RestartGame() {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

    }

}
