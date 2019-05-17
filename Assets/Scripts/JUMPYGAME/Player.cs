using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 20f;

    [SerializeField] private float _jumpTimer = 2f;
    private bool _canJump = true;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        HandleJumping();
    }

    private void HandleJumping()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            _rb.AddForce(Vector2.up * _jumpForce);
            _canJump = false;
            StartCoroutine(ResetJump());
        }
    }

    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(_jumpTimer);
        _canJump = true;
    }
}
