using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MyMonoBehaviour
{
    [SerializeField] protected Animator modelAnim;
    public Animator ModelAnim => modelAnim;

    [SerializeField] protected PlayerDamageSender playerDamage;
    public PlayerDamageSender PlayerDamageSender => playerDamage;

    [SerializeField] protected PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;

    [SerializeField] protected PlayerKnockBack playerKnockBack;
    public PlayerKnockBack PlayerKnockBack => playerKnockBack;

    [SerializeField] protected PlayerDamageRecciecer playerDamageRecciecer;
    public PlayerDamageRecciecer PlayerDamageRecciecer => playerDamageRecciecer;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModelAnim();
        LoadPlayerDamageSender();
        LoadPlayerMovement();
        LoadPlayerKnockBack();
        LoadPlayerDamageRecciever();
    }

    protected virtual void LoadModelAnim()
    {
        Transform model = transform.parent.Find("Model");
        if (modelAnim != null) return;
        modelAnim = model.GetComponent<Animator>();
        Debug.Log("load modelAnim" + modelAnim);
    }
    protected virtual void LoadPlayerDamageSender()
    {
        if (playerDamage != null) return;
        playerDamage = transform.parent.GetComponentInChildren<PlayerDamageSender>();
        Debug.Log("load playerDamageSender " + playerDamage);
    }
    protected virtual void LoadPlayerMovement()
    {
        if (playerMovement != null) return;
        playerMovement = transform.parent.GetComponentInChildren<PlayerMovement>();
        Debug.Log("load playerDamageSender " + playerMovement);
    }
    protected virtual void LoadPlayerKnockBack()
    {
        if (playerKnockBack != null) return;
        playerKnockBack = transform.parent.GetComponentInChildren<PlayerKnockBack>();
    }

    protected virtual void LoadPlayerDamageRecciever()
    {
        if (playerDamageRecciecer != null) return;
        playerDamageRecciecer = transform.parent.GetComponentInChildren<PlayerDamageRecciecer>();
    }
} 
