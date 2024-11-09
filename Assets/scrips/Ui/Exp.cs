
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Exp : MonoBehaviour
{
    public Image exp;

    public TextMeshProUGUI expText;
    public void updateExp(int currentExp, int requireExp, int currentLevel)
    {
        exp.fillAmount = (float)currentExp / (float)requireExp;
        expText.text = currentExp.ToString() + " / " + requireExp.ToString() + " Level " + currentLevel.ToString();
    }
}
