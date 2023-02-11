using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] float _healthLevel;
    [SerializeField] float _maxHealth;
    [SerializeField] float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;    }
}
