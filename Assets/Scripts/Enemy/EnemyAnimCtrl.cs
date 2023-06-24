using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimCtrl : MyMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void Update()
    {
        base.Update();
        UpdateAnim();
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
    protected virtual void UpdateAnim()
    {
        enemyCtrl.ModelAnim.SetBool("canMove", enemyCtrl.EnemyMovement.GetCanMove());
        enemyCtrl.ModelAnim.SetBool("isDead", enemyCtrl.EnemyDamageRecceiver.GetIsDead());
        enemyCtrl.ModelAnim.SetBool("isAttack", enemyCtrl.EnemyDamageSender.GetIsAttack());
    }
}
