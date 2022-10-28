using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public bool _isDamage;
    public float _damage;
    public float _basicDamage;
    
    public bool _isOnce = true;


    private void Awake()
    {
        
        _basicDamage = _damage;
    }

    private void Update()
    {
       if( Player.Instance._isAttack == true )
       {
           _isOnce = true;
           _isDamage = true;
       }
       else if(Player.Instance._isAttack == false)
       {
           _isDamage = false;
           _isOnce = false;
       }
    }




}
