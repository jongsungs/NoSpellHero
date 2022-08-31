using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Monster
{
    private void Start()
    {
        _navimeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {

        _navimeshAgent.SetDestination(_player.transform.position);
    }
}
