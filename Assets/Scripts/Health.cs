using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

   [SerializeField] private int _health;
    // Start is called before the first frame update
    void Start()
    {
        _health = _maxHealth;
    }

    public void DealDamage(int damage)
    {
        if (_health == 0) { return; }
        _health = Mathf.Max(_health - damage, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
