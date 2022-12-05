using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waldo : Weapon
{
    private void Start()
    {
        _damage = 15f;
        _basicDamage = _damage;
        _spellProbability = 0;
    }
}
