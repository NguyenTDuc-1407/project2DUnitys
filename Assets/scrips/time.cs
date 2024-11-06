using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI textTimer;
    int gameMode = 0;
    int time;
    void Start()
    {
        gameMode = PlayerPrefs.GetInt("gameMode");
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        int showTimer = 0;
        int maxTimer = 0;
        if (gameMode == 0) maxTimer = 300;
        int second, minute;
        while (true)
        {
            time++;
            if (gameMode == 0)
            {
                showTimer = maxTimer - time;
                if (time >= maxTimer)
                {
                    // win
                }
            }
            else
            {
                showTimer = time;
            }

            second = showTimer % 60;
            minute = (showTimer / 60) % 60;
            textTimer.text = minute.ToString() + ":" + second.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
