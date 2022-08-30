using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    protected readonly int _aniHashKeyState = Animator.StringToHash("State");

   protected enum State : int
    {
        Idle = 0,
        Walk = 1,
        Attack = 2,
        Hit = 3,
        Die = 4,

    }

    protected State _state = State.Idle;

    public float _hp;
    public float _atk;
    public float _matk;
    public float _atkSpeed;
    public float _def;
    public float _speed;
    public float _critical;
    public float _handicraft;
    public float _charm;

   protected Animator _animator;
    virtual public void Idle()
    {

    }
    virtual public void Walk()
    {

    }
    virtual public void Attack()
    {

    }
    virtual public void Hit()
    {

    }
    virtual public void Die()
    {

    }


    bool IsState(State state)
    {
        return _state == state;
    }

    virtual protected void ChangeState(State state)
    {
        if (IsState(state))
            return;
        _state = state;


    }


}
