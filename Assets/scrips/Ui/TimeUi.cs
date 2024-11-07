using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUi : MonoBehaviour
{
    public TextMeshProUGUI textTimer;

    public void TimeGame(int minute, int second)
    {
        textTimer.text = minute.ToString() + ":" + second.ToString();
    }

}
