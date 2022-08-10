using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    public float _hp;
    public float _att;
    public float _matt;
    public float _attSpeed;
    public float _def;
    public float _speed;
    public float _critical;
    public float _handicraft;
    public float _charm;


    virtual public void Attack()
    {

    }
    virtual public void UseSpell()
    {

    }



}
