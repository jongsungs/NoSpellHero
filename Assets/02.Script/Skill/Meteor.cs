using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : SkillBase
{
    public GameObject _target;

    private void Awake()
    {
        _target = GamePlay.Instance._player.transform.GetChild(5).gameObject;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime) ;
    }
}
