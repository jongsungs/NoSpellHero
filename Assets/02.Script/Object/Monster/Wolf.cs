using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wolf : Monster
{

   public List<SkinnedMeshRenderer> _material;
   public List<SkinnedMeshRenderer> _tempMaterial;

    private void Start()
    {


        _monster = MonsterKind.Wolf;

        _tempMaterial = _material;
        FadeIn();

        _state = State.Walk;
        Debug.Log("���� ����");
    }

    private void Update()
    {



        if (_hp <= 0f)
        {
            ChangeState(State.Die);

        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Freezing();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Burn();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Stun();
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
                break;
        }
    }
    public override void Burn()
    {
        base.Burn();
        for(int i = 0; i < _material.Count; ++i)
        {
            _material[i].material.color = Color.red;

        }
    }
    public override void Freezing()
    {
        base.Freezing();

    }

    public override void CCrecovery()
    {
        base.CCrecovery();
        for (int i = 0; i < _material.Count; ++i)
        {
            _material[i].material.color = Color.white;

        }

        Debug.Log("ȸ��");
    }

    private void OnTriggerEnter(Collider other)
    {



        if (other.CompareTag("Weapon"))
        {

            if (other.GetComponent<Weapon>()._isOnce == true && Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
            {
                other.GetComponent<Weapon>()._isOnce = false;
                ChangeState(State.Hit);
                int _30 = Random.Range(0, 3); // 30��Ȯ���� ����
                if (_30 == 0)
                {
                    Freezing();
                    Debug.Log("���屺 ����");

                }

                var damage = other.GetComponent<Weapon>()._damage + (Player.Instance._atk * 5) - (_def * 3);
                _hp -= damage;
                _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

            }
            else if (other.GetComponent<Weapon>()._isOnce == true && Player.Instance._playerTitle == Player.PlayerTitle.Druid)
            {
                other.GetComponent<Weapon>()._isOnce = false;
                ChangeState(State.Hit);
                _hp -= other.GetComponent<Weapon>()._damage;
                int rand = Random.Range(0, 10 - _player.GetComponent<Player>()._skill1);

                if (rand == 0)
                {

                    m_targetMask = 64;
                    if (Player.Instance.druidfirstskill == false)
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
            else if (other.GetComponent<Weapon>()._isOnce == true && Player.Instance._playerTitle == Player.PlayerTitle.QRF && Player.Instance._skill2 >= 3f && Player.Instance._isHanger == true)
            {
                other.GetComponent<Weapon>()._isOnce = false;
                ChangeState(State.Hit);
                int rand = Random.Range(0, 3);
                if (rand == 0)
                {
                    Stun();
                }
            }
            else if (other.GetComponent<Weapon>()._isOnce == true && Player.Instance._playerTitle == Player.PlayerTitle.Acupuncturist)
            {
                other.GetComponent<Weapon>()._isOnce = false;
                ChangeState(State.Hit);
                int rand = Random.Range(0, 100);
                Player.Instance._comboInstantDie.Add(rand);

                if (rand < Player.Instance._instantDeathProbablility)
                {

                    int damage = 999999;
                    _hp -= damage;
                    _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                    if (Player.Instance.acupuncturistfirstskill == false)
                    {
                        Player.Instance.acupuncturistfirstskill = true;
                        AchievementManager.instance.Unlock("acupuncturistfirstskill");
                    }
                }
                else if (rand >= Player.Instance._instantDeathProbablility)
                {
                    var damage = other.GetComponent<Weapon>()._damage + (Player.Instance._atk * 5) - (_def * 3);
                    _hp -= damage;
                    _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                }

                if (Player.Instance._comboInstantDie.Count >= 3 && Player.Instance._comboInstantDie.Exists(x => x < Player.Instance._instantDeathProbablility) == false && Player.Instance.acupuncturistcritical == false)
                {
                    Player.Instance.acupuncturistcritical = true;
                    AchievementManager.instance.Unlock("acupuncturistcritical");
                }
                if (Player.Instance._comboInstantDie.Exists(x => x >= Player.Instance._instantDeathProbablility) == true)
                {
                    Player.Instance._comboInstantDie.Clear();
                }



            }
            else if (other.GetComponent<Weapon>()._isOnce == true && Player.Instance._playerTitle == Player.PlayerTitle.DokeV)
            {
                int rand = Random.Range(0, 100);
                other.GetComponent<Weapon>()._isOnce = false;
                var damage = other.GetComponent<Weapon>()._damage + (Player.Instance._atk * 5) - (_def * 3);
                _hp -= damage;
                ChangeState(State.Hit);
                _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                if (rand < Player.Instance._dokevSkillProbability)
                {
                    int rand2 = Random.Range(0, 9);
                    float stat;
                    if (rand == 0)
                    {
                        stat = _basicHp - (_basicHp * 0.1f);

                        _hp = stat;
                        Player.Instance._hp += stat;

                    }
                    else if (rand == 1)
                    {
                        stat = _basicAtk - (_basicAtk * 0.1f);

                        _atk = stat;
                        Player.Instance._atk += stat;
                    }
                    else if (rand == 2)
                    {
                        stat = _basicMatk - (_basicMatk * 0.1f);

                        _matk = stat;
                        Player.Instance._matk += stat;
                    }
                    else if (rand == 3)
                    {
                        stat = _basicAtkSpeed - (_basicAtkSpeed * 0.1f);

                        _atkSpeed = stat;
                        Player.Instance._atkSpeed += stat;
                    }
                    else if (rand == 4)
                    {
                        stat = _basicDef - (_basicDef * 0.1f);

                        _def = stat;
                        Player.Instance._def += stat;
                    }
                    else if (rand == 5)
                    {
                        stat = _basicSpeed - (_basicSpeed * 0.1f);

                        _speed = stat;
                        Player.Instance._speed += stat;
                    }
                    else if (rand == 6)
                    {
                        stat = _basicCritical - (_basicCritical * 0.1f);

                        _critical = stat;
                        Player.Instance._critical += stat;
                    }
                    else if (rand == 7)
                    {
                        stat = _basicHandicraft - (_basicHandicraft * 0.1f);

                        _critical = stat;
                        Player.Instance._critical += stat;
                    }
                    else if (rand == 8)
                    {
                        stat = _basicCharm - (_basicCharm * 0.1f);

                        _charm = stat;
                        Player.Instance._charm += stat;
                    }

                    if (Player.Instance.dokevfirstskill == false)
                    {
                        Player.Instance.dokevfirstskill = true;
                        AchievementManager.instance.Unlock("dokevfirstskill");
                    }

                }






            }
            else if (other.GetComponent<Weapon>()._isOnce == true)
            {

                other.GetComponent<Weapon>()._isOnce = false;
                Debug.Log("�������ؽ�Ʈ");

                //ChangeState(State.Hit);
                var damage = other.GetComponent<Weapon>()._damage + (Player.Instance._atk * 5) - (_def * 3);
                _hp -= damage;
                _mmfPlayer.PlayFeedbacks(transform.position, damage);
            }

        }
        else if (other.CompareTag("IceBall"))
        {

            //  ChangeState(State.Hit);
            var damage = other.GetComponent<Weapon>()._damage + (Player.Instance._matk * 5) - (_def * 3);

            int _30 = Random.Range(0, 3); // 30��Ȯ���� ����

            if (_30 == 0)
            {
                Freezing();

            }
        }
        else if (other.CompareTag("FireBall"))
        {
            // ChangeState(State.Hit);
            var damage = other.GetComponent<Weapon>()._damage + (Player.Instance._matk * 5) - (_def * 3);
            int _30 = Random.Range(0, 3);
            if (_30 == 0)
            {
                Burn();
            }
        }
        else if (other.CompareTag("Thunder"))
        {
            // ChangeState(State.Hit);
            var damage = other.GetComponent<Weapon>()._damage + (Player.Instance._matk * 5) - (_def * 3);
            _hp -= damage;
            _mmfPlayer.PlayFeedbacks(transform.position, damage);

        }
        else if (other.CompareTag("Meteor"))
        {
            // ChangeState(State.Hit);
            var damage = other.GetComponent<Weapon>()._damage + (Player.Instance._matk * 5) - (_def * 3);
            _hp -= damage;
            _mmfPlayer.PlayFeedbacks(transform.position, damage);
        }



    }

    public override void Walk()
    {
        ChangeState(State.Walk);
    }

    public void AttackOff()
    {
        _isAttack = false;
        _attackOnce = true;
        Walk();
    }

    public override void MonsterRelease()
    {
        _hp = 0f;
    }
    public void ChangeIndex(List<Color> list, int index, float cnt, Color temp)
    {
        temp = list[index];
        temp.r = cnt;
        list[index] = temp;
    }

    public override IEnumerator CoFadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        var sr = _material;
        List<Color> tempColor = new List<Color>();
   
        for(int i = 0; i < _material.Count; ++i)
        {
            tempColor.Add(_material[i].material.color);
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

    // ������ -> ����
    public override IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        var sr = _material;

        List<Color> tempColor = new List<Color>();

        for (int i = 0; i < _material.Count; ++i)
        {
            tempColor.Add(_material[i].material.color);
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
