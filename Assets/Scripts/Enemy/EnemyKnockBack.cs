using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockBack : KnockBack
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

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

    protected override void SetIsKnockBack()
    {
        enemyCtrl.EnemyMovement.IsKnockBack();
    }
}
