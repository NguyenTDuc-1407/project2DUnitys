using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image hpBar;
    public TextMeshProUGUI hpText;
    public Image hpEnemy;

    public void updateBar(int nowHp, int maxHp){
        hpBar.fillAmount = (float)nowHp / (float)maxHp;
        hpText.text = nowHp.ToString() + " / " + maxHp.ToString();
    }

    public void hpEnemys(int enemyNowHp, int enemyMaxHp){
        hpEnemy.fillAmount = (float)enemyNowHp / (float)enemyMaxHp;
    }

}
