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

        if (Player.Instance._isAttack == false)
        {
            _onHit = false;
        }

        if (_ingameHp <= 0f)
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
                    GamePlay.Instance.BossDie(GamePlay.Instance._currentStage + 1);
                    GamePlay.Instance.ChangeStage();
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

        Debug.Log("È¸º¹");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {

            if (Player.Instance._isAttack == true && Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
            {
                Player.Instance._isAttack = false;
                int _30 = Random.Range(0, 3); // 30ÆÛÈ®·ü·Î ºù°á
                if (_30 == 0)
                {
                    Freezing();
                    Debug.Log("µ¿Àå±º µîÀå");

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
            int _30 = Random.Range(0, 3); // 30ÆÛÈ®·ü·Î ºù°á

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


                other.GetComponent<SkillBase>().SkillRelease();
            }
            StartCoroutine(CoHit());
        }





    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("FireBall"))
        {
            int rand = Random.Range(0, 100);



            if (rand < Player.Instance._criticalProbability)
            {

                if(_category == MonsterCategory.Common)
                {

                    var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5)) * Player.Instance._criticalDamage - (_def * 3);
                    _ingameHp -= damage;


                    _floatingTextSpawner.AnimateColorGradient = redgrad;
                    _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                }
                else if(_category == MonsterCategory.Boss)
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
    public void AttackOff2()
    {
        _isAttack = false;
        _attackOnce = true;

        _attackStack = 0;
        Walk();
    }
    public void Bone()
    {
        if(_monster == MonsterKind.CaptainSkull && _category == MonsterCategory.Boss)
        {
            _bonePool.Get();

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


    ///--------»À´Ù±Í ´øÁö±â
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

    // ºÒÅõ¸í -> Åõ¸í
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
