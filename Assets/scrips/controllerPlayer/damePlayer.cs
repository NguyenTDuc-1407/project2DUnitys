using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damePlayer : MonoBehaviour
{
    player playerr;
    [SerializeField] int minDamage;
    [SerializeField] int maxDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerr = other.GetComponent<player>();
            InvokeRepeating("damagePlayer", 0, 0.3f);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerr = null;
            CancelInvoke("damagePlayer");
        }
    }
    void damagePlayer()
    {
        int damage = Random.Range(minDamage, maxDamage);
        playerr.takeDamage(damage);
    }

}
