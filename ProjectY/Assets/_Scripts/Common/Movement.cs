using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float _speed;

    [Header("Jump")]
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _checkGroundRadius;


    [Header("Stamina")]
    [SerializeField] private float _maxStamina;
    [SerializeField] private float _currentStamina;

    [Header("Required components")]
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float moveDirection)
    {
        _rigidbody2D.velocity = new Vector2(moveDirection * _speed, _rigidbody2D.velocity.y);
        Flip(moveDirection);
    }

    public void Jump()
    {
        if (IsOnGround()) 
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpHeight);
        }
    }

    private bool IsOnGround() 
    {
        return Physics2D.OverlapCircle(_groundChecker.position, _checkGroundRadius, _groundLayer);
    }
    private void Flip(float direction)
    {
        if (direction == 0f) return;
        transform.rotation = direction < 0f ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.Euler(0f, 0f, 0f);
    }
}
