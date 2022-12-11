using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

using UnityEngine.AI;
public class Golem : Monster
{
    public List<SkinnedMeshRenderer> _tempMaterial;
    public List<Monster> _listobject;
    public float _skilldistance;

    public SkillBase _roar;
    public IObjectPool<SkillBase> _roarPool;
    public GameObject _objectPool;
    public GameObject _skillBarrel;
    private void Start()
    {

        _skilldistance = 2f;

        _tempMaterial = _listMaterial;

        _roarPool = new ObjectPool<SkillBase>(CreateRoarGolem, OngetRoar, OnReleaseRoar, OnDestroyRoar, maxSize: 10);
        FadeIn();
    }

    private void Update()
    {



        if (_ingameHp <= 0f)
        {
            ChangeState(State.Die);

        }


        if (_CC != CrowdControl.Freezing || _CC != CrowdControl.Stun)
        {
            _navimeshAgent.speed = _speed;

        }


    }










    public override void ChangeState(State state)
    {
        base.ChangeState(state);
        _animator.SetInteger(_aniHashKeyState, (int)_state);
        switch (_state)
        {
            case State.Idle:
                _speed = 0f;

                break;
            case State.Walk:
                _speed = _basicSpeed;
                _attackOnce = true;

                break;
            case State.Attack:
                _atk = _basicAtk;
                _speed = 0f;
                break;
            case State.Hit:
                _speed = 0f;

                break;
            case State.Die:
                _speed = 0f;
                StartCoroutine(CoDie());
                if (_category == MonsterCategory.Boss && _isDead == false)
                {
                    _isDead = true;
                    GamePlay.Instance.BossDie();
                    // GamePlay.Instance.ChangeStage();
                }
                break;
            case State.Attack2:
                _speed = 0f;
               
                break;

        }
    }
    public override void Burn()
    {
        base.Burn();
        for (int i = 0; i < _listMaterial.Count; ++i)
        {
            _listMaterial[i].material.color = Color.red;

        }
    }
    public override void Freezing()
    {
        base.Freezing();

    }

    public override void CCrecovery()
    {
        base.CCrecovery();
        for (int i = 0; i < _listMaterial.Count; ++i)
        {
            _listMaterial[i].material.color = Color.white;

        }

    }



    public override void Walk()
    {
        ChangeState(State.Walk);
    }

    public override void AttackOn()
    {
        
        base.AttackOn();
    }

    public override void AttackOff()
    {
        base.AttackOff();
        _attackStack++;
        Walk();
    }
    public virtual void AttackOn2()
    {
        if (_monsterWeapon != null)
            _monsterWeapon._isOnce = true;
        _atk = _basicAtk * 2f;
        if (_monster != MonsterKind.CaptainSkull)
        {
            SoundManager.Instance.EffectPlay(SoundManager.Instance._monsterAttack);

        }
    }
    public  void AttackOff2()
    {
        if (_monsterWeapon != null)
            _monsterWeapon._isOnce = false;
        _attackStack = 0;
       
    }
    public void Roar()
    {



        _roarPool.Get();
        SoundManager.Instance.EffectPlay(SoundManager.Instance._meteorex);
      




        Collider[] targets = Physics.OverlapSphere(m_transform.position, _skilldistance, m_targetMask);

        for (int i = 0; i < targets.Length; ++i)
        {
            if(targets[i].GetComponent<Monster>() != null)
            {
                _listobject.Add(targets[i].GetComponent<Monster>());

            }
        }

        for (int i = 0; i < _listobject.Count; ++i)
        {
            _listobject[i]._ccDurationTime = 1f;
            _listobject[i].Stun();

        }


        // _listBlizzardMonster.Clear();

    }
    ///--------뼈다귀 던지기
    private SkillBase CreateRoarGolem()
    {
        var bone = Instantiate(_roar, _skillBarrel.transform.position, transform.rotation, _objectPool.transform);
        bone.SetPool(_roarPool);
        return bone;
    }
    private void OngetRoar(SkillBase skill)
    {
        skill.transform.position = _skillBarrel.transform.position;
        skill.transform.rotation = transform.rotation;
        skill.gameObject.SetActive(true);
    }

    private void OnReleaseRoar(SkillBase skill)
    {
        skill.gameObject.SetActive(false);
    }
    private void OnDestroyRoar(SkillBase skill)
    {
        Destroy(skill.gameObject);
    }
    public override void MonsterRelease()
    {
        _ingameHp = 0f;
    }
    public void ChangeIndex(List<Color> list, int index, float cnt, Color temp)
    {
        temp = list[index];
        temp.r = cnt;
        list[index] = temp;
    }

    public override IEnumerator CoFadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        var sr = _listMaterial;
        List<Color> tempColor = new List<Color>();

        for (int i = 0; i < _listMaterial.Count; ++i)
        {
            tempColor.Add(_listMaterial[i].material.color);
        }

        for (int i = 0; i < _tempMaterial.Count; ++i)
        {
            float cnt = 0;
            while (tempColor[i].a < 1f)
            {
                cnt += Time.deltaTime / fadeOutTime;
                tempColor[i] = new Color(1, 1, 1, cnt);
                sr[i].material.color = tempColor[i];

                if (tempColor[i].a >= 1f) tempColor[i] = new Color(1f, 1f, 1f, 1f);

                yield return null;
            }
            sr[i].material.color = tempColor[i];
        }

        if (nextEvent != null) nextEvent();
    }

    // 불투명 -> 투명
    public override IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        var sr = _listMaterial;

        List<Color> tempColor = new List<Color>();

        for (int i = 0; i < _listMaterial.Count; ++i)
        {
            tempColor.Add(_listMaterial[i].material.color);
        }
        for (int i = 0; i < _tempMaterial.Count; ++i)
        {
            float cnt = 0;
            while (tempColor[i].a > 0f)
            {
                cnt -= Time.deltaTime / fadeOutTime;
                tempColor[i] = new Color(1, 1, 1, cnt);
                sr[i].material.color = tempColor[i];

                if (tempColor[i].a <= 0f) tempColor[i] = new Color(1f, 1f, 1f, 0f);

                yield return null;
            }
            sr[i].material.color = tempColor[i];
        }
        if (nextEvent != null) nextEvent();
    }

}
