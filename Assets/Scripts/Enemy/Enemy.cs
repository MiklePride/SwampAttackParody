using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Player _target;

    public event Action<Enemy> Died;

    public Player Target => _target;
    public int Reward => _reward;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
            Died?.Invoke(this);
        }
    }

    public void Init(Player target)
    {
        _target = target;
    }
}
