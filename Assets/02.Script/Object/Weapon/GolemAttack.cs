using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttack : Weapon
{
    private void Start()
    {
        _damage = transform.root.GetComponent<Monster>()._atk * 4f;
        _basicDamage = _damage;
        _spellProbability = 20;
    }
}
