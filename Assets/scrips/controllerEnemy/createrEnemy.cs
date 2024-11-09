using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaterEnemy : MonoBehaviour
{
    public GameObject enemyType1;
    public Transform enemyPos;
    private float timeBtwEnemy;
    public float timeEnemy = 0.2f;
    int Countenemy = 0;
    [SerializeField] int limitEnemy;
    void Update()
    {
        timeBtwEnemy -= Time.deltaTime;
        if (timeBtwEnemy < 0 && Countenemy < limitEnemy)
        {
            autoEnemy();
        }
    }
    void autoEnemy()
    {
        timeBtwEnemy = timeEnemy;
        Instantiate(enemyType1, enemyPos.position, Quaternion.identity);
        Countenemy++;
    }
}
