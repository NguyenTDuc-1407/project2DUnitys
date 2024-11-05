using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float timeShoot = 0.2f;
    public float bulletForce;
    private float timeBtwFire;
    Rigidbody2D rb;
    void Update()
    {
        timeBtwFire -= Time.deltaTime;
        if (Input.GetKeyDown("space") && timeBtwFire < 0)
        {
            fireButter();
        }
    }
    void fireButter()
    {
        timeBtwFire = timeShoot;
        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
