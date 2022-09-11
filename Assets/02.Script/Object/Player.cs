using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System;


#region PlayerData
public class PlayerData
{
    public float m_hp;
    public float m_atk;
    public float m_matk;
    public float m_atkSpeed;
    public float m_def;
    public float m_speed;
    public float m_critical;
    public float m_handicraft;
    public float m_charm;
    public float m_criticalDamage;

    public PlayerData(float hp, float atk, float matk, float atkspeed, float def, float speed, float critical, float handicraft, float charm,float criticalDamage)
    {
        m_hp = hp;
        m_atk = atk;
        m_matk = matk;
        m_atkSpeed = atkspeed;
        m_def = def;
        m_speed = speed;
        m_critical = critical;
        m_handicraft = handicraft;
        m_charm = charm;
        m_criticalDamage = criticalDamage;
    }
}
#endregion
public class Player : BaseObject
{

    public enum PlayerTitle : int
    {
        Normal = 0,
        MagicalBlader, // 마검사
        MadMan, //광인
        StrongMan, //괴력몬 
        Warrior, //전사
        Dwarf, //난쟁이
        JackFrost, // 동장군
        AssaultCaptain,//돌격대장
        ZhangFei,//삼국지 장비
        Berserker, // 광전사
        Critialer,//급소킬러
        Druid, //드루이드
        Assassin,//암살자
        Ambidextrous,//양손잡이
        LuBu,//여포
        HeavyCavalry, //개마무사
        HealthMagician,//덩치법사
        Priest, // 사제
        Warlock, // 흑마법사
        Salamander, // 불도마뱀
        Zeus,//제우스
        PracticeBug,//연습벌레
        Stranger,//스트레인저
        GateKeeper,//문지기
        Cook,//요리사
        QRF,//번개조
        Servant, //돌쇠
        Athlete, //운동선수
        Versatile,//다재다능
        Shieldbearer,//방패병
        Acupuncturist,//침술사
        SpoonKiller,//숟가락 살인마
        Helen,//절세미인
        Slicker,//야바위꾼
        Idol,//아이돌
        Delivery,//배달부
        Repairman,//수리공
        Taoist,//전우치
        Gambler,//도박사
        SlowStarter,//슬로우스타터
        Orpheus,//오르페우스
        DokeV,//도깨비



    }

    [SerializeField] float _preSpeed;
    [SerializeField] float _rotateSpeed;
    //---------------------------------
    
  
    //-----------------------------
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    PlayerData _data;
    public List<Weapon> _myWeapon = new List<Weapon>();
    public bool _isAttack;
    public bool _isIdle = true;
    public PlayerTitle _playerTitle = PlayerTitle.StrongMan;

    /// --------------
    /// 확률
    public int _half;
    public int _1_3;
    public int _quater;
    public int _1_5;


    


    private void Awake()
    {
        Load();
        _data = new PlayerData(_hp, _atk, _matk, _atkSpeed, _def, _speed, _critical, _handicraft, _charm,_criticalDamage);
        
        _preSpeed = _speed;
        _maxHp = _hp;
        _basicAtk = _atk;
        _basicMatk = _matk;
        _basicAtkSpeed = _atkSpeed;
        _basicDef = _def;
        _basicSpeed = _speed;
        _basicCritical = _critical;
        _basicHandicraft = _handicraft;
        _basicCharm = _charm;

    }

    private void Start()
    {
        
        _animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
       // _half = UnityEngine.Random.Range(0, 2);
        _1_3 = UnityEngine.Random.Range(0, 3);
        _quater = UnityEngine.Random.Range(0, 4);
        if(_animator != null)
        {
            _animator.speed = 0.5f + (_atkSpeed / 10f);
            _animator.SetFloat("AtkSpeed", _animator.speed);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _hp += 1;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Die();
            GamePlay.Instance.ActiveResultPopUp();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Hit();
            
        }

    }


