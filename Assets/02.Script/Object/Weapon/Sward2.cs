using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sward2 : Weapon
{
    private void Start()
    {
        _damage = 5f;
        _basicDamage = _damage;
        _spellProbability = 10;
    }
}
