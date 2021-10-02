#define TESTING

/*==============================================================*/
/*  This script holds input events to be used by other scripts  */
/*==============================================================*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    public event Func<float, float> HorzInput;

    public event Action JumpInput;
    
    /*  Singleton start */
    public static PlayerInputSystem instance;
    private void Awake() { instance = this; }
    /*  Singleton end   */

    void Update()
    {
        Jump();
        HorizontalMovement();
    }


    void Jump()
    {
        if (Input.GetKeyDown("w"))
            JumpInput?.Invoke();
    }

    void HorizontalMovement()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            HorzInput(Input.GetAxisRaw("Horizontal"));
        }
    }

#if TESTING
    public void JumpTest()
    {
        JumpInput?.Invoke();
    }
#endif

}

