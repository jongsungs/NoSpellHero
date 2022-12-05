using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStick : Weapon
{
    private void Start()
    {
        _damage = 3f;
        _basicDamage = _damage;
        _spellProbability = 10;
    }
}
