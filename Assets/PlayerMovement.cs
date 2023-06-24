using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MyMonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float direction = 1;
    [SerializeField] protected PlayerCtrl playerCtrl;
    float move;
    float inpDirection = 1;
    [SerializeField] bool canFlip;
    [SerializeField] bool canMove;
    protected override void Start()
    {
        canFlip = canMove = true;
        inpDirection = 1;
        direction = 1;
        base.Start();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }
    protected override void ResetValues()
    {
        base.ResetValues();
        speed = 2f;
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = transform.parent.GetComponentInChildren<PlayerCtrl>();
    }

    protected override void Update()
    {
        base.Update();
        GetInput();
        CheckFlip();
        UpdateAnimation();
    }

    protected virtual void UpdateAnimation()
    {
        playerCtrl.ModelAnim.SetFloat("velocityX", Mathf.Abs(move));
    }

    private void FixedUpdate()
    {
        Movement();
    }
    protected virtual void Movement()
    {
        if (canMove)
        {
            if (move != 0)
            {
                Vector3 pos = transform.parent.position;
                pos.x += move * speed * Time.deltaTime;
                transform.parent.position = pos;

            }
        }
    }

    protected virtual void Flip()
    {
        Vector3 setScale = transform.parent.localScale;
        setScale.x *= -1;
        transform.parent.localScale = setScale;
        direction *= -1;
    }
    protected virtual void GetInput()
    {
        move = InputManager.Instance.InputMovement();
        if(move > 0)
        {
            inpDirection = 1;
        }
        else if(move < 0)
        {
            inpDirection = -1;
        }
    }
    protected virtual void CheckFlip()
    {
        if (canFlip)
        {
            if (direction != inpDirection)
            {
                Flip();
            }
        }
    }
    public void UpdateCan(bool val)
    {
        canMove = val;
        canFlip = val;
    }
}
