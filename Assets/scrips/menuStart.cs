using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public void gameStart()
    {
        SceneManager.LoadScene(1);
    }
    public void gameExit()
    {
        Application.Quit();
    }
    public void gameRestart(){
        SceneManager.LoadScene(0);
    }
}
