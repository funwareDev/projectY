using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Attacker : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float _damage;
    [SerializeField] private float _radius;

    [Header("Attack transforms")]
    [SerializeField] private Transform _rightHand;
    [SerializeField] private Transform _leftHand;


    public void TryAttack() 
    {
        List<Collider2D> colliders = new List<Collider2D>(Physics2D.OverlapCircleAll(_rightHand.position, _radius));
        List<Enemy> enemies = new List<Enemy>();

        foreach(var collider in colliders)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                enemies.Add(enemy);
            }
        }

        foreach (var enemy in enemies)
        {
            enemy.TakeDamage(_damage);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_rightHand.position, _radius);
    }
}