    public void FixedUpdate()
    {
        if (variableJoystick != null)
        {

            if (variableJoystick._isStop)
            {
                _speed = 0f;
               ChangeState(State.Idle);
            }
            else if (variableJoystick._isStop == false)
            {
                _speed = _preSpeed;
               ChangeState(State.Walk);
            }
           
        }
    }
    public override void Idle()
    {
        _isIdle = true;
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
    public override void Attack2()
    {

        if (_playerTitle == PlayerTitle.StrongMan)
        {

            _half = UnityEngine.Random.Range(0, 2);

            if (_half == 0)
            {
                Debug.Log("터졌다");
                ChangeState(State.Attack2);
            }
            else if (_half == 1)
            {
                _isIdle = true;
                ChangeState(State.Idle);
            }
        }
    }

    public void AttackOn()
    {
        _isAttack = true;
    }
    public void AttackOff()
    {
        _isAttack = false;
    }


    protected override void ChangeState(State state)
    {
        base.ChangeState(state);
        _animator.SetInteger(_aniHashKeyState, (int)_state);
        switch(_state)
        {
            case State.Idle:
                Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
                rb.velocity = (direction * (_speed * 50f) * Time.fixedDeltaTime);
                transform.rotation = Quaternion.LookRotation(direction);
                transform.Translate(Vector3.forward * _rotateSpeed * Time.deltaTime);
               
                break;
            case State.Walk:
                Vector3 direction2 = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
                rb.velocity = (direction2 * (_speed * 50f) * Time.fixedDeltaTime);
                transform.rotation = Quaternion.LookRotation(direction2);
                transform.Translate(Vector3.forward * _rotateSpeed * Time.deltaTime);
                
                break;
            case State.Attack:
                _isAttack = true;
                
                break;
            case State.Hit:
            
                break;
            case State.Die:
                break;
            case State.Attack2:
                _isAttack = true;
                break;
        }
    }
    #region SKill
    public void MagicalBlader() //마검사 효과
    {
        if(_half == 0)
        {
            _atk = _basicAtk * 2f;
            _matk = 0f;
        }
        else if(_half == 1)
        {
            _atk = 0f;
            _matk = _basicMatk * 2f;
        }
    }

    public void MadMan() // 광인 효과
    {
        _atk = _basicAtk * 0.75f;
        _matk = _basicMatk * 0.75f;
        _criticalDamage = _criticalDamage * 2f;
    }
    
    public void StrongMan() //괴력몬 효과
    {
        if(_half == 0)
        {
            ChangeState(State.Attack2);
        }
    }
    public void Warrior() // 전사 효과
    {
        _atk = _atk + (_atk*0.1f);
    }
    public void Dwarf() // 난쟁이
    {
        for(int i = 0; i < _myWeapon.Count; ++i)
        {
            if(_myWeapon[i].gameObject.activeSelf == true)
            {
                _myWeapon[i]._damage = _myWeapon[i]._damage + ( _myWeapon[i]._damage * 0.2f);
            }
        }
    }
    public void JackFrost() // 동장군
    {
        if(_1_3 == 0)
        {
            //공격시 30 % 확률로 빙결 모든 스킬 얼음덩이으로 변경
        }
    }
    public void AssaultCaptain() // 돌격대장
    {
        _speed = _basicSpeed + (_basicSpeed * 0.2f);
    }

    public void ZhangFei() // 삼국지 장비
    {
        //공격시 20% 확률로 주변적에게 스턴주는 기합 발동
    }

    public void Berserker() //광전사
    {
        if(_hp <= _maxHp * 0.25f)
        {
            _atk = _basicAtk * 2f;
        }
    }
    public void Critialer() //급소쟁이
    {
        _criticalProbability = 1f;
    }

    public void Druid() //드루이드
    {
        // 공격시 10% 확률로 몬스터를 아군으로 만듬
    }

    public void Assassin() // 암살자
    {
        _criticalDamage = _criticalDamage + (_criticalDamage * 0.2f);
    }

    public void Ambidextrous() //양손잡이
    {
        _atkSpeed += _basicAtkSpeed+(_basicAtkSpeed * 0.5f);

    }
    public void LuBu() // 삼국지 여포
    {
        _atk = _basicAtk * 4f;
        _basicAtk = 2f;
        _speed = 2f;
    }

    public void HeavyCavalry() // 개마무사
    {
        _atk = _basicAtk + (_basicAtk * 0.1f);
        _speed = _basicSpeed + (_basicSpeed * 0.1f);
    }

    public void HealthMagician() // 덩치법사
    {
        for (int i = 0; i < _myWeapon.Count; ++i)
        {
            if (_myWeapon[i].gameObject.activeSelf == true)
            {
                _myWeapon[i]._spellCastProbability = 0.5f;
            }
        }
    }
    public void Priest() // 사제
    {
        //스킬 사용시 20% 확률로 최대 체력의 10% 회복
    }
    public void Warlock() // 흑마법사
    {
        if (_hp <= _maxHp * 0.25f)
        {
            _matk = _basicMatk * 2f;
        }
    }
    public void Salamander() // 불도마뱀
    {
        //모슨 스킬 불덩이로 스킬 변경 스킬 사용시 5 % 확률로 운석 소환
    }
    public void Zeus() //제우스
    {
        //모든 마법을 연쇄번개로 바꾸고 전이 횟수가 5회 늘어난다.
    }

    public void PracticeBug() //연습벌레
    {
        for (int i = 0; i < _myWeapon.Count; ++i)
        {
            if (_myWeapon[i].gameObject.activeSelf == true)
            {
                _myWeapon[i]._spellCastProbability = 1f;
            }
        }
    }
   
    public void Stranger() // 스트레인저
    {
        //스킬 사용시 5% 확률로 블랙홀 소환

    }

    public void GateKeeper() // 문지기
    {
        //스킬 사용시 20%로 벽 소환
    }
    public void Cook() //요리사
    {
        //몬스터 피해의 30 % 를 체력으로 전환

    }
    public void QRF() // 번개조
    {
        _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * 0.5f);
        _atk = _basicAtk + (_basicAtk * 0.1f);

    }

