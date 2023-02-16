using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    private int damage;
    [SerializeField] private Collider _myCollider;
    private List<Collider> _alreadyCollideWidth = new List<Collider>();


    private void OnEnable()
    {
        _alreadyCollideWidth.Clear();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == _myCollider) { return; }
        
        if (_alreadyCollideWidth.Contains(other)) { return; }
        _alreadyCollideWidth.Add(other);

        if (other.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(10);
        }


    }
        public void SetAttack(int damage)
        {
            this.damage = damage;
        }
}
