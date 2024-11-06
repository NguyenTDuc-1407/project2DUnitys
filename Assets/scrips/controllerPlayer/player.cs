using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] int maxHp;
    [SerializeField] int nowHp;
    [SerializeField] health healthBar;
    public float moveSpeed = 5f;
    bool checkDead = false;
    Vector3 moveInput;
    [SerializeField] Animator animator;
    [SerializeField]GameObject weapon;
    void Start()
    {
        nowHp = maxHp;
        healthBar.updateBar(nowHp, maxHp);
        animator = GetComponent<Animator>();
    }

    public void takeDamage(int damage)
    {
        nowHp -= damage;
        if (nowHp <= 0)
        {
            nowHp = 0;
            healthBar.updateBar(nowHp, maxHp);
            checkDead = true;
            if (checkDead == true)
            animator.SetBool("checkDead", false);
            {
                Destroy(weapon,0);
                Destroy(this.gameObject, 0.5f);
            }
        }
        healthBar.updateBar(nowHp, maxHp);

    }

    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        animator.SetFloat("speed", moveInput.sqrMagnitude);
        transform.position += moveInput * moveSpeed * Time.deltaTime;
        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }

    }
}
