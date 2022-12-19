using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestController : MonoBehaviour
{
    public Vector2 Direction;

    public Rigidbody2D RB;
    public float JumpForce = 100.0f;
    public float Speed = 100.0f;
    public void Update()
    {
        transform.Translate(Direction * 10 * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext move)
    {
        Direction = move.ReadValue<Vector2>();
        
    }

    public void Jump(InputAction.CallbackContext move)
    {
        RB.AddForce(transform.up * JumpForce * Speed);
    }
    
    public void Attack(InputAction.CallbackContext attack)
    {
        Debug.Log("Attack");
    }
}
