﻿using System.Collections;
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

    public PlayerData(float hp, float atk, float matk, float atkspeed, float def, float speed, float critical, float handicraft, float charm)
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




    private void Awake()
    {
        Load();
        _data = new PlayerData(_hp, _atk, _matk, _atkSpeed, _def, _speed, _critical, _handicraft, _charm);
        
        _preSpeed = _speed;
    }

    private void Update()
    {
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
    }


    public void FixedUpdate()
    {
        if (variableJoystick != null)
        {

            if (variableJoystick._isStop)
            {
                // rb.velocity = Vector3.zero;
                //rb.angularVelocity = Vector3.zero;
                _speed = 0f;
            }
            else if (variableJoystick._isStop == false)
            {
                _speed = _preSpeed;
            }
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            rb.velocity = (direction * ((_speed+1) * 50f)* Time.fixedDeltaTime);

            transform.rotation = Quaternion.LookRotation(direction);
            transform.Translate(Vector3.forward * _rotateSpeed * Time.deltaTime);
        }
    }

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