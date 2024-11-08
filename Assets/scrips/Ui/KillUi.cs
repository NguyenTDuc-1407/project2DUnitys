using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillUi : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void UpdateKilled(int currentKilled)
    {
        text.text = currentKilled.ToString();
    }
}
