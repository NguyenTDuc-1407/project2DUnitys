using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public int currentKilled = 0;
    public void UpdateKill()
    {
        currentKilled++;
        FindObjectOfType<ManageGame>().UpdateGameState(GameState.KillEnemy);
    }
}
