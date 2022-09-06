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
    [SerializeField] float _preSpeed;
    [SerializeField] float _rotateSpeed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    PlayerData _data;
    public Weapon _myWeapon;
    public bool _isAttack;


    /// --------------
    /// 확률
    public int _half;
    public int _1_3;
    public int _quater;



    


    private void Awake()
    {
        Load();
        _data = new PlayerData(_hp, _atk, _matk, _atkSpeed, _def, _speed, _critical, _handicraft, _charm,_criticalDamage);
        
        _preSpeed = _speed;
    }

    private void Start()
    {
        
        _animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        _half = UnityEngine.Random.Range(0, 2);
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
        ChangeState(State.Idle);
    }
    public override void Attack()
    {
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
    public void asd() //마검사 효과
    {
        if(_half == 0)
        {
            _atk = _atk * 2f;
            _matk = 0f;
        }
        else if(_half == 1)
        {
            _atk = 0f;
            _matk = _matk * 2f;
        }
    }

    public void MadMan() // 광인 효과
    {
        _atk = _atk * (3f / 4f);
        _matk = _matk * (3f / 4f);
        _criticalDamage = _criticalDamage * 2f;
    }
    
    public void PowerMan() //괴력몬 효과
    {
        if(_half == 0)
        {
            ChangeState(State.Attack2);
        }
    }
    public void Warrior() // 전사 효과
    {
        _atk = _atk + (_atk / 10);
    }
    public void Dwarf() // 난쟁이
    {
        //추후 추가
    }
    public void JackFrost() // 동장군
    {
        if(_1_3 == 0)
        {
            //빙결
        }
    }
    //--------------------

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
