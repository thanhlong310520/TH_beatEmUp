using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MyMonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float direction = 1;
    [SerializeField] protected Transform model;
    float move;
    [SerializeField]float inpDirection = 1;
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
        LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.parent.Find("Model");
        Debug.Log("load model " + model);
    }

    protected override void Update()
    {
        base.Update();
        GetInput();
        CheckFlip();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    protected virtual void Movement()
    {
        if ( move != 0)
        {
            Vector3 pos = transform.parent.position;
            pos.x += move * speed * Time.deltaTime;
            transform.parent.position = pos;
            
        }
    }

    protected virtual void Flip()
    {
        Vector3 setScale = model.transform.localScale;
        setScale.x *= -1;
        model.transform.localScale = setScale;
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
}
