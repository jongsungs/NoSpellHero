using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class Skeleton : Monster
{


    public List<SkinnedMeshRenderer> _tempMaterial;

    public SkillBase _bone;
    public IObjectPool<SkillBase> _bonePool;
    public GameObject _objectPool;
    public GameObject _skillBarrel;


    private void Start()
    {

        _bonePool = new ObjectPool<SkillBase>(CreateBone, OngetBone, OnReleaseBone, OnDestroyBone, maxSize: 10);
        _tempMaterial = _listMaterial;
        FadeIn();

        _state = State.Walk;
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
                _speed = 0f;
                _attackOnce = false;
                _attackStack++;
                break;
            case State.Hit:
                _speed = 0f;

                break;
            case State.Die:
                _speed = 0f;
                StartCoroutine(CoDie());
                if(_category == MonsterCategory.Boss && _isDead == false)
                {
                    _isDead = true;
                    GamePlay.Instance.BossDie();
                   // GamePlay.Instance.ChangeStage();
                }

                break;
            case State.Attack2:
                _speed = 0f;
                _attackOnce = false;
                SkeletonSpawn();
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

    public override void AttackOff()
    {
        base.AttackOff();
        _attackOnce = true;
        Walk();
    }
    public void AttackOff2()
    {
        
        _attackOnce = true;

        _attackStack = 0;
        Walk();
    }
    public void Bone()
    {
        if(_monster == MonsterKind.CaptainSkull )
        {
            _bonePool.Get();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._result);

        }
    }

    public override void MonsterRelease()
    {
        _ingameHp = 0f;
    }

    public void SkeletonSpawn()
    {
        GamePlay.Instance._skeletonPool.Get();
    }


    ///--------뼈다귀 던지기
    private SkillBase CreateBone()
    {
        var bone = Instantiate(_bone, _skillBarrel.transform.position, transform.rotation, _objectPool.transform);
        bone.SetPool(_bonePool);
        return bone;
    }
    private void OngetBone(SkillBase skill)
    {
        skill.transform.position = _skillBarrel.transform.position;
        skill.transform.rotation = transform.rotation;
        skill.gameObject.SetActive(true);
    }

    private void OnReleaseBone(SkillBase skill)
    {
        skill.gameObject.SetActive(false);
    }
    private void OnDestroyBone(SkillBase skill)
    {
        Destroy(skill.gameObject);
    }

    ///--------------------------------



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
