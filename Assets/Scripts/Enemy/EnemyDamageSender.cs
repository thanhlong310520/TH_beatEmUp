using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    [SerializeField] Transform hitbox;
    [SerializeField] float hitboxRange;
    [SerializeField] protected float timeDelayAttack =1f;
    [SerializeField] LayerMask whatIsPlayer;
    [SerializeField]float currentTimeAttack;
    [SerializeField] protected bool canAttack;
    [SerializeField] protected bool isAttack;
    Collider2D player;
    protected override void ResetValues()
    {
        base.ResetValues();
        timeDelayAttack = 0.5f;
        whatIsPlayer = LayerMask.GetMask("Player");
        isAttack = canAttack = false;
        hitboxRange = 0.3f;
        currentTimeAttack = timeDelayAttack;
    }
    protected override void Update()
    {
        base.Update();
        if (!canAttack)
        {
            CheckPlayerInAttackRange();
        }
        else
        {
            if(currentTimeAttack <= 0)
            {
                isAttack = true;
            }
            else
            {
                currentTimeAttack -= Time.deltaTime;
            }
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHitbox();
    }
    private void LoadHitbox()
    {
        hitbox = transform.parent.Find("HitBox");
    }

    protected virtual void CheckPlayerInAttackRange()
    {
        player = Physics2D.OverlapCircle(hitbox.position, hitboxRange, whatIsPlayer);
        if (player != null)
        {
            canAttack = true;
        }
    }

    public bool GetCanAttack()
    {
        return canAttack;
    }
    public bool GetIsAttack()
    {
        return isAttack;
    }
    public void SetEndAttack()
    {
        currentTimeAttack = timeDelayAttack;
        canAttack = false;
        isAttack = false;
    }
    public void SendDamage()
    {
        var reccieverTransform = Physics2D.OverlapCircle(hitbox.position, hitboxRange, whatIsPlayer);
        if (reccieverTransform != null)
        {
            Send(reccieverTransform.transform, transform.parent);
            Debug.Log("Sender damage player " + player);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitbox.position, hitboxRange);
    }
}
 