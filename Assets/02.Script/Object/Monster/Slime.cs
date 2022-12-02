using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : Monster
{

    MeshRenderer _material;
    MeshRenderer _tempMaterial;

    private void Start()
    {
        

        _monster = MonsterKind.Slime;
        
        _material = GetComponent<MeshRenderer>();
        _tempMaterial = _material;
        FadeIn();
        
        _state = State.Walk;
        Debug.Log("슬라임 시작");
    }

    private void Update()
    {
        
        
        
        if(_ingameHp <= 0f)
        {
            ChangeState(State.Die);

        }
        if(Player.Instance._isAttack == false)
        {
            _onHit = false;
        }

       


        if(_CC != CrowdControl.Freezing || _CC != CrowdControl.Stun)
        {
            _navimeshAgent.speed = _speed;

        }
      
        
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
        _material.material.color = Color.red;
    }
    public override void Freezing()
    {
        base.Freezing();

    }
   
    public override void CCrecovery()
    {
        base.CCrecovery();
        _material.material.color = Color.green;
       
        Debug.Log("회복");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {

            if (Player.Instance._isAttack == true && Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
            {
                Player.Instance._isAttack = false;
                int _30 = Random.Range(0, 3); // 30퍼확률로 빙결
                if (_30 == 0)
                {
                    Freezing();
                    Debug.Log("동장군 등장");

                }

                int rand = Random.Range(0, 100);



                if (rand < Player.Instance._criticalProbability)
                {

                    if (_category == MonsterCategory.Common)
                    {

                        var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                        _ingameHp -= damage;


                        _floatingTextSpawner.AnimateColorGradient = redgrad;
                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                    }
                    else if (_category == MonsterCategory.Boss)
                    {
                        var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                        _ingameHp -= damage;


                        _floatingTextSpawner.AnimateColorGradient = redgrad;
                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                    }

                }
                else if (rand >= Player.Instance._criticalProbability)
                {
                    if (_category == MonsterCategory.Common)
                    {
                        var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5) - (_def * 3);
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                    }

                    else if (_category == MonsterCategory.Boss)
                    {

                        var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5) - (_def * 3);
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                    }


                }
                StartCoroutine(CoHit());

            }
            else if (Player.Instance._isAttack == true && Player.Instance._playerTitle == Player.PlayerTitle.Druid)
            {
                Player.Instance._isAttack = false;

                int rand = Random.Range(0, 100);



                if (rand < Player.Instance._criticalProbability)
                {

                    if (_category == MonsterCategory.Common)
                    {

                        var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                        _ingameHp -= damage;


                        _floatingTextSpawner.AnimateColorGradient = redgrad;
                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                    }
                    else if (_category == MonsterCategory.Boss)
                    {
                        var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                        _ingameHp -= damage;


                        _floatingTextSpawner.AnimateColorGradient = redgrad;
                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                    }

                }
                else if (rand >= Player.Instance._criticalProbability)
                {
                    if (_category == MonsterCategory.Common)
                    {
                        var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5) - (_def * 3);
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                    }

                    else if (_category == MonsterCategory.Boss)
                    {

                        var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5) - (_def * 3);
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                    }


                }
                int rand2 = Random.Range(0, 1/* - Player.Instance._skill1*/);
                if (rand2 == 0 && _category == MonsterCategory.Common)
                {

                    _fascination.SetActive(true);
                    m_targetMask = 64;
                    this.gameObject.layer = 3;
                    this.gameObject.tag = "Player";
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
                StartCoroutine(CoHit());

            }
            else if (Player.Instance._isAttack == true && Player.Instance._playerTitle == Player.PlayerTitle.QRF && Player.Instance._skill2 >= 3f && Player.Instance._isHanger == true)
            {
                Player.Instance._isAttack = false;
                int rand = Random.Range(0, 100);
                if (rand < Player.Instance._criticalProbability)
                {

                    if (_category == MonsterCategory.Common)
                    {

                        var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                        _ingameHp -= damage;


                        _floatingTextSpawner.AnimateColorGradient = redgrad;
                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                    }
                    else if (_category == MonsterCategory.Boss)
                    {
                        var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                        _ingameHp -= damage;


                        _floatingTextSpawner.AnimateColorGradient = redgrad;
                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                    }

                }
                else if (rand >= Player.Instance._criticalProbability)
                {
                    if (_category == MonsterCategory.Common)
                    {
                        var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5) - (_def * 3);
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                    }

                    else if (_category == MonsterCategory.Boss)
                    {

                        var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5) - (_def * 3);
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                    }


                }
                int rand2 = Random.Range(0, 3);
                if (rand2 == 0)
                {
                    Stun();
                }
                StartCoroutine(CoHit());
            }
            else if (Player.Instance._isAttack == true && Player.Instance._playerTitle == Player.PlayerTitle.Acupuncturist)
            {
                Player.Instance._isAttack = false;
                int rand = Random.Range(0, 100);
                Player.Instance._comboInstantDie.Add(rand);

                if (rand < Player.Instance._instantDeathProbablility)
                {
                    if (_category == MonsterCategory.Common)
                    {

                        int damage = 999999;
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = redgrad;

                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                        if (Player.Instance.acupuncturistfirstskill == false)
                        {
                            Player.Instance.acupuncturistfirstskill = true;
                            AchievementManager.instance.Unlock("acupuncturistfirstskill");
                            Player.Instance.Save();
                        }
                    }
                    else if (_category == MonsterCategory.Boss)
                    {
                        var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                        _ingameHp -= damage;


                        _floatingTextSpawner.AnimateColorGradient = redgrad;
                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                    }
                }
                else if (rand >= Player.Instance._instantDeathProbablility)
                {
                    if (_category == MonsterCategory.Common)
                    {
                        var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5) - (_def * 3);
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                    }

                    else if (_category == MonsterCategory.Boss)
                    {

                        var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5) - (_def * 3);
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                    }
                }

                if (Player.Instance._comboInstantDie.Count >= 3 && Player.Instance._comboInstantDie.Exists(x => x < Player.Instance._instantDeathProbablility) == false && Player.Instance.acupuncturistcritical == false)
                {
                    Player.Instance.acupuncturistcritical = true;
                    AchievementManager.instance.Unlock("acupuncturistcritical");
                    Player.Instance.Save();
                }
                if (Player.Instance._comboInstantDie.Exists(x => x >= Player.Instance._instantDeathProbablility) == true)
                {
                    Player.Instance._comboInstantDie.Clear();
                }

                StartCoroutine(CoHit());

            }
            else if (Player.Instance._isAttack == true && Player.Instance._playerTitle == Player.PlayerTitle.DokeV)
            {
                Player.Instance._isAttack = false;
                int rand = Random.Range(0, 100);


                if (rand < Player.Instance._criticalProbability)
                {

                    if (_category == MonsterCategory.Common)
                    {

                        var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                        _ingameHp -= damage;


                        _floatingTextSpawner.AnimateColorGradient = redgrad;
                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                    }
                    else if (_category == MonsterCategory.Boss)
                    {
                        var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                        _ingameHp -= damage;


                        _floatingTextSpawner.AnimateColorGradient = redgrad;
                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                    }

                }
                else if (rand >= Player.Instance._criticalProbability)
                {
                    if (_category == MonsterCategory.Common)
                    {
                        var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5) - (_def * 3);
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                    }

                    else if (_category == MonsterCategory.Boss)
                    {

                        var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5) - (_def * 3);
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                    }


                }

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
                        Player.Instance.Save();
                    }

                }


                StartCoroutine(CoHit());



            }
            else if (_onHit == false && Player.Instance._isAttack == true)
            {

                _onHit = true;

                if (_category == MonsterCategory.Common)
                {
                    int rand = Random.Range(0, 100);



                    if (rand < Player.Instance._criticalProbability)
                    {
                        var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                        _ingameHp -= damage;


                        _floatingTextSpawner.AnimateColorGradient = redgrad;


                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                    }
                    else if (rand >= Player.Instance._criticalProbability)
                    {
                        var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5) - (_def * 3);
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);


                    }
                }
                else if (_category == MonsterCategory.Boss)
                {
                    int rand = Random.Range(0, 100);



                    if (rand < Player.Instance._criticalProbability)
                    {
                        var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                        _ingameHp -= damage;


                        _floatingTextSpawner.AnimateColorGradient = redgrad;


                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                    }
                    else if (rand >= Player.Instance._criticalProbability)
                    {
                        var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5) - (_def * 3);
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);


                    }
                }

                StartCoroutine(CoHit());

            }
           


        }
        else if (other.CompareTag("IceBall"))
        {

            //  ChangeState(State.Hit);
            int rand = Random.Range(0, 100);



            if (rand < Player.Instance._criticalProbability)
            {

                if (_category == MonsterCategory.Common)
                {

                    var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                    _ingameHp -= damage;


                    _floatingTextSpawner.AnimateColorGradient = redgrad;
                    _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                }
                else if (_category == MonsterCategory.Boss)
                {
                    var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                    _ingameHp -= damage;


                    _floatingTextSpawner.AnimateColorGradient = redgrad;
                    _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                    GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                }

            }
            else if (rand >= Player.Instance._criticalProbability)
            {
                if (_category == MonsterCategory.Common)
                {
                    var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5) - (_def * 3);
                    _ingameHp -= damage;
                    _floatingTextSpawner.AnimateColorGradient = whitegrad;
                    _mmfPlayer.PlayFeedbacks(transform.position, damage);
                }

                else if (_category == MonsterCategory.Boss)
                {

                    var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5) - (_def * 3);
                    _ingameHp -= damage;
                    _floatingTextSpawner.AnimateColorGradient = whitegrad;
                    _mmfPlayer.PlayFeedbacks(transform.position, damage);
                    GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                }


            }
            int _30 = Random.Range(0, 3); // 30퍼확률로 빙결

            StartCoroutine(CoHit());
            if (_30 == 0)
            {
                Freezing();

            }
        }
        else if (other.CompareTag("FireBall"))
        {
            // ChangeState(State.Hit);
            int rand = Random.Range(0, 100);



            if (rand < Player.Instance._criticalProbability)
            {

                if (_category == MonsterCategory.Common)
                {

                    var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                    _ingameHp -= damage;


                    _floatingTextSpawner.AnimateColorGradient = redgrad;
                    _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                }
                else if (_category == MonsterCategory.Boss)
                {
                    var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                    _ingameHp -= damage;


                    _floatingTextSpawner.AnimateColorGradient = redgrad;
                    _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                    GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                }

            }
            else if (rand >= Player.Instance._criticalProbability)
            {
                if (_category == MonsterCategory.Common)
                {
                    var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5) - (_def * 3);
                    _ingameHp -= damage;
                    _floatingTextSpawner.AnimateColorGradient = whitegrad;
                    _mmfPlayer.PlayFeedbacks(transform.position, damage);
                }

                else if (_category == MonsterCategory.Boss)
                {

                    var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5) - (_def * 3);
                    _ingameHp -= damage;
                    _floatingTextSpawner.AnimateColorGradient = whitegrad;
                    _mmfPlayer.PlayFeedbacks(transform.position, damage);
                    GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                }


            }
            StartCoroutine(CoHit());
            int _30 = Random.Range(0, 3);
            if (_30 == 0)
            {
                Burn();
            }
        }
        else if (other.CompareTag("Thunder"))
        {
            // ChangeState(State.Hit);
            int rand = Random.Range(0, 100);



            if (rand < Player.Instance._criticalProbability)
            {

                if (_category == MonsterCategory.Common)
                {

                    var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                    _ingameHp -= damage;


                    _floatingTextSpawner.AnimateColorGradient = redgrad;
                    _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                }
                else if (_category == MonsterCategory.Boss)
                {
                    var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                    _ingameHp -= damage;


                    _floatingTextSpawner.AnimateColorGradient = redgrad;
                    _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                    GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                }

            }
            else if (rand >= Player.Instance._criticalProbability)
            {
                if (_category == MonsterCategory.Common)
                {
                    var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5) - (_def * 3);
                    _ingameHp -= damage;
                    _floatingTextSpawner.AnimateColorGradient = whitegrad;
                    _mmfPlayer.PlayFeedbacks(transform.position, damage);
                }

                else if (_category == MonsterCategory.Boss)
                {

                    var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5) - (_def * 3);
                    _ingameHp -= damage;
                    _floatingTextSpawner.AnimateColorGradient = whitegrad;
                    _mmfPlayer.PlayFeedbacks(transform.position, damage);
                    GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                }


            }
            StartCoroutine(CoHit());
        }
        else if (other.CompareTag("Meteor"))
        {
            int rand = Random.Range(0, 100);



            if (rand < Player.Instance._criticalProbability)
            {

                if (_category == MonsterCategory.Common)
                {

                    var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                    _ingameHp -= damage;


                    _floatingTextSpawner.AnimateColorGradient = redgrad;
                    _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                }
                else if (_category == MonsterCategory.Boss)
                {
                    var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                    _ingameHp -= damage;


                    _floatingTextSpawner.AnimateColorGradient = redgrad;
                    _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                    GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                }

            }
            else if (rand >= Player.Instance._criticalProbability)
            {
                if (_category == MonsterCategory.Common)
                {
                    var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5) - (_def * 3);
                    _ingameHp -= damage;
                    _floatingTextSpawner.AnimateColorGradient = whitegrad;
                    _mmfPlayer.PlayFeedbacks(transform.position, damage);
                }

                else if (_category == MonsterCategory.Boss)
                {

                    var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5) - (_def * 3);
                    _ingameHp -= damage;
                    _floatingTextSpawner.AnimateColorGradient = whitegrad;
                    _mmfPlayer.PlayFeedbacks(transform.position, damage);
                    GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                }


            }
            StartCoroutine(CoHit());
        }
        else if (this.gameObject.layer == 3)
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

                StartCoroutine(CoHit());
                other.GetComponent<SkillBase>().SkillRelease();
            }
            
        }





    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("FireBall"))
        {
            int rand = Random.Range(0, 100);



            if (rand < Player.Instance._criticalProbability)
            {

                if (_category == MonsterCategory.Common)
                {

                    var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                    _ingameHp -= damage;


                    _floatingTextSpawner.AnimateColorGradient = redgrad;
                    _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                }
                else if (_category == MonsterCategory.Boss)
                {
                    var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                    _ingameHp -= damage;


                    _floatingTextSpawner.AnimateColorGradient = redgrad;
                    _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                    GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                }

            }
            else if (rand >= Player.Instance._criticalProbability)
            {
                if (_category == MonsterCategory.Common)
                {
                    var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5) - (_def * 3);
                    _ingameHp -= damage;
                    _floatingTextSpawner.AnimateColorGradient = whitegrad;
                    _mmfPlayer.PlayFeedbacks(transform.position, damage);
                }

                else if (_category == MonsterCategory.Boss)
                {

                    var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5) - (_def * 3);
                    _ingameHp -= damage;
                    _floatingTextSpawner.AnimateColorGradient = whitegrad;
                    _mmfPlayer.PlayFeedbacks(transform.position, damage);
                    GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                }


            }
            int _30 = Random.Range(0, 3);
            StartCoroutine(CoHit());
            if (_30 == 0)
            {
                Burn();
            }
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

    public override void MonsterRelease()
    {
        _ingameHp = 0f;
    }


  public override  IEnumerator CoFadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        var sr = _material;
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
    public override IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        var sr = _material;

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
