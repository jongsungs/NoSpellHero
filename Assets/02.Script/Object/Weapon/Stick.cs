using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : Weapon
{
    private void Start()
    {
        _damage = 6f;
        _basicDamage = _damage;
        _spellProbability = 20;
    }
}
