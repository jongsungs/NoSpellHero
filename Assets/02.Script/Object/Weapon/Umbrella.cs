using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : Weapon
{
    private void Start()
    {
        _damage = 3f;
        _basicDamage = _damage;
        _spellProbability = 30;
    }
}
