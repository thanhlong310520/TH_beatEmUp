using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageRecciecer : DamageRecceiver
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = transform.parent.GetComponentInChildren<PlayerCtrl>();
    }
    public override void Deduct(int deduct, Transform val)
    {
        base.Deduct(deduct, val);
        playerCtrl.PlayerKnockBack.KB(val);
    }
}
