using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MyMonoBehaviour
{
    [SerializeField] Image heal;
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
    protected override void OnEnable()
    {
        heal.fillAmount = 1f;
    }
    protected override void Update()
    {
        base.Update();
        heal.fillAmount = (float)enemyCtrl.EnemyDamageRecceiver.GetHp() / enemyCtrl.EnemyDamageRecceiver.GetHpMax();
    }
}
