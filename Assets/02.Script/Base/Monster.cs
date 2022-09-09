using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.AI;

public class Monster : BaseObject
{
    private IObjectPool<Monster> _monsterpool;
    protected GameObject _player;
    protected NavMeshAgent _navimeshAgent;
    public bool _onHit;
    protected float _ccDurationTime;
    protected bool _ccOn = false;
    
    private void Start()

    {
        _navimeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {

        _navimeshAgent.SetDestination(_player.transform.position);
        
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
        Debug.Log("¾ó¾ú´Ù");
        _animator.speed = 0f;
        _navimeshAgent.speed = 0f;

    }
    protected virtual void CCrecovery()
    {
        _animator.speed = 1f;
        _navimeshAgent.speed = _speed;
    }



}
