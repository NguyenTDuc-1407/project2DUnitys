using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dameEnemy : MonoBehaviour
{
    [SerializeField] int Inputdamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            int damage = Inputdamage;
            other.GetComponent<Enemy>().takeDamageEnemy(damage);
        }
    }
}
