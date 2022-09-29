using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonKing : Monster
{
    SkinnedMeshRenderer _material;
    SkinnedMeshRenderer _tempMaterial;


    protected override void Start()
    {
        _monster = MonsterKind.CaptainSkull;
        if (GamePlay.Instance._currentStage == GamePlay.GameState.Stage4)
        {
            _category = MonsterCategory.Boss;
        }
        else
        {
            _category = MonsterCategory.Common;
        }
        _navimeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _tempMaterial = _material;
        FadeIn();
        GamePlay._eventHandler += MonsterRelease;
    }

    private void Update()
    {

        if (_ccOn == true)
        {
            _ccDurationTime -= Time.deltaTime;

        }

        if (_hp <= 0f && _isDead == false)
        {
            _isDead = true;
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
        // Color _temp = _tempMaterial.material.color;
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
                if (_category == MonsterCategory.Boss)
                {
                    GamePlay.Instance.BossDie(GamePlay.GameState.Result);
                    _navimeshAgent.speed = 0f;
                }
                else
                {
                    _navimeshAgent.speed = 0f;

                }
                //StartCoroutine(CoDie());
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

        _material.material.color = Color.blue;
    }

    public override void CCrecovery()
    {
        base.CCrecovery();
        _material.material.color = Color.white;

        Debug.Log("ȸ��");
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
                Debug.Log("���⿩��");

                ChangeState(State.Hit);
                _hp -= other.GetComponent<Weapon>()._damage;
            }

        }

        if (other.CompareTag("IceBall"))
        {
            int _30 = Random.Range(0, 3); // 30��Ȯ���� ����
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

    public override void MonsterRelease()
    {
        _hp = 0f;
    }



    // ���� -> ������
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

    // ������ -> ����
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
