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
    private int _currentWeaponIndex = 0;
    private Weapon _currentWeapon;
    private Animator _animator;

    public event Action<int, int> HealthChenged;
    public event Action<int> MoneyChenged;

    public int Money { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _health = _maxHealth;
        ChengeWeapon(_weapons[_currentWeaponIndex]);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    private void ChengeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    public void AddMoney(int reward)
    {
        Money += reward;
        MoneyChenged?.Invoke(Money);
    }

    public void TakeDamage(int damage)
    {
        int minHealth = 0;

        _health -= Mathf.Clamp(damage, minHealth, _maxHealth);

        HealthChenged?.Invoke(_health, _maxHealth);

        if (_health <= 0)
            Destroy(gameObject);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
        MoneyChenged?.Invoke(Money);
    }

    public void NextWeapon()
    {
        if (_currentWeaponIndex == _weapons.Count - 1)
        {
            _currentWeaponIndex = 0;
        }
        else
        {
            _currentWeaponIndex++;
        }

        ChengeWeapon(_weapons[_currentWeaponIndex]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponIndex == 0)
        {
            _currentWeaponIndex = _weapons.Count - 1;
        }
        else
        {
            _currentWeaponIndex--;
        }

        ChengeWeapon(_weapons[_currentWeaponIndex]);
    }


}
