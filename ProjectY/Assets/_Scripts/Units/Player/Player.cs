using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour, IAttackable, IDamageable
{
    public PlayerInput PlayerInput { get; private set; }

    public Movement Movement { get; private set; }
    public Health Health { get; private set; }
    public Attacker Attacker { get; private set; }

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private UIInventory _uiInventory;


    private void Awake()
    {
        PlayerInput = new PlayerInput();

        PlayerInput.Player.Jump.performed += context => OnJump();
        PlayerInput.Player.Attack.performed += context => Attack();

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
        Attacker.TryAttack();
    }

    public void TakeDamage(float damage)
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
        transform.rotation = direction < 0f ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.Euler(0f, 0f, 0f);
    }
}
