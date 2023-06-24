using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KnockBack : MyMonoBehaviour
{
    [SerializeField] Vector2 force;
    [SerializeField] Rigidbody2D rig;
    [SerializeField] float direction;

    protected override void Update()
    {
        base.Update();

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigidbody2d();
    }

    protected virtual void LoadRigidbody2d()
    {
        rig = transform.parent.GetComponent<Rigidbody2D>();
    }
    protected override void ResetValues()
    {
        base.ResetValues();
        force = new Vector2(4, 0);
        direction = 1; 
    }

    public void KB(Transform val)
    {
        SetIsKnockBack();
        if (val.position.x <= transform.parent.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        rig.AddForce(force*direction, ForceMode2D.Impulse);
    }
    protected abstract void SetIsKnockBack();
}
