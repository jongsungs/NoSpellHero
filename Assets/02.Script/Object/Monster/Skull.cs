using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skull : Monster
{
    SkinnedMeshRenderer _material;
    SkinnedMeshRenderer _tempMaterial;


    private void Start()
    {
        _monster = MonsterKind.Slime;
        _navimeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _material = this.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
        _tempMaterial = _material;
        FadeIn();
    }

    private void Update()
    {

        if (_ccOn == true)
        {
            _ccDurationTime -= Time.deltaTime;

        }

        if (_hp <= 0f)
        {
            ChangeState(State.Die);

        }





        _navimeshAgent.SetDestination(_player.transform.position);
    }


    public override void Idle()
    {
        ChangeState(State.Idle);
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

                break;
            case State.Walk:
                _navimeshAgent.speed = 1f;

                break;
            case State.Attack:
                _navimeshAgent.speed = 0f;

                break;
            case State.Hit:
                _navimeshAgent.speed = 0f;

                break;
            case State.Die:
                _navimeshAgent.speed = 0f;
                StartCoroutine(CoDie());
                break;
        }
    }
    protected override void Burn()
    {
        base.Burn();
        _material.material.color = Color.red;
    }
    protected override void Freezing()
    {
        base.Freezing();

        _material.material.color = Color.blue;
    }

    public override void CCrecovery()
    {
        base.CCrecovery();
        _material.material.color = Color.white;

        Debug.Log("회복");
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            ChangeState(State.Attack);
        }
        if (other.CompareTag("Weapon"))
        {

            if (other.GetComponent<Weapon>()._isOnce == true)
            {

                other.GetComponent<Weapon>()._isOnce = false;
                Debug.Log("여기여기");

                ChangeState(State.Hit);
                _hp -= other.GetComponent<Weapon>()._damage;
            }

        }

        if (other.CompareTag("IceBall"))
        {
            int _30 = Random.Range(0, 3); // 30퍼확률로 빙결
            if (_30 == 0)
            {
                Freezing();

            }
        }
        if (other.CompareTag("FireBall"))
        {
            int _30 = Random.Range(0, 3);
            if (_30 == 0)
            {
                Burn();
            }
        }
        if (other.CompareTag("Roar"))
        {
            Roar();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeState(State.Walk);
        }
        if (other.CompareTag("Weapon"))
        {

        }
    }

    IEnumerator CoDie()
    {
        StartCoroutine(CoFadeOut(1f));
        yield return new WaitForSeconds(2f);
        _monsterpool.Release(this);
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