    public void Servant() // 돌쇠
    {
        _hp = _basicHp + _basicHp;
        _basicHp = _hp;

    }
    public void Athlete() // 운동선수
    {
        _hp = _basicHp + (_basicHp * 0.3f);
        _speed = _basicSpeed + (_basicSpeed * 0.2f);

    }
    public void Versatile() // 다재다능
    {
        for (int i = 0; i < _myWeapon.Count; ++i)
        {
            if (_myWeapon[i].gameObject.activeSelf == true)
            {
                _myWeapon[i]._damage = _myWeapon[i]._damage * 2f ;
            }
        }
    }

    public void Shieldbearer() // 방패병
    {
        //휠윈드 애니메이션 만들기
    }
    public void Acupuncturist() // 침술사
    {
        //10% 확률로 공격한 적 즉사
    }
    public void SpoonKiller() //숟가락 살인마
    {
        //공격력 50 % 감소 공격속도 200 % 증가
    }

    public void Helen() // 절세미인
    {
        //주변적 80% 확률로 빙결
    }

    public void Slicker() // 야바위꾼
    {
        //죽었을때 30%확률로 부활
    }
    public void Idol() //아이돌
    {
        //죽인 몬스터 수 *  골드 획득
    }

    public void Delivery() // 배달부
    {
        _speed = _basicSpeed + _basicSpeed;
    }

    public void RepairMan() //수리공
    {
        //5초마다 체력 재생력 +10;
    }

    public void Taoist()//전우치
    {
        //공격시 10% 확률로 분신 소환 분신은 스테이지가 종료되면 사라짐

    }

    public void Gambler() //도박사
    {
        //공격시 50 % 확률로 자신의 능력치 중 하나를 10 % 증가시키거나 10 % 감소한다.

    }

    public void SlowStarter() // 슬로우 스타터
    {
        //스테이지 종료마다 모든능력치 20% 상승

    }
    
    public void Orpheus() // 오르페우스
    {
        //주변 몬스터의 공격력을 70% 감소시킨다.
    }

    public void DokeV() //도꺠비
    {
        //공격시 10% 확률로 몬스터의 능력치를 랜덤으로 가져온다.

    }

    #endregion


    #region File IO
    public void Save()
    {
        DataSave();
        string data = ObjectToJason(_data);
        string path = Path.Combine(Application.dataPath + "/04.Json/PlayerData.json");
        File.WriteAllText(path, data);

    }

    public void Load()
    {
        string path = Path.Combine(Application.dataPath + "/04.Json/PlayerData.json");
        string getJson = File.ReadAllText(path);

        PlayerData json = JsonToObject<PlayerData>(getJson);
        InsertData(json);
    }
    public void InsertData(PlayerData data)
    {
        _hp = data.m_hp;
        _atk = data.m_atk;
        _matk = data.m_matk;
        _atkSpeed = data.m_atkSpeed;
        _def = data.m_def;
        _speed = data.m_speed;
        _critical = data.m_critical;
        _handicraft = data.m_handicraft;
        _charm = data.m_charm;
        _criticalDamage = data.m_criticalDamage;
    }
    public void DataSave()
    {
        _data.m_hp = _hp;
        _data.m_atk = _atk;
        _data.m_matk = _matk;
        _data.m_atkSpeed = _atkSpeed;
        _data.m_def = _def;
        _data.m_speed = _speed;
        _data.m_critical = _critical;
        _data.m_handicraft = _handicraft;
        _data.m_charm = _charm;
        _data.m_criticalDamage = _criticalDamage;

    }
    string ObjectToJason(object data)
    {
        return JsonConvert.SerializeObject(data);
    }
    T JsonToObject<T>(string JsonData)
    {
        return JsonConvert.DeserializeObject<T>(JsonData);
    }
    #endregion
}
