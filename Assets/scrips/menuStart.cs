using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuStart : MonoBehaviour
{
    public void gameStart()
    {
        SceneManager.LoadScene(1);
    }
    public void gameExit()
    {
        Application.Quit();
    }

}
