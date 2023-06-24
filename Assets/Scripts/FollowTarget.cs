using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MyMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 7f;
    [SerializeField] Vector3 diff;
    [SerializeField] float direction = 1f;
    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if(InputManager.Instance.InputMovement()*direction < 0)
        {
            direction *= -1;
            diff.x *= -1;
        } 
        transform.position = Vector3.Lerp(transform.position, this.target.position + diff, speed * Time.fixedDeltaTime);
    }
}
