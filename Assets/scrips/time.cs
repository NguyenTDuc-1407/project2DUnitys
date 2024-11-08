using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TimeUi timeUi;
    int gameMode = 0;
    int time;
    int maxTimer = 0;
    public IEnumerator StartTimer()
    {
        int showTimer = 0;
        if (gameMode == 0) 
        {
             maxTimer = 180;
        }
        int second, minute;
        while (true)
        {
            time++;
            if (gameMode == 0)
            {
                showTimer = maxTimer - time;
                if (time >= maxTimer)
                {
                    FindObjectOfType<ManageGame>().EndGame();
                }
            }
            else
            {
                showTimer = time;
            }
            second = showTimer % 60;
            minute = (showTimer / 60) % 60;
            timeUi.TimeGame(minute, second);
            yield return new WaitForSeconds(1f);
        }
    }
}
