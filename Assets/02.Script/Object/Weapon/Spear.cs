using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon
{
    private void Start()
    {
        _damage = 8f;
        _basicDamage = _damage;
        _spellProbability = 5;
    }
}
