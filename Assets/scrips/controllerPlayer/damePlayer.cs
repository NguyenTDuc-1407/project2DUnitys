using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamePlayer : MonoBehaviour
{
    Player playerr;
    [SerializeField] int minDamage;
    [SerializeField] int maxDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerr = other.GetComponent<Player>();
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
