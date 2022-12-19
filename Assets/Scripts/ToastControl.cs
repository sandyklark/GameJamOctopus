using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class ToastControl : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 8f;
    
    private List<Rigidbody2D> _rigidbodies;
    private bool _shouldJump;

    private float _jumpCooldownSeconds = 1f;
    private float _lastJumpTime;
    private Vector2 _moveDirection;

    public void Move(InputAction.CallbackContext move)
    {
        _moveDirection = move.ReadValue<Vector2>();
    }
    
    public void Jump(InputAction.CallbackContext action)
    {
        _shouldJump = true;
    }
    
    private void Awake()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody2D>().ToList();
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     _shouldJump = true;
        // }
    }

    private void FixedUpdate()
    {
        var didJump = false;
        // var moveVector = new Vector2();
        //
        // if (Input.GetKey(KeyCode.A))
        // {
        //     moveVector.x = -1;
        // }
        //
        // if (Input.GetKey(KeyCode.D))
        // {
        //     moveVector.x = 1;
        // }
        
        _rigidbodies.ForEach(rigid =>
        {
            rigid.AddForce(_moveDirection * moveSpeed, ForceMode2D.Force);

            if (_shouldJump && Time.realtimeSinceStartup > _lastJumpTime + _jumpCooldownSeconds)
            {
                rigid.velocity = Vector2.up * jumpForce;
                didJump = true;
            }
        });

        if(didJump) _lastJumpTime = Time.realtimeSinceStartup;
        _shouldJump = false;
    }
}
