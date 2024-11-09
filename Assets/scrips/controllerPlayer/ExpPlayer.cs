using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPlayer : MonoBehaviour
{
    public int currentExp = 0;
    public int currentLevel = 1;
    public int requireExp = 15;
      public void UpdateExperience(int addExp)
    {
        currentExp += addExp;
        FindObjectOfType<ManageGame>().UpdateGameState(GameState.expPlayer);
        if (currentExp >= requireExp)
        {
            currentLevel++;
            currentExp = currentExp - requireExp;
            requireExp = (int)(requireExp * 1.5);
            FindObjectOfType<ManageGame>().UpdateGameState(GameState.expPlayer);
            FindObjectOfType<ManageGame>().UpdateGameState(GameState.UpLevel);
        }   
    }
}
