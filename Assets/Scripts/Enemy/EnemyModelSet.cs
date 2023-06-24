using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModelSet : MyMonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
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
    public void EndAttackAnim()
    {
        enemyCtrl.EnemyDamageSender.SetEndAttack();
    }
    public void SenDamage()
    {
        enemyCtrl.EnemyDamageSender.SendDamage();
    }
}
