using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MyMonoBehaviour
{
    [SerializeField] float distanceLookAtPlayer;
    [SerializeField] LayerMask whatIsPlayer;
    Vector3 playerPos;
    [SerializeField] float speed;
    [SerializeField] int playerDirection;
    [SerializeField] int enemyDirection;


    [SerializeField]bool isKnockback = false;
    [SerializeField] float timeKnockback = 0.5f;
    float currentTimeKnockback;

    bool canMove;

    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void ResetValues()
    {
        base.ResetValues();
        enemyDirection = 1;
        whatIsPlayer = LayerMask.GetMask("Player");
        distanceLookAtPlayer = 5f;
        speed = 1f;
        isKnockback = false;
        timeKnockback = 0.3f;
        currentTimeKnockback = 0f;
        canMove = false;
    }

    protected override void Update()
    {
        base.Update();
        if (IsPlayerInVision())
        {
            CheckFlip();
        }
        if (IsPlayerInVision() && !IsPlayerInAttackRange() && !isKnockback)
        {
            canMove = true;
        }
        else
            canMove = false;
        EndKnockback();
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            Movement();
        }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyCtrl();
    }

   
    private void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponentInChildren<EnemyCtrl>();
    }

    protected virtual bool IsPlayerInVision()
    {
        Collider2D temp = Physics2D.OverlapCircle(transform.parent.position, distanceLookAtPlayer, whatIsPlayer);
        if(temp!= null)
        {
            playerPos = temp.transform.position;
            CheckPlayerPos();
            return true;
        }
        return false;
    }
    protected virtual bool IsPlayerInAttackRange()
    {
        return enemyCtrl.EnemyDamageSender.GetCanAttack();
    }

    protected virtual void Movement()
    {
        Vector3 pos = transform.parent.position;
        pos.x += enemyDirection * speed * Time.fixedDeltaTime;
        transform.parent.position = pos;
    }

    protected virtual void CheckPlayerPos()
    {
        float sup = transform.parent.position.x - playerPos.x;
        if (sup < 0)
        {
            playerDirection = 1;
        }
        else
            playerDirection = -1;
    }

    void Flip()
    {
        Vector3 setScale = transform.parent.localScale;
        setScale.x *= -1;
        transform.parent.localScale = setScale;
        enemyDirection *= -1;
    }
    void CheckFlip()
    {
        if(enemyDirection != playerDirection)
        {
            Flip();
            Debug.Log("quay");
        }
    }

    public void IsKnockBack()
    {
        isKnockback = true;
        currentTimeKnockback = timeKnockback;
    }
    protected void EndKnockback()
    {
        if (isKnockback)
        {
            currentTimeKnockback -= Time.deltaTime;
            if (currentTimeKnockback <= 0)
                isKnockback = false;
        }
    }
    public bool GetCanMove()
    {
        return canMove;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.parent.position, distanceLookAtPlayer);
    }
}
