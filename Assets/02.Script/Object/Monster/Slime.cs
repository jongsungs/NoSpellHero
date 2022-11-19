using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : Monster
{

    SkinnedMeshRenderer _material;
    SkinnedMeshRenderer _tempMaterial;


    protected override void Start()
    {
        base.Start();

        _monster = MonsterKind.Slime;
        _material = this.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
        _tempMaterial = _material;
        FadeIn();
        GamePlay._eventHandler += MonsterRelease;
        _state = State.Walk;
        Debug.Log("슬라임 시작");
    }

    private void Update()
    {
        
        
        
        if(_hp <= 0f)
        {
            ChangeState(State.Die);

        }



        if(_CC != CrowdControl.Freezing)
        {
            _navimeshAgent.speed = _speed;

        }
      
        
    }


    public override void Idle()
    {
        ChangeState(State.Idle);
    }







    public override void ChangeState(State state)
    {
        base.ChangeState(state);
        _animator.SetInteger(_aniHashKeyState, (int)_state);
        Color _temp = _tempMaterial.material.color;
        switch (_state)
        {
            case State.Idle:
                _speed = 0f;
                
                break;
            case State.Walk:
                _speed =  _basicSpeed;
              
                break;
            case State.Attack:
                _speed = 0f;

                break;
            case State.Hit:
                _speed = 0f;

                break;
            case State.Die:
                _speed = 0f;
                StartCoroutine(CoDie());
                break;
        }
    }
    public override void Burn()
    {
        base.Burn();
        _material.material.color = Color.red;
    }
    public override void Freezing()
    {
        base.Freezing();
        
        _material.material.color = Color.blue;
    }
   
    public override void CCrecovery()
    {
        base.CCrecovery();
        _material.material.color = Color.white; 
       
        Debug.Log("회복");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
     
        if (other.CompareTag("Weapon") )
        {
            
            if(other.GetComponent<Weapon>()._isOnce == true && Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
            {
                other.GetComponent<Weapon>()._isOnce = false;
                ChangeState(State.Hit);
                int _30 = Random.Range(0, 3); // 30퍼확률로 빙결
                if (_30 == 0)
                {
                    Freezing();
                    Debug.Log("동장군 등장");

                }

                var damage = other.GetComponent<Weapon>()._damage + (Player.Instance._atk * 5) - (_def * 3);
                _hp -= damage;
                _feedBack.PlayFeedbacks(this.transform.position,damage);
              
            }
            else if(other.GetComponent<Weapon>()._isOnce == true && Player.Instance._playerTitle == Player.PlayerTitle.Druid)
            {
                other.GetComponent<Weapon>()._isOnce = false;
                ChangeState(State.Hit);
                _hp -= other.GetComponent<Weapon>()._damage;
                int rand = Random.Range(0, 10 - _player.GetComponent<Player>()._skill1);

                if(rand == 0)
                {
                
                    m_targetMask = 64;
                    if(Player.Instance.druidfirstskill == false)
                    {
                        Player.Instance.druidfirstskill = true;
                    }
                    Player.Instance._druidScore++;
                    AchievementManager.instance.AddAchievementProgress("druidskill100", Player.Instance._druidScore);

                  //  if (Player.Instance._druidScore >= 100 && Player.Instance.druidskill100 == false)
                  //  {
                  //      Player.Instance.druidskill100 = true;
                  //      AchievementManager.instance.Unlock("druidskill100");
                  //  }


                }

            }
            else if(other.GetComponent<Weapon>()._isOnce == true && Player.Instance._playerTitle == Player.PlayerTitle.QRF && Player.Instance._skill2 >= 3f &&Player.Instance._isHanger == true)
            {
                other.GetComponent<Weapon>()._isOnce = false;
                ChangeState(State.Hit);
                int rand = Random.Range(0, 3);
                if(rand == 0)
                {
                    Stun();
                }
            }
            else if (other.GetComponent<Weapon>()._isOnce == true && Player.Instance._playerTitle == Player.PlayerTitle.Acupuncturist)
            {
                other.GetComponent<Weapon>()._isOnce = false;
                ChangeState(State.Hit);
                int rand = Random.Range(0, 100);
                if(rand <Player.Instance._instantDeathProbablility)
                {
                    int damage = 999999;
                    _hp -= damage;
                    _feedBack.PlayFeedbacks(this.transform.position, damage);
                }
                else if(rand >= Player.Instance._instantDeathProbablility)
                {
                    var damage = other.GetComponent<Weapon>()._damage + (Player.Instance._atk * 5) - (_def * 3);
                    _hp -= damage;
                    _feedBack.PlayFeedbacks(this.transform.position, damage);
                }

            }
            else if (other.GetComponent<Weapon>()._isOnce == true)
            {

                other.GetComponent<Weapon>()._isOnce = false;
                Debug.Log("여기여기");

                ChangeState(State.Hit);
                var damage = other.GetComponent<Weapon>()._damage + (Player.Instance._atk * 5) - (_def * 3);
                _hp -= damage;
                _feedBack.PlayFeedbacks(this.transform.position, damage);
            }

        }

        if (other.CompareTag("IceBall"))
        {

            ChangeState(State.Hit);
            var damage = other.GetComponent<Weapon>()._damage + (Player.Instance._matk * 5) - (_def * 3);

            int _30 = Random.Range(0, 3); // 30퍼확률로 빙결

            if (_30 == 0)
            {
                Freezing();
       
            }
        }
        

        if(other.CompareTag("FireBall") )
        {
            ChangeState(State.Hit);
            var damage = other.GetComponent<Weapon>()._damage + (Player.Instance._matk * 5) - (_def * 3);
            int _30 = Random.Range(0, 3);
            if(_30 == 0)
            {
                Burn();
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Weapon"))
        {

        }
    }

   public IEnumerator CoDie()
    {
        _layerMask = 0;
        StartCoroutine(CoFadeOut(1f));
        yield return new WaitForSeconds(2f);
        if(_CC == CrowdControl.Freezing && Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
        {
            Player.Instance._jackfrostScore++;
            AchievementManager.instance.AddAchievementProgress("jackfrosttuna", Player.Instance._jackfrostScore);
            
        }
       // if(Player.Instance._jackfrostScore >= 1000 && Player.Instance.jackfrosttuna == false)
       // {
       //     Player.Instance.jackfrosttuna = true;
       //     AchievementManager.instance.Unlock("jackfrosttuna");
       // }



        _monsterpool.Release(this);
    }

    public override void MonsterRelease()
    {
        _hp = 0f;
    }



    // 투명 -> 불투명
    IEnumerator CoFadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        var sr = this.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
        Color tempColor = sr.material.color;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeOutTime;
            sr.material.color = tempColor;

            if (tempColor.a >= 1f) tempColor.a = 1f;

            yield return null;
        }

        sr.material.color = tempColor;
        if (nextEvent != null) nextEvent();
    }

    // 불투명 -> 투명
    IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        var sr = this.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
        
        Color tempColor = sr.material.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            sr.material.color = tempColor;

            if (tempColor.a <= 0f) tempColor.a = 0f;

            yield return null;
        }
        sr.material.color = tempColor;
        if (nextEvent != null) nextEvent();
    }
   

}
