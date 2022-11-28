using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    protected readonly int _aniHashKeyState = Animator.StringToHash("State");

    public enum State : int
    {
        Idle = 0,
        Walk = 1,
        Attack = 2,
        Hit = 3,
        Die = 4,
        Attack2 = 5,
        None = 6,


    }
    protected enum CrowdControl : int
    {
        Normal = 0,
        Burn,
        Freezing,
        ElectricShock,
        Stun,

    }

    public State _state;
    [SerializeField]protected CrowdControl _CC = CrowdControl.Normal;


    public float _hp;
    public float _atk;
    public float _matk;
    public float _atkSpeed;
    public float _def;
    public float _speed;
    public float _critical;
    public float _handicraft;
    public float _charm;
    public float _criticalDamage;

    public float _ingameHp;
    public float _maxHp;
    public float _basicHp;
    public float _basicAtk;
    public float _basicMatk;
    public float _basicAtkSpeed;
    public float _basicDef;
    public float _basicSpeed;
    public float _basicCritical;
    public float _basicHandicraft;
    public float _basicCharm;
    public float _basicCriticalDamage;
    public float _criticalProbability; //치명타확률

    public bool _isAttack;
    public Animator _animator;
    public Rigidbody _rigidbody;

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
    virtual public void Attack2()
    {

    }


    bool IsState(State state)
    {
        return _state == state;
    }

    virtual public void ChangeState(State state)
    {
        if (IsState(state))
            return;
        _state = state;


    }

    public virtual void Play(int i)
    {
        
       
    }

  
}
