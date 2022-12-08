using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float hp { get; set; }
    void TakeDamage(GameObject attacker, int damage);
}
