using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(GooseHead))]
public class GooseControl : MonoBehaviour
{
    [Header("Config")]
    public float moveSpeed = 20f;
    public float jumpForce = 20f;
    [Header("References")]
    public Rigidbody2D footRigid;
    public List<GameObject> objectsToFlip;

    private GooseHead _gooseHead;
    private bool _shouldJump;
    private float _initialOffsetX;
    private float _lastScaleX = 1f;
    private Vector2 _moveDirection;
    private PlayerInput _input;
    private bool _canBite = true;

    private void Awake()
    {
        _gooseHead = GetComponent<GooseHead>();
        _initialOffsetX = _gooseHead.offset.x;
        
        _input = GetComponent<PlayerInput>();
        _input.currentActionMap.FindAction("Move").performed += Move;
        _input.currentActionMap.FindAction("Move").canceled += StopMove;
        _input.currentActionMap.FindAction("Jump").started += Jump;
        _input.currentActionMap.FindAction("Attack").started += Attack;
    }

    private void Move(InputAction.CallbackContext move)
    {
        _moveDirection = move.ReadValue<Vector2>();
    }
    
    private void StopMove(InputAction.CallbackContext move)
    {
        _moveDirection = Vector2.zero;
    }

    private void Jump(InputAction.CallbackContext action)
    {
        if (action.started)
        {
            _shouldJump = true;
        }
    }

    private void Attack(InputAction.CallbackContext action)
    {
        if (!_canBite) return;
        StopAllCoroutines();
        StartCoroutine(DoAttack());
    }
    
    private IEnumerator DoAttack()
    {
        _canBite = false;
        _gooseHead.normalFace.SetActive(false);
        _gooseHead.biteFace.SetActive(true);

        yield return new WaitForSeconds(0.1f);
        
        _gooseHead.biteFace.SetActive(false);
        _gooseHead.normalFace.SetActive(true);
        
        yield return new WaitForSeconds(0.2f);
        _canBite = true;
    }

    private void Update()
    {
        var x = _moveDirection.x;
        var newScaleX = x switch
        {
            > 0 => 1f,
            < 0 => -1f,
            _ => _lastScaleX
        };

        
        objectsToFlip.ForEach(obj =>
        {
            var scale = obj.transform.localScale;
            scale.x = newScaleX;
            obj.transform.localScale = scale;
        });

        if(Math.Abs(newScaleX - _lastScaleX) > 0.5f) _gooseHead.offset.x = _initialOffsetX * newScaleX;
        _lastScaleX = newScaleX;
    }
    
    private void FixedUpdate()
    {
        footRigid.AddForce(_moveDirection * moveSpeed, ForceMode2D.Force);
        
        if (_shouldJump)
        {
            footRigid.velocity = Vector2.up * jumpForce;
            _shouldJump = false;
        }
    }
}
