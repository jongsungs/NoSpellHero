using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.AI;

public class Monster : BaseObject
{
    private IObjectPool<Monster> _monsterpool;
    protected GameObject _player;
    [SerializeField] Vector3 m_spped;
    protected NavMeshAgent _navimeshAgent;
    public bool _onHit;
    
    private void Start()

    {
        _navimeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        
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
    




}
