using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelSet : MyMonoBehaviour
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
    public void EndHitAnim()
    {
        playerCtrl.PlayerDamageSender.UpdateAnim();
    }
    public void Damage()
    {
        playerCtrl.PlayerDamageSender.SenDamage();
    }
}
