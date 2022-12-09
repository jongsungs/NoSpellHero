using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : Monster
{

    public MeshRenderer _material;
    MeshRenderer _tempMaterial;

    private void Start()
    {
        

        _monster = MonsterKind.Slime;
        
        _tempMaterial = _material;
        FadeIn();
        
        _state = State.Walk;
    }

    private void Update()
    {
        
        
        
        if(_ingameHp <= 0f)
        {
            ChangeState(State.Die);

        }
       

       


        if(_CC != CrowdControl.Freezing || _CC != CrowdControl.Stun)
        {
            _navimeshAgent.speed = _speed;

        }
      
        
    }


    







    public override void ChangeState(State state)
    {
        base.ChangeState(state);
        _animator.SetInteger(_aniHashKeyState, (int)_state);
        Color _temp = _tempMaterial.material.color;
        switch (_state)
        {
            case State.Idle:
                _speed = 0f;
                
                break;
            case State.Walk:
                _speed =  _basicSpeed;
                _attackOnce = true;
              
                break;
            case State.Attack:
                _speed = 0f;
                _attackOnce = false;
                break;
            case State.Hit:
                _speed = 0f;

                break;
            case State.Die:
                _speed = 0f;
                StartCoroutine(CoDie());
                break;
        }
    }
    public override void Burn()
    {
        base.Burn();
        _material.material.color = Color.red;
    }
    public override void Freezing()
    {
        base.Freezing();

    }
   
    public override void CCrecovery()
    {
        base.CCrecovery();
        _material.material.color = Color.green;
       
      
    }



    public override void Walk()
    {
        ChangeState(State.Walk);
    }
    public override void AttackOn()
    {
        base.AttackOn();
        _monsterWeapon.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    public override void AttackOff()
    {
        base.AttackOff();
        _monsterWeapon.gameObject.GetComponent<BoxCollider>().enabled = false;
        Walk();
    }

    public override void MonsterRelease()
    {
        _ingameHp = 0f;
    }


  public override  IEnumerator CoFadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        var sr = _material;
        Color tempColor = sr.material.color;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeOutTime;
            sr.material.color = tempColor;

            if (tempColor.a >= 1f) tempColor.a = 1f;

            yield return null;
        }

        sr.material.color = tempColor;
        if (nextEvent != null) nextEvent();
    }

    // 불투명 -> 투명
    public override IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        var sr = _material;

        Color tempColor = sr.material.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            sr.material.color = tempColor;

            if (tempColor.a <= 0f) tempColor.a = 0f;

            yield return null;
        }
        sr.material.color = tempColor;
        if (nextEvent != null) nextEvent();
    }



}
