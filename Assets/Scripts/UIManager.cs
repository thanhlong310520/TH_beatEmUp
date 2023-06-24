using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MyMonoBehaviour
{
    [SerializeField] Image playerHealth;
    [SerializeField] Transform player;

    protected override void Start()
    {
        base.Start();
        playerHealth.fillAmount = 1f;
    }
    protected override void Update()
    {

        GetPlayerHp();
    }
    void GetPlayerHp()
    {
        int playHp = player.GetComponentInChildren<PlayerCtrl>().PlayerDamageRecciecer.GetHp();
        int playHpMax = player.GetComponentInChildren<PlayerCtrl>().PlayerDamageRecciecer.GetHpMax();

        playerHealth.fillAmount = (float)playHp / playHpMax;
    }


}
