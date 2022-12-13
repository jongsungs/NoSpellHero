using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wolf : Monster
{

  
   public List<SkinnedMeshRenderer> _tempMaterial;

    private void Start()
    {


        _monster = MonsterKind.Wolf;

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
        }
    }
    public override void Burn()
    {
        base.Burn();
        for(int i = 0; i < _listMaterial.Count; ++i)
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
        Walk();
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
   
        for(int i = 0; i < _listMaterial.Count; ++i)
        {
            tempColor.Add(_listMaterial[i].material.color);
        }
   
        for (int i = 0; i < _tempMaterial.Count; ++i)
        {
            float cnt = 0;
            while (tempColor[i].a < 1f)
            {
                cnt += Time.deltaTime / fadeOutTime;
                tempColor[i] =new Color(1,1,1, cnt);
                sr[i].material.color = tempColor[i];
   
                if (tempColor[i].a >= 1f) tempColor[i]= new Color(1f,1f,1f, 1f);
   
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
