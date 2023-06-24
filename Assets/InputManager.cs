using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MyMonoBehaviour
{
    [SerializeField] protected static InputManager instance;
    public static InputManager Instance => instance;
    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    protected override void Update()
    {
        base.Update();
        InputMovement();
    }
    public float InputMovement()
    {
        return Input.GetAxis("Horizontal");
    }
    public bool InputPlayerHit()
    {
        if (Input.GetKeyDown(KeyCode.F))
            return true;
        return false;
    }
}
