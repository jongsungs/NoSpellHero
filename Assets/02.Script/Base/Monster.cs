using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.AI;

public class Monster : BaseObject
{
    public enum MonsterKind : int
    {
        Slime,
        Wolf,

    }
    


    protected IObjectPool<Monster> _monsterpool;
    protected GameObject _player;
    protected NavMeshAgent _navimeshAgent;
    public bool _onHit;
    protected float _ccDurationTime;
    protected bool _ccOn = false;
    public MonsterKind _monster;
   
    private void Start()

    {
        _navimeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _maxHp = _hp;
        _basicAtk = _atk;
        _basicMatk = _matk;
        _basicAtkSpeed = _atkSpeed;
        _basicDef = _def;
        _basicSpeed = _speed;
        _basicCritical = _critical;
        _basicHandicraft = _handicraft;
        _basicCharm = _charm;

    }

    private void LateUpdate()
    {

        _navimeshAgent.SetDestination(_player.transform.position);
        if (_ccDurationTime <= 0)
        {
            _ccDurationTime = 0f;
        }
        if (_ccDurationTime <= 0 && _ccOn == true)
        {
            CCrecovery();
        }
        if(_CC == CrowdControl.Burn)
        {
            _hp -= (_player.GetComponent<Player>()._matk / 10f) * Time.deltaTime ;
        }
        


    }

    private void Awake()
    {
        _player = GameObject.Find("Player");
    }
   

    public void SetPool(IObjectPool<Monster> pool)
    {
        _monsterpool = pool;
    }

    private void OnBecameInvisible()
    {
        _monsterpool.Release(this);
    }

    

    protected virtual void Freezing()
    {
        _CC = CrowdControl.Freezing;
        Debug.Log("얼었다");
        _animator.speed = 0f;
        _navimeshAgent.speed = 0f;
        _ccDurationTime += 3f;
        _ccOn = true;

    }
    protected virtual void Burn()
    {
        _CC = CrowdControl.Burn;
        _ccDurationTime += 3f;
        Debug.Log("으이구 이 화상아");
        _atk = _basicAtk / 2;
        _ccOn = true;

    }
    protected virtual void Roar()
    {
        _CC = CrowdControl.Stun;
        _ccDurationTime += 3f;
        _animator.speed = 0f;
        _navimeshAgent.speed = 0f;
        _ccOn = true;
    }
    protected virtual void CCrecovery()
    {
        _CC = CrowdControl.Normal;
        _animator.speed = 1f;
        _navimeshAgent.speed = _speed;
        _atk = _basicAtk;
        _ccOn = false;
    }

    // 투명 -> 불투명
    public void FadeIn()
    {
        var sr = this.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
        Color tempColor = sr.material.color;
        while (tempColor.a < 1f)
        {
            tempColor.a += 1f;
            sr.material.color = tempColor;

            if (tempColor.a >= 1f) tempColor.a = 1f;


        }

        sr.material.color = tempColor;
    }

}
