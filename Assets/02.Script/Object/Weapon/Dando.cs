using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dando : Weapon
{
    private void Start()
    {
        _damage = 5f;
        _basicDamage = _damage;
        _spellProbability = 10;
    }
}
