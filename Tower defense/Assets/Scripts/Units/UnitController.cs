using System;
using System.Collections;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private UnitStats unitStats;
    private Rigidbody2D rb;
    private Animator anim;

    public Transform target;

    private void Start()
    {
        unitStats = GetComponent<UnitStats>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        bool moveCond = target != null && ((target.tag.Contains("Team") && Vector2.Distance(transform.position, target.position) > unitStats.GetRadius()) || (target.tag.Contains("Tower") && Vector2.Distance(transform.position, target.position) > unitStats.GetTowerRadius()));
        if (moveCond)
        {
            anim.SetBool("Move", true);
            if (target.position.x > transform.position.x)
            {
                rb.velocity = Vector3.right * unitStats.GetSpeed() * Time.deltaTime;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                rb.velocity = Vector3.left * unitStats.GetSpeed() * Time.deltaTime;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if (target != null && ((target.tag.Contains("Team") && Vector2.Distance(transform.position, target.position) < unitStats.GetRadius()) || (target.tag.Contains("Tower") && Vector2.Distance(transform.position, target.position) < unitStats.GetTowerRadius())))
        {
            anim.SetBool("Move", false);
            Attack();
        }
        else
        {
            anim.SetBool("Move", false);
        }
    }

    private void Attack()
    {
        if (target.GetComponent<ObjStats>().GetHealth() - unitStats.GetDamage() >= 0 || target.GetComponent<ObjStats>().GetHealth() - unitStats.GetDamage() < 0)
        {
            anim.SetTrigger("Attack");
        }
    }

    public void DecreaseEnemyHP()
    {
        if (target != null)
        {
            target.GetComponent<ObjStats>().TakeDamage(unitStats.GetDamage());
        }
    }


    private void UpdateTarget()
    {
        GameObject[] enemies;
        if (gameObject.tag == "FirstTeam")
        {
            enemies = GameObject.FindGameObjectsWithTag("SecondTeam");

            if (enemies.Length == 0)
            {
                enemies = GameObject.FindGameObjectsWithTag("BlueTower");
            }
        }
        else
        {
            enemies = GameObject.FindGameObjectsWithTag("FirstTeam");

            if (enemies.Length == 0)
            {
                enemies = GameObject.FindGameObjectsWithTag("RedTower");
            }
        }

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

            if (nearestEnemy != null)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
    }


}
