using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSender : DamageSender
{
    [SerializeField] float radius;
    [SerializeField] LayerMask whatIsLayerMask;

    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected bool checkHit;
    bool canHit;
    Collider2D[] enemies;
    // Start is called before the first frame update
    protected override void Start()
    {
        canHit = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        Hit();
        GetInput();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
        LoadLayerMask();

    }
    protected override void ResetValues()
    {
        base.ResetValues();
        radius = 0.5f;
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = transform.parent.GetComponentInChildren<PlayerCtrl>();
    }
    protected virtual void LoadLayerMask()
    {
        whatIsLayerMask = LayerMask.GetMask("Enemy");
    }
    protected virtual void Hit()
    {
        if (canHit)
        {
            if (checkHit)
            {
                UpdateAnim();
                enemies = Physics2D.OverlapCircleAll(transform.position, radius, whatIsLayerMask);
            }
        }
    }

    protected virtual void GetInput()
    {
       checkHit = InputManager.Instance.InputPlayerHit();
    }
    public void UpdateAnim()
    {
        canHit = !canHit;
        playerCtrl.ModelAnim.SetBool("hit", checkHit);
        playerCtrl.PlayerMovement.UpdateCan(!checkHit);
    }
    public void SenDamage()
    {
        if(enemies != null)
        {
            foreach (var enemy in enemies)
            {
                Send(enemy.transform,transform.parent);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
