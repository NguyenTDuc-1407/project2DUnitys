using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    bool checkDead = false;
    Vector3 moveInput;
    [SerializeField] public int playerHp;
    [SerializeField] Animator animator;
    [SerializeField] GameObject weapon;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void takeDamage(int damage)
    {
        playerHp -= damage;
        FindObjectOfType<ManageGame>().UpdateGameState(GameState.damePlayer);
        if (playerHp <= 0)
        {
            playerHp = 0;
            checkDead = true;
            if (checkDead == true)
                animator.SetBool("checkDead", false);
            {
                FindObjectOfType<ManageGame>().UpdateGameState(GameState.end);
                Destroy(weapon, 0);
            }
        }
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
