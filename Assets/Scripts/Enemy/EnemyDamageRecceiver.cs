using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageRecceiver : DamageRecceiver
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponentInChildren<EnemyCtrl>();
    }

    public override void Deduct(int deduct, Transform val)
    {
        base.Deduct(deduct,val);
        enemyCtrl.KnockBack.KB(val);
    }

}
