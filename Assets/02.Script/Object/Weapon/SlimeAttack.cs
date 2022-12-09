using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : Weapon
{
    private void Start()
    {
        _damage = transform.root.GetComponent<Monster>()._atk * 3f;
        _basicDamage = _damage;
        _spellProbability = 20;
    }
}
