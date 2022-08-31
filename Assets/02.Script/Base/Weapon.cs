using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Player _player;
    public bool _isDamage;
    public float _damage;
    public float _spellCastProbability;
    public bool _isOnce = true;


    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if(_player._isAttack == true && _isOnce == true )
        {
            _isOnce = false;
            _isDamage = true;
        }
        else if(_player._isAttack == false)
        {
            _isDamage = false;
            _isOnce = true;
        }
    }




}
