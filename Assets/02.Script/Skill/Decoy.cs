using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class Decoy : Monster
{


    public Weapon _myWeapon;



    private IObjectPool<Monster> _decoypool;

    private void OnEnable()
    {

         _myWeapon = Player.Instance._weapon;
        _hp = Player.Instance._hp;
        _atk = Player.Instance._atk;
        _matk = Player.Instance._matk;
        _atkSpeed = Player.Instance._atkSpeed;
        _def = Player.Instance._def;
        _speed = Player.Instance._speed + 0.5f;
        _critical = Player.Instance._critical;
        _handicraft = Player.Instance._handicraft;
        _charm = Player.Instance._charm;
        _basicHp = _hp;
        _maxHp = _basicHp;
        _basicAtk = _atk;
        _basicMatk = _matk;
        _basicAtkSpeed = _atkSpeed;
        _basicDef = _def;
        _basicSpeed = _speed;
        _basicCritical = _critical;
        _basicHandicraft = _handicraft;
        _basicCharm = _charm;


        _ingameHp = 50 + (_hp * 5);
        _maxHp = 50 + (_hp * 5);
        StartCoroutine(CoFindEnemy());
        Debug.Log("디코이");
    }

    private void Update()
    {
        if (_animator != null)
        {
            _animator.speed = 0.5f + (_atkSpeed / 10f);
            _animator.SetFloat("AtkSpeed", _animator.speed);
        }

        if (_ingameHp <= 0f)
        {
            ChangeState(State.Die);

        }

        if (_CC != CrowdControl.Freezing)
        {
            _navimeshAgent.speed = _speed;

        }
        DrawView();  // Scene뷰에 시야범위 그리기
                     // FindVisibleTargets(); // Enemy인지 장애물인지 판별

    }


    public override void Idle()
    {

        ChangeState(State.Idle);
    }
    public override void Attack()
    {
        //_isIdle = false;
        ChangeState(State.Attack);
    }
    public override void Walk()
    {
        ChangeState(State.Walk);
    }
    public override void Hit()
    {
        ChangeState(State.Hit);
    }
    public override void Die()
    {
        ChangeState(State.Die);
    }


    public override void AttackOn()
    {
        _isAttack = true;
        int spell;
        spell = UnityEngine.Random.Range(0, 100);

        if (Player.Instance._playerTitle == Player.PlayerTitle.Dosa && Player.Instance._skill2 >= 3)
        {
            if (Player.Instance.dosahidden == false)
            {
                Player.Instance.dosahidden = true;
                AchievementManager.instance.Unlock("dosahidden");
                Player.Instance.Save();
            }

            if (spell < Player.Instance._spellCastProbability + Player.Instance._weapon._spellProbability)
            {
                Spell(Player.Instance._iceBallProbability, Player.Instance._fireBallProbability, Player.Instance._chainLightProbability);

            }

        }
    }
    public override void AttackOff()
    {
        _isAttack = false;
        _attackOnce = true;
        Idle();
    }


    public override void ChangeState(State state)
    {
        base.ChangeState(state);
        _animator.SetInteger(_aniHashKeyState, (int)_state);
        switch (_state)
        {
            case State.Idle:
                _speed = 0f;
                _attackOnce = true;
                break;
            case State.Walk:
                _attackOnce = true;
                _speed = _basicSpeed;
                break;
            case State.Attack:
                _isAttack = true;
                _attackOnce = false;
                _speed = 0f;
                break;
            case State.Hit:
                _speed = 0f;
                break;
            case State.Die:
                _speed = 0f;
                StartCoroutine(CoDie());
                break;
            case State.Attack2:
                _isAttack = true;
                break;
        }
    }

    public override void MonsterRelease()
    {
        _hp = 0f;
    }

    public void Spell(float ice, float fire, float light)
    {
        float rand = UnityEngine.Random.Range(0, (ice + fire + light));



        if (rand <= ice)
        {
            //아이스볼
            Debug.Log("아이스볼");
        }
        else if (rand <= ice + fire && rand > ice)
        {






            //파이어볼
            Debug.Log("불공");
        }
        else if (rand >= ice + fire && rand <= ice + fire + light)
        {
            Debug.Log("체라");

        }


    }
}

