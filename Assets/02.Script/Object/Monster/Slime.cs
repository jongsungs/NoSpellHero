using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : Monster
{

    SkinnedMeshRenderer _material;
    SkinnedMeshRenderer _tempMaterial;


    private void Start()
    {
        _navimeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _material = this.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
        _tempMaterial = _material;
        
    }

    private void Update()
    {
        if(_hp <= 0f)
        {
            ChangeState(State.Die);

        }
        _onHit = _player.GetComponent<Player>()._isAttack;
       

        _navimeshAgent.SetDestination(_player.transform.position);
    }


    protected override void ChangeState(State state)
    {
        base.ChangeState(state);
        _animator.SetInteger(_aniHashKeyState, (int)_state);
        Color _temp = _tempMaterial.material.color;
        switch (_state)
        {
            case State.Idle:
                _navimeshAgent.speed = 0f;
                FadeIn();
                break;
            case State.Walk:
                _navimeshAgent.speed = 1f;
                FadeIn();
                break;
            case State.Attack:
                _navimeshAgent.speed = 0f;
                FadeIn();
                break;
            case State.Hit:
                _navimeshAgent.speed = 0f;
                FadeIn();
                break;
            case State.Die:
                _navimeshAgent.speed = 0f;
                StartCoroutine(CoDie());
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ChangeState(State.Attack);
        }
        if (other.tag == "Weapon" && _onHit == true)
        {
            Debug.Log("여기여기");
           
            _hp -= other.GetComponent<Weapon>()._damage;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            ChangeState(State.Walk);
        }
        if(other.tag == "Weapon")
        {
            
        }
    }

    IEnumerator CoDie()
    {
        StartCoroutine(CoFadeOut(1f));
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }



    // 투명 -> 불투명
   public void  FadeIn()
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

    // 투명 -> 불투명
    IEnumerator CoFadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        var sr = this.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
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
    IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        var sr = this.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
        
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
