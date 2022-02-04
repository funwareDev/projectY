using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour, IAttackable, IDamageable
{
    public Movement Movement { get; set; }
    public Health Health { get; set; }
    public Attacker Attacker { get; set; }

    private Player _player;

    [SerializeField] private float _startFollowingDistance;
    [SerializeField] private float _stopFollowingDistance;
    [SerializeField] private float _attackDistance;


    private void Awake()
    {
        Movement = GetComponent<Movement>();
        Health = GetComponent<Health>();
        Attacker = GetComponent<Attacker>();

        _player = FindObjectOfType<Player>();
    }

    private  void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.transform.position);
        float direction = (_player.transform.position - transform.position).normalized.x;

        if (distanceToPlayer <= _startFollowingDistance && distanceToPlayer > _stopFollowingDistance)
        {
            Movement.Move(direction);
        }

        if (distanceToPlayer <= _attackDistance) 
        {
            Attack();
        }
    }

    public void Attack()
    {
        Attacker.TryAttack();
    }

    public void TakeDamage(float damage)
    {
        Health.TakeDamage(damage);
    }
}
