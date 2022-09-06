using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public enum State
    {
        Idle,
        Chase,
        Attack
    }

    private State curState = State.Idle;

    [Header("Ranges")]
    [SerializeField] private float chaseRange;
    [SerializeField] private float attackRange;

    [Header("Attack")]
    [SerializeField] private float attackRate;
    private float lastAttackTime;
    [SerializeField] private GameObject attackPrefab;

    private float targetDistance;

    private void Start()
    {
        target = Player.Current;
    }
    private void Update()
    {
        if (target == null)
            return;
        
        targetDistance = Vector3.Distance(transform.position, target.transform.position);

        switch (curState)
        {
            case State.Idle:
                IdleUpdate();
                break;
            case State.Chase:
                ChaseUpdate();
                break;
            case State.Attack:
                AttackUpdate();
                break;
        }
    }
    void SetState(State newState)
    {
        curState = newState;

        switch (curState)
        {
            case State.Idle:
                Controller.StopMovement();
                break;
            case State.Chase:
                Controller.MoveToTarget(target.transform);
                break;
            case State.Attack:
                Controller.StopMovement();
                break;
        }
    }
    void IdleUpdate()
    {
        if (targetDistance < chaseRange && targetDistance > attackRange)
            SetState(State.Chase);
        else if (targetDistance < attackRange)
            SetState(State.Attack);
    }
    void ChaseUpdate()
    {
        if (targetDistance > chaseRange)
            SetState(State.Idle);
        else if (targetDistance < attackRange)
            SetState(State.Attack);
    }
    void AttackUpdate()
    {
        if (targetDistance > attackRange)
            SetState(State.Chase);

        Controller.LookTowards(target.transform.position - transform.position);

        if(Time.time - lastAttackTime > attackRate)
        {
            lastAttackTime = Time.time;
            AttackTarget();
        }

    }
    void AttackTarget()
    {

    }
}
