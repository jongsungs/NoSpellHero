using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class Decoy : Monster
{


    public Weapon _myWeapon;



    private IObjectPool<Monster> _decoypool;

    private  void OnEnable()
    {

         _myWeapon = Player.Instance._weapon;
        _hp = Player.Instance._hp;
        _atk = Player.Instance._atk;
        _matk = Player.Instance._matk;
        _atkSpeed = Player.Instance._atkSpeed;
        _def = Player.Instance._def;
        _speed = Player.Instance._speed + 1f ;
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


        GamePlay._eventHandler += MonsterRelease;
        _ingameHp = 25 + (_hp * 5);
        _maxHp = 25 + (_hp * 5);
        StartCoroutine(CoFindEnemy());
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
        int spell;
        spell = UnityEngine.Random.Range(0, 100);

        if (Player.Instance._playerTitle == Player.PlayerTitle.Dosa && Player.Instance._skill2 >= 3)
        {
            if (Player.Instance.dosahidden == false)
            {
                Player.Instance.dosahidden = true;
                AchievementManager.instance.Unlock("dosahidden");
                Player.Instance.AchiveSave();
            }

            if (spell < Player.Instance._spellCastProbability)
            {
                Spell(Player.Instance._iceBallProbability, Player.Instance._fireBallProbability);

            }

        }
    }
    public override void AttackOff()
    {
        
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
                break;
        }
    }

    public override void MonsterRelease()
    {
        _ingameHp = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bone"))
        {
            var damage = other.GetComponent<SkillBase>()._skillDamage - (_def * 3f);
            if (damage <= 0)
            {
                damage = 0f;
            }
            _ingameHp -= damage;
            _mmfPlayer.PlayFeedbacks(transform.position, damage);
            SoundManager.Instance.EffectPlay(SoundManager.Instance._playerHit);
            if(other.GetComponent<SkillBase>() != null)
            other.GetComponent<SkillBase>().SkillRelease();
        }
        else if (other.CompareTag("Weapon") && other.transform.root.GetComponent<Monster>() != null&& other.transform.root.gameObject.layer == 6)
        {
            if (other.GetComponent<Weapon>()._isOnce == true)
            {

                other.GetComponent<Weapon>()._isOnce = false;
                var damage = other.GetComponent<Weapon>()._damage - (_def * 3f);
                if (damage <= 0)
                {
                    damage = 0f;
                }
                _ingameHp -= damage;
                _mmfPlayer.PlayFeedbacks(transform.position, damage);
                SoundManager.Instance.EffectPlay(SoundManager.Instance._playerHit);
            }

        }
        else if (other.CompareTag("Enemy") && other.GetComponent<Weapon>() == null && other.GetComponent<Monster>()._isAttack == true && other.GetComponent<Monster>()._monster != Monster.MonsterKind.CaptainSkull)
        {
            other.GetComponent<Monster>()._isAttack = false;
            var damage = (other.GetComponent<Monster>()._atk * 5) - (_def * 3f);
            if (damage <= 0)
            {
                damage = 0f;
            }
            _ingameHp -= damage;
            _mmfPlayer.PlayFeedbacks(transform.position, damage);
            SoundManager.Instance.EffectPlay(SoundManager.Instance._playerHit);
            Player.Instance._hitCount++;
        }

    }
    public void Spell(float ice, float fire)
    {

   
        float rand = UnityEngine.Random.Range(0, (ice + fire));
     

        if (rand <= ice)
        {
            IceBall();
        }
        else if (rand <= ice + fire && rand > ice)
        {
           

            FireBall();
        }
       

       

    }



    
    public void IceBall()
    {
        SoundManager.Instance.EffectPlay(SoundManager.Instance._iceball);
        GamePlay.Instance._iceballPool.Get();
    }
 
    public void FireBall()
    {
        GamePlay.Instance._fireBallPool.Get();
        SoundManager.Instance.EffectPlay(SoundManager.Instance._fireball);
    }
}

