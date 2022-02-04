using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float _damage;
    [SerializeField] private float _radius;
    [SerializeField] private float _cooldown;

    [Header("Attack transforms")]
    [SerializeField] private Transform _rightHand;
    [SerializeField] private Transform _leftHand;

    private float _lastAttackTime;

    public void TryAttack() 
    {
        if (Time.time < _lastAttackTime + _cooldown)
            return;

        List<Collider2D> colliders = new List<Collider2D>(Physics2D.OverlapCircleAll(_rightHand.position, _radius));
        List<IDamageable> enemies = new List<IDamageable>();

        foreach(var collider in colliders)
        {
            if (collider.TryGetComponent(out IDamageable target))
            {
                enemies.Add(target);
            }
        }

        foreach (var target in enemies)
        {
            target.TakeDamage(_damage);
        }

        _lastAttackTime = Time.time;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_rightHand.position, _radius);
    }
}
