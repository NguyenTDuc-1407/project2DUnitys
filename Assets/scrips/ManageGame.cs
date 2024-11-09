using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{
    public static ManageGame instance;
    public GameState state;
    public static event Action<GameState> onGameStateChanged;
    [SerializeField] Health healthBar;
    [SerializeField] KillUi KillUi;
    public Timer timerClass;
    public Player playerClass;
    public Kill killClass;
    // public Enemy enemyClass;
    [SerializeField] public int maxHp;
    public int currentKilled = 0;
    int nowHp;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        UpdateGameState(GameState.start);
    }
    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            case GameState.start:
                StartCoroutine(timerClass.StartTimer());
                PlayerHealth();
                break;
            case GameState.damePlayer:
                DamagePlayer();
                break;
            case GameState.KillEnemy:
                KillEnemy();
                break;
            // case GameState.hpEnemy:
            //     EnemyHealth();
                // break;
            case GameState.end:
                EndGame();
                break;

        }
        onGameStateChanged?.Invoke(newState);
    }
    void PlayerHealth()
    {
        playerClass.playerHp = maxHp;
        if (healthBar != null)
        {
            healthBar.updateBar(playerClass.playerHp, maxHp);
        }
    }
    void DamagePlayer()
    {
        nowHp = playerClass.playerHp;
        if (healthBar != null)
        {
            healthBar.updateBar(nowHp, maxHp);
        }
    }

    // void EnemyHealth()
    // {
    //     enemyClass.nowHpEnemy = enemyClass.maxHpEnemy;
    //     if (healthBar != null)
    //     {
    //         healthBar.hpEnemy(enemyClass.nowHpEnemy, enemyClass.maxHpEnemy);
    //     }

    // }
    // void DamageEnemy()
    // {

    // }
    void KillEnemy()
    {
        currentKilled = killClass.currentKilled;
        KillUi.UpdateKilled(currentKilled);
    }
    public void EndGame()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(2);
    }
}
public enum GameState
{
    start,
    damePlayer,
    hpEnemy,
    KillEnemy,
    end

}

