using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameEnemy : MonoBehaviour
{
    [SerializeField] int minDamage;
    [SerializeField] int maxDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            int damage = Random.Range(minDamage, maxDamage);
            other.GetComponent<Enemy>().takeDamageEnemy(damage);
        }
    }
}
