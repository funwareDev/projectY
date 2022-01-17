using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour, IAttackable, IDamageable
{
    public PlayerInput PlayerInput { get; private set; }

    public Movement Movement { get; set; }
    public Health Health { get; set; }
    public Attacker Attacker { get; set; }

    [SerializeField] private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        PlayerInput = new PlayerInput();

        PlayerInput.Player.Jump.performed += context => OnJump();

        Movement = GetComponent<Movement>();
        Health = GetComponent<Health>();
        Attacker = GetComponent<Attacker>();
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = PlayerInput.Player.Move.ReadValue<Vector2>();
        float horizontalNormalized = (moveDirection * Vector2.right).normalized.x;

        Flip(horizontalNormalized);
        Movement.Move(horizontalNormalized);
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }

    public void OnJump()
    {
        Movement.Jump();
    }

    private void Flip(float direction)
    {
        if (direction == 0f) return;
        _spriteRenderer.flipX = direction > 0f ? false : true;
    }
}
