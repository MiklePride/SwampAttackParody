using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons = new List<Weapon>();
    [SerializeField] private int _maxHealth;
    [SerializeField] private Transform _shootPoint;

    private int _health;
    private Weapon _currentWeapon;
    private Animator _animator;

    public event Action<int, int> HealthChenged;

    public int Money { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _health = _maxHealth;
        _currentWeapon = _weapons[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void AddMoney(int reward)
    {
        Money += reward;
    }

    public void TakeDamage(int damage)
    {
        int minHealth = 0;

        _health -= Mathf.Clamp(damage, minHealth, _maxHealth);

        HealthChenged?.Invoke(_health, _maxHealth);

        if (_health <= 0)
            Destroy(gameObject);
    }
}
