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
        Swell, //달인
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
    //체인라이트닝을 위한 곳
    [SerializeField] float m_viewDistance; //시야거리
    [SerializeField] LayerMask m_targetMask;  //Enemy 레이어마스크 지정을 위한 변수

    public List<Monster> _listMonster = new List<Monster>();
    public List<Monster> _listMonster2 = new List<Monster>();
    public List<Monster> _listBlizzardMonster = new List<Monster>();
    public List<GameObject> _listLightning = new List<GameObject>();

    public GameObject _lightning;

    public int _jumpStack;
    public int _basicJumpStack;

    private Transform m_transform;
    public int _count;

    //-----------------------------
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    PlayerData _data;
    public List<Weapon> _myWeapon = new List<Weapon>();
    
    public bool _isIdle = true;
    public PlayerTitle _playerTitle = PlayerTitle.StrongMan;
    public List<float> _listState = new List<float>();
    public float _spellCastProbability;
    public float _fireBallProbability;
    public float _iceBallProbability;
    public float _chainLightProbability;


    public int _skill1;
    public int _skill2;
    public int _skill3;




    /// --------------
    /// 확률
    public int _half;
    public int _1_3;
    public int _quater;
    public int _1_5;
    public int _strongManProbability;

    [SerializeField] float m_viewAngle;    //시야각





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
        _basicCriticalDamage = _criticalDamage;
        _criticalProbability = 3f;
        

        _listState.Add(_atk);
        _listState.Add(_matk);
        _listState.Add(_atkSpeed);
        _listState.Add(_hp);
        _listState.Add(_def);
        _listState.Add(_speed);
        _listState.Add(_critical);
        _listState.Add(_handicraft);
        _listState.Add(_charm);

     

    }

    private void Start()
    {
        
        _animator = GetComponent<Animator>();
        _fireBallProbability = 30f;
        _iceBallProbability = 30f;
        _chainLightProbability = 30f;
        m_transform = GetComponent<Transform>();
        _jumpStack = 3;
        _basicJumpStack = _jumpStack;

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
            Spell();


        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            

        }
        DrawView();
        
    }
    public Vector3 DirFromAngle(float angleInDegrees)
    {
        // 좌우 회전값 갱신
        angleInDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    public void DrawView()
    {
        Vector3 leftBoundary = DirFromAngle(-m_viewAngle / 2);
        Vector3 rightBoundary = DirFromAngle(m_viewAngle / 2);
        Debug.DrawLine(transform.position, transform.position + leftBoundary * m_viewDistance, Color.blue);
        Debug.DrawLine(transform.position, m_transform.position + rightBoundary * m_viewDistance, Color.blue);
    }

    public void FixedUpdate()
    {
        if (variableJoystick != null)
        {

            if (variableJoystick._isStop)
            {
                _basicSpeed = 0f;
               ChangeState(State.Idle);
            }
            else if (variableJoystick._isStop == false)
            {
                _basicSpeed = _preSpeed;
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
        int rand;
        _isAttack = true;
        if (_playerTitle == PlayerTitle.JackFrost)
        {
            rand = UnityEngine.Random.Range(0, 10);
            Debug.Log(rand);
            if (rand == 0 && GamePlay.Instance._isBlizzard == false)
            {
                StartCoroutine(Blizzard());
            }
        }
        else if(_playerTitle == PlayerTitle.ZhangFei)
        {
            rand = UnityEngine.Random.Range(0, 5);
            if(rand ==0)
            {
                Roar();
            }
        }

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
                rb.velocity = (direction * (_basicSpeed * 50f) * Time.fixedDeltaTime);
                transform.rotation = Quaternion.LookRotation(direction);
                transform.Translate(Vector3.forward * _rotateSpeed * Time.deltaTime);
               
                break;
            case State.Walk:
                Vector3 direction2 = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
                rb.velocity = (direction2 * (_basicSpeed * 50f) * Time.fixedDeltaTime);
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

    


    public void Spell()
    {
        float rand = UnityEngine.Random.Range(0, (_iceBallProbability + _fireBallProbability + _chainLightProbability));
     
        
        if(rand <=_iceBallProbability)
        {
            //아이스볼
            Debug.Log("아이스볼");
        }
        else if(rand <=_iceBallProbability + _fireBallProbability && rand > _iceBallProbability)
        {
            //파이어볼
            Debug.Log("불공");
        }
        else if (rand >= _iceBallProbability + _fireBallProbability && rand <= _iceBallProbability + _fireBallProbability + _chainLightProbability)
        {
            Debug.Log("체라");

        }

    }
    public void MagicalBlader() //마검사 효과
    {
        if(_half == 0)
        {
            _atk = _basicAtk  + _basicAtk + (_basicAtk * _skill2/10f);
            _matk = 0 + (_basicMatk * _skill1/10f);
            if(_skill1 == 3)
            {
                _atk = _basicAtk + _basicAtk + (_basicAtk * 0.5f);
            }
        }
        else if(_half == 1)
        {
            _atk = 0 + (_basicAtk * _skill2 / 10f);
            _matk = _basicMatk + _basicMatk + (_basicMatk * _skill1 / 10f);
            if(_skill2 >= 3)
            {
                _matk = _basicMatk + _basicMatk + (_basicMatk * 0.5f);
            }
        }
    }

    public void MadMan() // 광인 효과
    {
        _atk = (_basicAtk * 0.75f) + (_basicAtk * _skill1 / 10f); 
        _matk = (_basicMatk * 0.75f) +(_basicMatk * _skill2 / 10f);
        _criticalDamage = (_basicCriticalDamage * 2f) + (_basicCriticalDamage * _skill3/10f);
    }
    
    public void StrongMan() //괴력몬 효과
    {
        _strongManProbability = UnityEngine.Random.Range(0, 4 - _skill2);

        _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill1 / 10f);

        if (_half == 0)
        {
            ChangeState(State.Attack2);
        }
    }
    public void Warrior() // 전사 효과
    {
        _atk = _basicAtk + (_basicAtk * 0.3f ) + (_basicAtk * _skill1/10f);

    }
    public void Dwarf() // 난쟁이
    {
        _atk = _basicAtk + _skill2 / 10f;

        for(int i = 0; i < _myWeapon.Count; ++i)
        {
            if(_myWeapon[i].gameObject.activeSelf == true)
            {
                _myWeapon[i]._damage = _myWeapon[i]._basicDamage + ( _myWeapon[i]._basicDamage * 0.3f) + (_myWeapon[i]._basicDamage * _skill1/10f);
            }
        }
    }
    public void JackFrost() // 동장군
    {
        
        _iceBallProbability = 100f;
        _chainLightProbability = 0f;
        _fireBallProbability = 0f;

        _atk = _basicAtk + (_basicAtk * _skill2 / 10f);
        _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill3 / 10f);
        
    }
    public void AssaultCaptain() // 돌격대장
    {
        _speed = _basicSpeed + (_basicSpeed * 0.3f) + (_basicSpeed * _skill1/10f);
        _atk = _basicAtk + (_basicAtk * _skill2 / 10f);
    }

    public void ZhangFei() // 삼국지 장비
    {
        //완성
    }

    public void Berserker() //광전사
    {
        _atk = _basicAtk + (_basicAtk * _skill2 / 10f);
        if(_skill1 <=3)
        {
            _maxHp = _basicHp * 0.2f;
            _atk = (_basicAtk * 2f) + (_basicAtk * 2f);
        }
        else if(_hp <= (_maxHp * (0.25f + _skill1/20f)))
        {
            _atk = (_basicAtk * 2f) + (_basicAtk * _skill2 / 10f); 
        }
        


    }
    public void Critialer() //급소쟁이
    {
        _criticalProbability = 1f;
        _criticalDamage = _basicCriticalDamage + (_basicCriticalDamage * _skill1 / 10f);
        _atk = (_basicAtk * 0.3f) + (_basicAtk * _skill2 / 10f);

    }

    public void Druid() //드루이드
    {
        _speed = _basicSpeed + (_basicSpeed * _skill2 / 10f);
        
        //완성
    }

    public void Assassin() // 암살자
    {
        float rand = UnityEngine.Random.Range(0, _criticalProbability - _skill1);
        _criticalDamage = _basicCriticalDamage + (_basicCriticalDamage * 0.2f) + (_basicCriticalDamage * _skill1/10f);
        _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill3 / 10f);
    }

    public void Ambidextrous() //양손잡이
    {

        _atkSpeed += _basicAtkSpeed+(_basicAtkSpeed * 0.5f) + (_basicAtkSpeed * _skill1/10f);
        _atk = _basicAtk + (_basicAtk * _skill2 / 10f);

    }
    public void LuBu() // 삼국지 여포
    {
        _atk = (_basicAtk * 3f) + (_basicAtk * _skill1/10f);
        _atkSpeed = 2f + (_skill2/10f);
        _speed = 2f;

        //무기 창 추가
        if(_skill3 >= 3)
        {
            _atk = (_basicAtk * 5f);
        }
        


    }

    public void HeavyCavalry() // 개마무사
    {
        _atk = _basicAtk + (_basicAtk * 0.2f) + (_basicAtk * _skill1/10f);
        _speed = _basicSpeed + (_basicSpeed * 0.2f) + (_basicSpeed * _skill2/10f);
    }

    public void HealthMagician() // 덩치법사
    {
        _maxHp = _basicHp + (_basicHp * 0.3f) + (_basicHp * _skill1 / 5f);
        //체력 풀스택시 체력비례 대미지 가격 및 주문확률증가 구현해야함
    }
    public void Priest() // 사제
    {
        //스킬 사용시 20% 확률로 최대 체력의 10% 회복
    }
    public void Warlock() // 흑마법사
    {

        if(_skill1 >= 3)
        {
            _spellCastProbability = 7f;
        }

        _matk = _basicMatk + (_basicMatk * _skill2 / 10f);
        if (_hp <= _maxHp * (0.20f+ _skill1/20f))
        {
            _matk = (_basicMatk * 2f) + (_basicMatk * _skill2 / 10f); 
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
        _spellCastProbability = 10f;

        _matk = _basicMatk + (_basicMatk * _skill1 / 10f);
        _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill2);



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
        _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * 0.5f) + (_basicAtkSpeed * _skill1/10f);
        _atk = _basicAtk + (_basicAtk * 0.1f);
        _speed = _basicSpeed + (_basicSpeed * _skill2);

        if(_skill2 >= 3)
        {
            //공격시 스턴
        }



    }

    public void Servant() // 돌쇠
    {
        _hp = _basicHp  * 2f + (_basicHp * _skill1/5f);
        _atkSpeed = _basicAtkSpeed * (_basicAtkSpeed * _skill2 / 10f);
        if(_skill1 >= 3)
        {

            //체력비례 대미지
        }

    }
    public void Athlete() // 운동선수
    {
        _hp = _basicHp + (_basicHp * 0.3f) + (_basicHp * _skill2/10f);
        _speed = _basicSpeed + (_basicSpeed * 0.2f) + (_basicSpeed * _skill1/10f);

    }
    public void Versatile() // 다재다능
    {
        for (int i = 0; i < _myWeapon.Count; ++i)
        {
            if (_myWeapon[i].gameObject.activeSelf == true)
            {
                _myWeapon[i]._damage = _myWeapon[i]._basicDamage * 2f +(_myWeapon[i]._basicDamage + _skill1/10f) ;
            }
        }
        _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill2 / 10f);

        if(_skill2 >= 3)
        {
            _spellCastProbability = 7f;
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
        _atk = (_basicAtk * 0.5f) + (_basicAtk * _skill2/10f);
        _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill1 / 10f);

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
        _critical = _basicCritical + (_basicCritical * _skill1 / 10f);
        _speed = _basicSpeed + (_basicSpeed * _skill2 / 10f);

        //죽인 몬스터 수 *  골드 획득
    }

    public void Swell() // 달인
    {
        _hp = _basicHp + (_basicHp * 0.2f) + (_basicHp * _skill1 / 10f);
        _atk = _basicAtk + (_basicAtk * 0.2f) + (_basicAtk * _skill1 / 10f);
        _matk = _basicMatk + (_basicMatk * 0.2f) + (_basicMatk * _skill1/10f);
        _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * 0.2f) + (_basicAtkSpeed * _skill1 / 10f); ;
        _def = _basicDef + (_basicDef * 0.2f) + (_basicDef * _skill1 / 10f); 
        _speed = _basicSpeed + (_basicSpeed * 0.2f) + (_basicSpeed * _skill1 / 10f); 
        _critical = _basicCritical + (_basicCritical * 0.2f) + (_basicCritical * _skill1 / 10f);
        _handicraft = _basicHandicraft + (_basicHandicraft * 0.2f) + (_basicHandicraft * _skill1 / 10f); 
        _charm = _basicCharm + (_basicCharm * 0.2f) + (_basicCharm * _skill1 / 10f); 

    }

    public void Delivery() // 배달부
    {
        _speed = _basicSpeed + _basicSpeed + (_basicSpeed * _skill1/10f);
        _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill2 / 10f);

        if(_skill1 >= 3)
        {
            //충돌데미지 추가
        }

    }

    public void RepairMan() //수리공
    {
        //5초마다 체력 재생력 +10;

        _atk = _basicAtk + (_basicAtk * _skill2 / 10f);

        if(_skill1 >= 3)
        {
            //매 초마다 체력 회복
        }

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


    public IEnumerator CoLightning()
    {
        _count++;

        Collider[] targets = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);

        

        if (_count % 2 == 0 && _count != 0)//짝수
        {
            _listMonster.Clear();


            if (targets.Length != 0 && targets != null)
            {
                if (targets.Length > _jumpStack)
                {


                    for (int i = 0; i < _jumpStack; ++i)
                    {
                        if (targets[i] != null && targets.Length >= _jumpStack)
                        {
                            _listMonster.Add(targets[i].GetComponent<Monster>());


                        }
                        else if (targets[i] != null && targets.Length < _jumpStack)
                        {
                            _jumpStack = targets.Length;
                            _listMonster.Add(targets[i].GetComponent<Monster>());


                        }

                        if (i == 0 && _listLightning.Count < targets.Length)
                        {
                            var obj = Instantiate(_lightning);
                            var light = obj.GetComponent<LightningBoltScript>();
                            _listLightning.Add(obj);
                            light.StartObject = this.gameObject;
                            light.EndObject = _listMonster[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;

                        }
                        else if (i != 0 && i <= _jumpStack && _listLightning.Count < targets.Length)
                        {

                            yield return new WaitForSeconds(0.05f);
                            var obj = Instantiate(_lightning);
                            _listLightning.Add(obj);
                            var light = obj.GetComponent<LightningBoltScript>();
                            light.StartObject = _listMonster[i - 1].gameObject;
                            light.EndObject = _listMonster[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i == 0 && _listLightning.Count >= targets.Length)
                        {
                            _listLightning[i].SetActive(true);
                            _listLightning[i].GetComponent<LightningBoltScript>().StartObject = this.gameObject;
                            if (_listMonster[i] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i != 0 && i <= _jumpStack && _listLightning.Count >= targets.Length && _listMonster.Count != 0)
                        {
                            yield return new WaitForSeconds(0.05f);
                            _listLightning[i].SetActive(true);
                            if (_listMonster[i - 1] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().StartObject = _listMonster[i - 1].gameObject;
                            if (_listMonster[i] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;


                        }




                    }
                }
                else if(targets.Length <= _jumpStack)
                {
                    for (int i = 0; i < targets.Length; ++i)
                    {
                        if (targets[i] != null && targets.Length >= _jumpStack)
                        {
                            _listMonster.Add(targets[i].GetComponent<Monster>());


                        }
                        else if (targets[i] != null && targets.Length < _jumpStack)
                        {
                            _jumpStack = targets.Length;
                            _listMonster.Add(targets[i].GetComponent<Monster>());


                        }

                        if (i == 0 && _listLightning.Count < targets.Length)
                        {
                            var obj = Instantiate(_lightning);
                            var light = obj.GetComponent<LightningBoltScript>();
                            _listLightning.Add(obj);
                            light.StartObject = this.gameObject;
                            light.EndObject = _listMonster[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;

                        }
                        else if (i != 0  && _listLightning.Count < targets.Length)
                        {

                            yield return new WaitForSeconds(0.05f);
                            var obj = Instantiate(_lightning);
                            _listLightning.Add(obj);
                            var light = obj.GetComponent<LightningBoltScript>();
                            light.StartObject = _listMonster[i - 1].gameObject;
                            light.EndObject = _listMonster[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i == 0 && _listLightning.Count >= targets.Length)
                        {
                            _listLightning[i].SetActive(true);
                            _listLightning[i].GetComponent<LightningBoltScript>().StartObject = this.gameObject;
                            if (_listMonster[i] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i != 0 && _listLightning.Count >= targets.Length && _listMonster.Count != 0)
                        {
                            yield return new WaitForSeconds(0.05f);
                            _listLightning[i].SetActive(true);
                            if (_listMonster[i - 1] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().StartObject = _listMonster[i - 1].gameObject;
                            if (_listMonster[i] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;


                        }




                    }
                }
                for (int i = 0; i < _listLightning.Count; ++i)
                {
                    yield return new WaitForSeconds(0.05f);
                    _listLightning[i].SetActive(false);


                }



                _jumpStack = _basicJumpStack;
            }
        }
        else if (_count %2 == 1) // 홀수
        {
            _listMonster2.Clear();
            if (targets.Length != 0 && targets != null)
            {

                if (targets.Length > _jumpStack)
                {


                    for (int i = 0; i < _jumpStack; ++i)
                    {
                        if (targets[i] != null )
                        {
                            _listMonster2.Add(targets[i].GetComponent<Monster>());


                        }
                      

                        if (i == 0 && _listLightning.Count < targets.Length)
                        {
                            var obj = Instantiate(_lightning);
                            var light = obj.GetComponent<LightningBoltScript>();
                            _listLightning.Add(obj);
                            light.StartObject = this.gameObject;
                            light.EndObject = _listMonster2[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;

                        }
                        else if (i != 0 && i <= _jumpStack && _listLightning.Count < targets.Length)
                        {

                            yield return new WaitForSeconds(0.05f);
                            var obj = Instantiate(_lightning);
                            _listLightning.Add(obj);
                            var light = obj.GetComponent<LightningBoltScript>();
                            light.StartObject = _listMonster2[i - 1].gameObject;
                            light.EndObject = _listMonster2[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i == 0 && _listLightning.Count >= targets.Length)
                        {
                            _listLightning[i].SetActive(true);
                            _listLightning[i].GetComponent<LightningBoltScript>().StartObject = this.gameObject;
                            if (_listMonster2[i] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster2[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i != 0 && i <= _jumpStack && _listLightning.Count >= targets.Length && _listMonster2.Count != 0)
                        {
                            yield return new WaitForSeconds(0.05f);
                            _listLightning[i].SetActive(true);
                            if (_listMonster2[i - 1] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().StartObject = _listMonster2[i - 1].gameObject;
                            if (_listMonster2[i]  != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster2[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;


                        }




                    }
                }
                else if (targets.Length <= _jumpStack)
                {
                    for (int i = 0; i < targets.Length; ++i)
                    {
                        if (targets[i] != null )
                        {
                            _listMonster2.Add(targets[i].GetComponent<Monster>());


                        }


                        if (i == 0 && _listLightning.Count < targets.Length)
                        {
                            var obj = Instantiate(_lightning);
                            var light = obj.GetComponent<LightningBoltScript>();
                            _listLightning.Add(obj);
                            light.StartObject = this.gameObject;
                            light.EndObject = _listMonster2[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;

                        }
                        else if (i != 0  && _listLightning.Count < targets.Length)
                        {

                            yield return new WaitForSeconds(0.05f);
                            var obj = Instantiate(_lightning);
                            _listLightning.Add(obj);
                            var light = obj.GetComponent<LightningBoltScript>();
                            light.StartObject = _listMonster2[i - 1].gameObject;
                            light.EndObject = _listMonster2[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i == 0 && _listLightning.Count >= targets.Length)
                        {
                            _listLightning[i].SetActive(true);
                            _listLightning[i].GetComponent<LightningBoltScript>().StartObject = this.gameObject;
                            if (_listMonster2[i].gameObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster2[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i != 0  && _listLightning.Count >= targets.Length && _listMonster2.Count != 0)
                        {
                            yield return new WaitForSeconds(0.05f);
                            _listLightning[i].SetActive(true);
                            if (_listMonster2[i - 1] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().StartObject = _listMonster2[i - 1].gameObject;
                            if (_listMonster2[i] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster2[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;


                        }




                    }
                }



                for (int i = 0; i < _listLightning.Count; ++i)
                {
                    yield return new WaitForSeconds(0.05f);
                    _listLightning[i].SetActive(false);


                }



                _jumpStack = _basicJumpStack;
            }
        }
        
    }
    public IEnumerator Blizzard()
    {
        GamePlay.Instance.ActiveBlizzard();
        Collider[] targets = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);


        for(int i = 0; i < targets.Length; ++i)
        {
            _listBlizzardMonster.Add(targets[i].GetComponent<Monster>());
        }

        for(int i = 0; i < _listBlizzardMonster.Count; ++i)
        {
            _listBlizzardMonster[i].Freezing();
            _listBlizzardMonster[i]._hp -= 5;
        }

        yield return new WaitForSeconds(4f);

        GamePlay.Instance.DisableBlizzard();
        _listBlizzardMonster.Clear();

    }
    public void Roar()
    {

        m_viewDistance = 2 + _skill2;

        if (_skill2 >= 3)
        {
            m_viewDistance = 60f;
        }


        Collider[] targets = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);

        for(int i = 0; i < targets.Length; ++i)
        {
            _listBlizzardMonster.Add(targets[i].GetComponent<Monster>());
        }

        for(int i = 0; i < _listBlizzardMonster.Count; ++i)
        {
            _listBlizzardMonster[i]._ccDurationTime = 1 + _skill1;
            _listBlizzardMonster[i].Roar();

        }


        _listBlizzardMonster.Clear();

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
