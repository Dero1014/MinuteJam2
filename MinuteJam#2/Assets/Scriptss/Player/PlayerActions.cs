/*====================================================================*/
/*  This script holds player actions to be executed on input command  */
/*====================================================================*/

//#define DEBUG

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : PlayerComponents
{
    public event Action OnDeath;
    public event Action OnScoreGain;

    [Header("Speed")]
    [SerializeField]
    private float speed;

    [Header("Jumping")]
    [SerializeField]
    private float _jumpHeight;
    [SerializeField]
    [Tooltip("Time to get to maximum height")]
    private float _jumpTime;
    [SerializeField] [Range(0,3)]

    private float _gravity;
    private float _upVelocity;

    private bool _jump = false;

    /*  Singleton start */
    public static PlayerActions instance;
    private void Awake() { instance = this; }
    /*  Singleton end   */

    void Start()
    {
        PlayerInputSystem.instance.JumpInput += JumpEnabled;
        PlayerInputSystem.instance.HorzInput += Direction;
        PlayerJumpSettings();
    }

    private void PlayerJumpSettings()
    {
        // calculate what the gravity and upwards velocity should be in order to get 
        _gravity = (2 * _jumpHeight) / Mathf.Pow(_jumpTime, 2);
        _upVelocity = (2 * _jumpHeight) / _jumpTime;
    }

    private void Update()
    {

    }

    void FixedUpdate()
    {
        PlGravity();
        Jumpy(_jump);
        HorizontalMovement();
        _jump = false;
    }

    private void HorizontalMovement(float dir)
    {

    }


    private void PlGravity()
    {
        _rb.AddForce(Vector2.down * _gravity,ForceMode2D.Force);
    }

    void JumpEnabled()
    {
        //Sound the jump 
        _jump = true;
    }

    void Jumpy(bool jump)
    {
        if (jump)
            _rb.velocity = Vector2.up * _upVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDeath?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnScoreGain?.Invoke();
        // Sound the point 
    }

}
