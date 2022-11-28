using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public bool _isDamage;
    public float _damage;
    public float _basicDamage;
    public int _spellProbability;


    public bool _isOnce = true;


    private void Awake()
    {
        
        _basicDamage = _damage;
    }





}
