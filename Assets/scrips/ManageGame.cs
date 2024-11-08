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
    [SerializeField] health healthBar;
    [SerializeField] KillUi KillUi;
    public Timer timerClass;
    public Player playerClass;
    public Kill killClass;
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
    private void Update()
    {
        DamagePlayer();
        KillEnemy();
        if (nowHp == 0)
        {
            UpdateGameState(GameState.end);
        }
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
    end

}

