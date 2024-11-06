using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemy : MonoBehaviour
{
    [SerializeField] int maxHpEnemy;
    [SerializeField] int nowHpEnemy;
    [SerializeField] health healthBar;
    public Seeker seeker;
    public SpriteRenderer enemySR;
    Path path;
    [SerializeField] float moveSpeed;
    [SerializeField] float nextWpDis;
    [SerializeField] bool roaming = true;
    [SerializeField] Animator animator;
    Coroutine move;
    bool checkDead = false;
    bool checkMove = false;
    void Start()
    {
        nowHpEnemy = maxHpEnemy;
        healthBar.hpEnemys(nowHpEnemy, maxHpEnemy);
        animator = GetComponent<Animator>();
        InvokeRepeating("caculatePath", 0f, 0.5f);
    }
    private void Update()
    {
        checkMove = checkDead;
    }
    public void takeDamageEnemy(int damage)
    {
        nowHpEnemy = nowHpEnemy - damage;
        healthBar.hpEnemys(nowHpEnemy, maxHpEnemy);
        if (nowHpEnemy <= 0)
        {
            nowHpEnemy = 0;
            healthBar.hpEnemys(nowHpEnemy, maxHpEnemy);
            checkDead = true;
            animator.SetBool("checkDead", false);
            if (checkDead == true)
            {
                Destroy(this.gameObject, 0.3f);
            }

        }

    }

    //huong di den player
    void caculatePath()
    {
        Vector2 target = findTarget();
        if (seeker.IsDone() && checkMove == false)
        {
            seeker.StartPath(transform.position, target, OnpathCallBack);
        }
        else
        {
            seeker.StartPath(transform.position, transform.position, OnpathCallBack);
        }
    }

    //location player
    Vector2 findTarget()
    {
        Vector3 playPos = FindObjectOfType<player>().transform.position;
        if (roaming == true)
        {
            return (Vector2)playPos + (Random.Range(10f, 50f) * new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized);
        }
        else
        {
            return playPos;
        }
    }
    void OnpathCallBack(Path p)
    {
        if (p.error)
        {
            return;
        }
        path = p;
        moveTager();
    }
    void moveTager()
    {
        if (move != null)
        {
            StopCoroutine(move);
        }
        move = StartCoroutine(moveTagerCoroutine());
    }
    // di chuyen
    IEnumerator moveTagerCoroutine()
    {
        int currentWp = 0;
        while (currentWp < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWp] - (Vector2)transform.position).normalized;
            Vector3 force = direction * moveSpeed * Time.deltaTime;
            transform.position += force;

            float dis = Vector2.Distance(transform.position, path.vectorPath[currentWp]);
            if (dis < nextWpDis)
            {
                currentWp++;
            }
            if (force.x != 0)
            {
                if (force.x < 0)
                {
                    enemySR.transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    enemySR.transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }
            yield return null;
        }
    }
}
