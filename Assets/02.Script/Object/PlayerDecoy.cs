using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class PlayerDecoy : Monster
{

    public List<GameObject> _listWeapon = new List<GameObject>();
    public List<GameObject> _listHelmet = new List<GameObject>();
    public List<GameObject> _listHair = new List<GameObject>();
    public List<GameObject> _listTop = new List<GameObject>();
    public List<GameObject> _listBottom = new List<GameObject>();
    public List<GameObject> _listShoes = new List<GameObject>();
    public List<GameObject> _listTopDeco = new List<GameObject>();
    public List<GameObject> _listBottomDeco = new List<GameObject>();
    public List<GameObject> _listShoesDeco = new List<GameObject>();
    public List<GameObject> _listSkin = new List<GameObject>();
    public Weapon _myWeapon;

    public SkillBase _fireBall;
    public SkillBase _iceBall;
    public IObjectPool<SkillBase> _fireBallPool;
    public IObjectPool<SkillBase> _iceBallPool;
    public GameObject _objectPool;
    public GameObject _skillBarrel;

    private void Start()
    {
        

        #region weapon
        if (Player.Instance._isbasicStick == true)
        {

            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[0].SetActive(true);
            Player.Instance._weapon = Player.Instance._basicStick;

        }
        else if (Player.Instance._isSward1 == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[1].SetActive(true);
            Player.Instance._weapon = Player.Instance._Sward1;
        }
        else if (Player.Instance._isSward2 == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[2].SetActive(true);
            Player.Instance._weapon = Player.Instance._Sward2;
        }
        else if (Player.Instance._isBroom == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[3].SetActive(true);
            Player.Instance._weapon = Player.Instance._Broom;
        }
        else if (Player.Instance._isClub == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[4].SetActive(true);
            Player.Instance._weapon = Player.Instance._Club;
        }
        else if (Player.Instance._isShortSward == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[5].SetActive(true);
            Player.Instance._weapon = Player.Instance._ShortSward;
        }
        else if (Player.Instance._isHanger == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[6].SetActive(true);
            Player.Instance._weapon = Player.Instance._Hanger;
        }
        else if (Player.Instance._isMace == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[7].SetActive(true);
            Player.Instance._weapon = Player.Instance._Mace;
        }
        else if (Player.Instance._isShield == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[8].SetActive(true);
            Player.Instance._weapon = Player.Instance._Shield;
        }
        else if (Player.Instance._isSpear == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[9].SetActive(true);
            Player.Instance._weapon = Player.Instance._Spear;
        }
        else if (Player.Instance._isUmbrella == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[10].SetActive(true);
            Player.Instance._weapon = Player.Instance._Umbrella;
        }
        else if (Player.Instance._isWaldo == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[11].SetActive(true);
            Player.Instance._weapon = Player.Instance._Waldo;
        }
        else if (Player.Instance._isStick == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[12].SetActive(true);
            Player.Instance._weapon = Player.Instance._Stick;
        }
        #endregion

        #region Helmet
        if (Player.Instance._isKightHelmet == true)
        {

            for (int i = 0; i < _listHelmet.Count; ++i)
            {
                _listHelmet[i].SetActive(false);
            }
            _listHelmet[0].SetActive(true);

        }
        else if (Player.Instance._isMasicianHat == true)
        {
            for (int i = 0; i < _listHelmet.Count; ++i)
            {
                _listHelmet[i].SetActive(false);
            }
            _listHelmet[1].SetActive(true);
        }
        else if (Player.Instance._isGat == true)
        {
            for (int i = 0; i < _listHelmet.Count; ++i)
            {
                _listHelmet[i].SetActive(false);
            }
            _listHelmet[2].SetActive(true);
        }
        else if (Player.Instance._isEmptyHelmet == true)
        {
            for (int i = 0; i < _listHelmet.Count; ++i)
            {
                _listHelmet[i].SetActive(false);
            }
            _listHelmet[3].SetActive(true);
        }
        #endregion

        #region Hair
        if (Player.Instance._isSkinHead == true)
        {

            for (int i = 0; i < _listHair.Count; ++i)
            {
                _listHair[i].SetActive(false);
            }
            _listHair[0].SetActive(true);

        }
        else if (Player.Instance._isnormalHair == true)
        {
            for (int i = 0; i < _listHair.Count; ++i)
            {
                _listHair[i].SetActive(false);
            }
            _listHair[1].SetActive(true);
        }
        #endregion

        #region Top
        if (Player.Instance._isKnightTop == true)
        {

            for (int i = 0; i < _listTop.Count; ++i)
            {
                _listTop[i].SetActive(false);
            }
            for (int i = 0; i < _listTopDeco.Count; ++i)
            {
                _listTopDeco[i].SetActive(false);
            }
            for (int i = 0; i < _listSkin.Count; ++i)
            {
                _listSkin[i].SetActive(false);
            }

            _listTop[0].SetActive(true);
            _listTopDeco[0].SetActive(true);
            _listSkin[0].SetActive(true);
        }
        else if (Player.Instance._isMasicianTop == true)
        {
            for (int i = 0; i < _listTop.Count; ++i)
            {
                _listTop[i].SetActive(false);
            }
            for (int i = 0; i < _listTopDeco.Count; ++i)
            {
                _listTopDeco[i].SetActive(false);
            }
            for (int i = 0; i < _listSkin.Count; ++i)
            {
                _listSkin[i].SetActive(false);
            }

            _listTopDeco[1].SetActive(true);
            _listTop[1].SetActive(true);

        }
        else if (Player.Instance._isDurumagiTop == true)
        {
            for (int i = 0; i < _listTop.Count; ++i)
            {
                _listTop[i].SetActive(false);
            }
            for (int i = 0; i < _listTopDeco.Count; ++i)
            {
                _listTopDeco[i].SetActive(false);
            }
            for (int i = 0; i < _listSkin.Count; ++i)
            {
                _listSkin[i].SetActive(false);
            }
            _listSkin[1].SetActive(true);
            _listTopDeco[2].SetActive(true);
            _listTop[2].SetActive(true);
        }
        else if (Player.Instance._isNormalTop == true)
        {
            for (int i = 0; i < _listTop.Count; ++i)
            {
                _listTop[i].SetActive(false);
            }
            for (int i = 0; i < _listTopDeco.Count; ++i)
            {
                _listTopDeco[i].SetActive(false);
            }
            for (int i = 0; i < _listSkin.Count; ++i)
            {
                _listSkin[i].SetActive(false);
            }
            _listTop[3].SetActive(true);
        }
        #endregion


        #region Bottom
        if (Player.Instance._isKnightBottom == true)
        {

            for (int i = 0; i < _listBottom.Count; ++i)
            {
                _listBottom[i].SetActive(false);
            }
            for (int i = 0; i < _listBottomDeco.Count; ++i)
            {
                _listBottomDeco[i].SetActive(false);
            }
            _listBottom[0].SetActive(true);
            _listBottomDeco[0].SetActive(true);
        }
        else if (Player.Instance._isMasicianBottom == true)
        {
            for (int i = 0; i < _listBottom.Count; ++i)
            {
                _listBottom[i].SetActive(false);
            }
            for (int i = 0; i < _listBottomDeco.Count; ++i)
            {
                _listBottomDeco[i].SetActive(false);
            }
            _listBottom[1].SetActive(true);
            _listBottomDeco[1].SetActive(true);
        }
        else if (Player.Instance._isdurumagiBottom == true)
        {
            for (int i = 0; i < _listBottom.Count; ++i)
            {
                _listBottom[i].SetActive(false);
            }
            for (int i = 0; i < _listBottomDeco.Count; ++i)
            {
                _listBottomDeco[i].SetActive(false);
            }
            _listBottom[2].SetActive(true);
            _listBottomDeco[2].SetActive(true);
        }
        else if (Player.Instance._isTrunkBottom == true)
        {
            for (int i = 0; i < _listBottom.Count; ++i)
            {
                _listBottom[i].SetActive(false);
            }
            for (int i = 0; i < _listBottomDeco.Count; ++i)
            {
                _listBottomDeco[i].SetActive(false);
            }
            _listBottom[3].SetActive(true);
        }

        #endregion

        #region Shoes
        if (Player.Instance._isKnightShoes == true)
        {

            for (int i = 0; i < _listShoes.Count; ++i)
            {
                _listShoes[i].SetActive(false);
            }
            for (int i = 0; i < _listShoesDeco.Count; ++i)
            {
                _listShoesDeco[i].SetActive(false);
            }

            _listShoesDeco[0].SetActive(true);
            _listShoesDeco[1].SetActive(true);
            _listShoes[0].SetActive(true);
            _listShoes[1].SetActive(true);

        }
        else if (Player.Instance._isSandal == true)
        {
            for (int i = 0; i < _listShoes.Count; ++i)
            {
                _listShoes[i].SetActive(false);
            }
            for (int i = 0; i < _listShoesDeco.Count; ++i)
            {
                _listShoesDeco[i].SetActive(false);
            }

            _listShoes[2].SetActive(true);
            _listShoes[3].SetActive(true);
        }
        else if (Player.Instance._isOldShoes == true)
        {
            for (int i = 0; i < _listShoes.Count; ++i)
            {
                _listShoes[i].SetActive(false);
            }
            for (int i = 0; i < _listShoesDeco.Count; ++i)
            {
                _listShoesDeco[i].SetActive(false);
            }

            _listShoes[4].SetActive(true);
            _listShoes[5].SetActive(true);
        }
        else if (Player.Instance._isnormalShoes == true)
        {
            for (int i = 0; i < _listShoes.Count; ++i)
            {
                _listShoes[i].SetActive(false);
            }
            for (int i = 0; i < _listShoesDeco.Count; ++i)
            {
                _listShoesDeco[i].SetActive(false);
            }

            _listShoes[6].SetActive(true);
            _listShoes[7].SetActive(true);
        }
        #endregion

        _fireBallPool = new ObjectPool<SkillBase>(CreateFireBall, OngetSkill, OnReleaseSkill, OnDestroySkill, maxSize: 10);
        _iceBallPool = new ObjectPool<SkillBase>(CreateIceBall, OngetSkill, OnReleaseSkill, OnDestroySkill, maxSize: 10);

    }
    private void OnEnable()
    {

        _myWeapon = Player.Instance._weapon;
        _hp = Player.Instance._hp/2f;
        _atk = Player.Instance._atk/2f;
        _matk = Player.Instance._matk/2f;
        _atkSpeed = Player.Instance._atkSpeed/2f;
        _def = Player.Instance._def/2f;
        _speed = (Player.Instance._speed + 1f)/2f;
        _critical = Player.Instance._critical/2f;
        _handicraft = Player.Instance._handicraft/2f;
        _charm = Player.Instance._charm/2f;
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
        _ingameHp = 50 + (_hp * 5);
        _maxHp = 50 + (_hp * 5);
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

    ///--------»À´Ù±Í ´øÁö±â
    private SkillBase CreateFireBall()
    {
        var bone = Instantiate(_fireBall, _skillBarrel.transform.position, transform.rotation, _objectPool.transform);
        bone.SetPool(_fireBallPool);
        return bone;
    }
    private SkillBase CreateIceBall()
    {
        var bone = Instantiate(_iceBall, _skillBarrel.transform.position, transform.rotation, _objectPool.transform);
        bone.SetPool(_iceBallPool);
        return bone;
    }
    private void OngetSkill(SkillBase skill)
    {
        skill.transform.position = _skillBarrel.transform.position;
        skill.transform.rotation = transform.rotation;
        skill.gameObject.SetActive(true);
    }

    private void OnReleaseSkill(SkillBase skill)
    {
        skill.gameObject.SetActive(false);
    }
    private void OnDestroySkill(SkillBase skill)
    {
        Destroy(skill.gameObject);
    }

    ///--------------------------------


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
            if (other.GetComponent<SkillBase>() != null)
                other.GetComponent<SkillBase>().SkillRelease();
        }
        else if (other.CompareTag("Rock"))
        {
            var damage = other.GetComponent<SkillBase>()._skillDamage - (_def * 3f);
            if (damage <= 0)
            {
                damage = 0f;
            }
            damage = Mathf.Round(damage);
            _ingameHp -= damage;
            _mmfPlayer.PlayFeedbacks(transform.position, damage);

            SoundManager.Instance.EffectPlay(SoundManager.Instance._playerHit);
            other.GetComponent<SkillBase>().SkillRelease();
            
        }
        else if (other.CompareTag("Weapon") && other.transform.root.GetComponent<Monster>() != null && other.transform.root.gameObject.layer == 6)
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
        _iceBallPool.Get();
    }

    public void FireBall()
    {
        _fireBallPool.Get();
        SoundManager.Instance.EffectPlay(SoundManager.Instance._fireball);
    }
    public void Attack2nd()
    {

    }
  


  

}
