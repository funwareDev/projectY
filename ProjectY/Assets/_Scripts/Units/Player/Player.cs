using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour, IAttackable, IDamageable
{
    public Movement Movement { get; set; }
    public Health Health { get; set; }
    public Attacker Attacker { get; set; }

    private void Awake()
    {
        Movement = GetComponent<Movement>();
        Health = GetComponent<Health>();
        Attacker = GetComponent<Attacker>();
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}
