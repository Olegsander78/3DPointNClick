using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;
    private float lastAttackTime;
    [SerializeField] private GameObject attackPrefab;

    public static Player Current;

    private void Awake()
    {
        Current = this;
    }
    private void Update()
    {
        if (target != null)
        {
            float targetDistance = Vector3.Distance(transform.position, target.transform.position);

            if (targetDistance < attackRange)
            {
                Controller.StopMovement();
                Controller.LookTowards(target.transform.position - transform.position);

                if (Time.time - lastAttackTime > attackRate)
                {
                    lastAttackTime = Time.time;
                    GameObject proj = Instantiate(attackPrefab, transform.position + Vector3.up, Quaternion.LookRotation(target.transform.position - transform.position));
                    proj.GetComponent<Projectile>().Setup(this);
                }
            }
            else
            {
                Controller.MoveToTarget(target.transform);
            }
        }
    }
}
