using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkAttack : Weapon
{
    // Start is called before the first frame update
    private void Start()
    {
        _damage = transform.root.GetComponent<Monster>()._atk * 4f;
        _basicDamage = _damage;
        _spellProbability = 20;
    }
}
