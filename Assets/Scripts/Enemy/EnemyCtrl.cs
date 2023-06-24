using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MyMonoBehaviour
{
    [SerializeField] Animator modelAnim;
    public Animator ModelAnim => modelAnim;

    [SerializeField] protected EnemyKnockBack knockBack;
    public KnockBack KnockBack => knockBack;

    [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement EnemyMovement => enemyMovement;

    [SerializeField] protected EnemyDamageRecceiver enemyDamageRecceiver;
    public EnemyDamageRecceiver EnemyDamageRecceiver => enemyDamageRecceiver;

    [SerializeField] protected EnemyDamageSender enemyDamageSender;
    public EnemyDamageSender EnemyDamageSender => enemyDamageSender;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadKnockBack();
        LoadEnemyMovement();
        LoadModelAnim();
        LoadEnemyDamageRecciever();
        LoadEnemyDamageSender();
    }

    private void LoadModelAnim()
    {
        Transform model = transform.parent.Find("Model");
        if (modelAnim != null) return;
        modelAnim = model.GetComponent<Animator>();
    }

    protected virtual void LoadKnockBack()
    {
        if (knockBack != null) return;
        knockBack = transform.parent.GetComponentInChildren<EnemyKnockBack>();
    }
    protected virtual void LoadEnemyMovement()
    {
        if (enemyMovement != null) return;
        enemyMovement = transform.parent.GetComponentInChildren<EnemyMovement>();
    }

    protected virtual void LoadEnemyDamageRecciever()
    {
        if (enemyDamageRecceiver != null) return;
        enemyDamageRecceiver = transform.parent.GetComponentInChildren<EnemyDamageRecceiver>();
    }
    protected virtual void LoadEnemyDamageSender()
    {
        if (enemyDamageSender != null) return;
        enemyDamageSender = transform.parent.GetComponentInChildren<EnemyDamageSender>();
    }
}
