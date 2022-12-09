using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Monster : BaseObject
{

    public enum MonsterCategory : int
    {
        Common,
        Boss,
    }

    public enum MonsterKind : int
    {
        Slime = 0,
        Wolf,
        CaptainSkull,
        Skull,
        DemonKing,
        Golem,
        Ork,
        Dragon,
        None,
        WolfKing,

    }
    


    protected IObjectPool<Monster> _monsterpool;

    protected GameObject _player;
    public NavMeshAgent _navimeshAgent;
    public bool _onHit;
    public float _ccDurationTime;
    public float _currentTime;
    protected bool _ccOn = false;
    public bool _isDead;
    public MonsterKind _monster;
    public MonsterCategory _category;
    public LayerMask _layerMask;
    public GameObject _frozen;
    public GameObject _burn;
    public GameObject _sturn;
    public GameObject _fascination;
    public MoreMountains.Feedbacks.MMFloatingTextSpawner _floatingTextSpawner;
    public MoreMountains.Feedbacks.MMF_Player _mmfPlayer;

    public Color _hitColor;
    public Color _slimeColor;



    protected Transform m_transform;
    [SerializeField] float m_viewAngle;    //시야각
    [SerializeField] float m_viewDistance; //시야거리

    public LayerMask m_targetMask;  //Enemy 레이어마스크 지정을 위한 변수
    public LayerMask m_obstacleMask; //Obstacle 레이어마스크 지정을 위한 변수

    public bool _attackOnce;
    public float _attackDistance;
    public List<SkinnedMeshRenderer> _listMaterial;
    public MeshRenderer _onlySlime;
    public int _attackStack;
    public Weapon _monsterWeapon;


   public Gradient whitegrad = new Gradient();
   public Gradient redgrad = new Gradient();
    Color _red = new Color(1, 0, 0);
    Color _white = new Color(1, 1, 1);
    GradientColorKey[] redkey = new GradientColorKey[2];
    GradientAlphaKey[] redakey = new GradientAlphaKey[2];
    GradientColorKey[] whitekey = new GradientColorKey[2];
    GradientAlphaKey[] whiteakey = new GradientAlphaKey[2];





    private void Awake()
    {
       
        _navimeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        m_transform = GetComponent<Transform>();
        _floatingTextSpawner = transform.GetChild(0).GetChild(0).GetComponent<MoreMountains.Feedbacks.MMFloatingTextSpawner>();
        _mmfPlayer = transform.GetChild(0).GetChild(1).GetComponent<MoreMountains.Feedbacks.MMF_Player>();
        _navimeshAgent.stoppingDistance = _attackDistance;
    

        if (_burn != null)
        _burn.SetActive(false);
        if(_frozen != null)
        _frozen.SetActive(false);
        if (_sturn != null)
            _sturn.SetActive(false);
        if (_fascination != null)
            _fascination.SetActive(false);
        _attackOnce = true;
        redkey[0].color = _red;
        redkey[0].time = 0;
        redkey[1].color = _white;
        redkey[1].time = 1;
        redakey[0].alpha = 1;
        redakey[0].time = 0;
        redakey[1].alpha = 1;
        redakey[1].time = 1;
        whitekey[0].color = _white;
        whitekey[0].time = 0;
        whitekey[1].color = _white;
        whitekey[1].time = 1;
        whiteakey[0].alpha = 1;
        whiteakey[0].time = 0;
        whiteakey[1].alpha = 1;
        whiteakey[1].time = 1;
        whitegrad.SetKeys(whitekey, whiteakey);
        redgrad.SetKeys(redkey, redakey);
    }
    private void OnEnable()
    {
        _basicHp = _hp;
        _maxHp = _basicHp;
        _basicAtk = _atk;
        _basicMatk = _matk;
        _basicAtkSpeed = _atkSpeed;
        _basicDef = _def;
        _basicSpeed = _speed;
        _basicCritical = _critical;
        _basicHandicraft = _handicraft;
        _basicCharm = _charm;
        if(_category == MonsterCategory.Common)
        {
            _ingameHp = 50 + (_hp * 10);
            _maxHp = 50 + (_hp * 10);
        }
        else if(_category == MonsterCategory.Boss)
        {
            _ingameHp = 200 + (_hp * 10);
            _maxHp = 200 + (_hp * 10);
        }
        CCrecovery();
        _isDead = false;
        if(_category != MonsterCategory.Boss)
        GamePlay._eventHandler += MonsterRelease;
        if(_category == MonsterCategory.Boss)
        {
            GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
        }

        if (_monster == MonsterKind.Slime)
            _onlySlime.material.color = _slimeColor;
        else if(_monster != MonsterKind.Slime)
        {
            for(int i = 0; i < _listMaterial.Count; ++i)
            {
                _listMaterial[i].material.color = Color.white;
            }
        }

        StartCoroutine(CoFindEnemy());
    }

    private void LateUpdate()
    {
        if(_monsterWeapon != null)
        {
            _monsterWeapon._damage = _atk * 5;

        }
        if (_ccOn == true)
        {
            _ccDurationTime -= Time.deltaTime;

        }

        if (_ccDurationTime <= 0)
        {
            _ccDurationTime = 0f;
        }
        if (_ccDurationTime <= 0 && _ccOn == true)
        {
            if(_CC == CrowdControl.Freezing)
            {
                _frozen.SetActive(false);
                CCrecovery();
            }
            else if (_CC == CrowdControl.Burn)
            {
                _burn.SetActive(false);
                CCrecovery();
            }
            else if(_CC == CrowdControl.Stun)
            {
                _sturn.SetActive(false);
                CCrecovery();
            }
        }
        if(_CC == CrowdControl.Burn)
        {
            _ingameHp -= (Player.Instance._matk / 10f) * Time.deltaTime ;
        }
        


    }

    
   

    public void SetPool(IObjectPool<Monster> pool)
    {
        _monsterpool = pool;
    }

    
    public virtual void AttackOn()
    {
        if(_monsterWeapon != null)
            _monsterWeapon._isOnce = true;
        if(_monster != MonsterKind.CaptainSkull)
        {
            SoundManager.Instance.EffectPlay(SoundManager.Instance._monsterAttack);

        }
    }
    public virtual void AttackOff()
    {
        if (_monsterWeapon != null)
            _monsterWeapon._isOnce = false;
    }

   
    public virtual void Freezing()
    {
        CCrecovery();
        _CC = CrowdControl.Freezing;
        _animator.speed = 0f;
        _navimeshAgent.speed = 0f;
        _ccDurationTime += 3f;
        _frozen.SetActive(true);
        _frozen.transform.GetChild(2).GetComponent<RFX4_StartDelay>().Delay = _ccDurationTime;
        _frozen.transform.GetChild(2).GetComponent<RFX4_DeactivateByTime>().DeactivateTime = _ccDurationTime;
        _frozen.transform.GetChild(2).GetComponent<RFX4_DeactivateByTime>().currentTime = 0;
        _frozen.transform.GetChild(2).GetComponent<RFX4_DeactivateByTime>().DeactivatedGameObject.SetActive(true);
        _ccOn = true;
        if(Player.Instance._playerTitle == Player.PlayerTitle.Helen)
        {
            Player.Instance._helenScore++;
            AchievementManager.instance.AddAchievementProgress("helenskill100", Player.Instance._helenScore);
        }
        else if(Player.Instance._playerTitle != Player.PlayerTitle.Helen)
        {
            Player.Instance._freezingCount++;
        }

    }
    public virtual void Burn()
    {
        CCrecovery();
        _CC = CrowdControl.Burn;
        _ccDurationTime += 3f;
        _atk = _basicAtk / 2;
        _ccOn = true;
        _burn.SetActive(true);
        Player.Instance._burnCount++;

    }
    public virtual void Stun()
    {
        CCrecovery();
        _CC = CrowdControl.Stun;
        _ccDurationTime += 1f;
        _animator.speed = 0f; 
        _navimeshAgent.speed = 0f;
        _ccOn = true;
        _sturn.SetActive(true);
    }
    public virtual void CCrecovery()
    {
        _CC = CrowdControl.Normal;
        _animator.speed = 1f;
        _navimeshAgent.speed = _speed;
        _atk = _basicAtk;
        _ccOn = false;
        if(_sturn.activeSelf == true)
        {
            _sturn.SetActive(false);
        }
        if(_frozen.activeSelf == true)
        {
            _frozen.SetActive(false);
        }
        if(_burn.activeSelf == true)
        {
            _burn.SetActive(false);
        }
    }

    public virtual void MonsterRelease()
    {
        _ingameHp = 0f;
    }

    // 투명 -> 불투명
    public void FadeIn()
    {
      //  var sr = this.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
      //  Color tempColor = sr.material.color;
      //  while (tempColor.a < 1f)
      //  {
      //      tempColor.a += 1f;
      //      sr.material.color = tempColor;
      //
      //      if (tempColor.a >= 1f) tempColor.a = 1f;
      //
      //
      //  }
        
      //  sr.material.color = tempColor;
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
    public void FindVisibleTargets()
    {
        //시야거리 내에 존재하는 모든 컬라이더 받아오기
        Collider[] targets = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);

        for (int i = 0; i < targets.Length; i++)
        {
            Transform target = targets[i].transform;

            //타겟까지의 단위벡터
            Vector3 dirToTarget = (target.position - m_transform.position).normalized;
            //transform.forward와 dirToTarget은 모두 단위벡터이므로 내적값은 두 벡터가 이루는 각의 Cos값과 같다.
            //대적값이 시야각/2의 Cos값보다 크면 시야에 들어온 것이다.
            if (Vector3.Dot(m_transform.forward, dirToTarget) > Mathf.Cos((m_viewAngle / 2) * Mathf.Deg2Rad))
            {
                float distToTarget = Vector3.Distance(m_transform.position, target.position);
                if (!Physics.Raycast(m_transform.position + m_transform.transform.up, dirToTarget, distToTarget, m_obstacleMask))
                {
                    Debug.DrawLine(m_transform.position, target.position, Color.red);

                    if(_CC == CrowdControl.Stun || _CC == CrowdControl.Freezing)
                    {
                        _speed = 0f;
                    }
                    else if (_monster == MonsterKind.CaptainSkull && _category == MonsterCategory.Boss && _attackStack >= 5)
                    {
                        ChangeState(State.Attack2);

                    }
                    else if (distToTarget <= _attackDistance && _attackOnce == true)
                    {
                        transform.LookAt(target);
                        ChangeState(State.Attack);
                    }
                    
                    else if (distToTarget > _attackDistance)
                    {
                        ChangeState(State.Walk);
                        _navimeshAgent.SetDestination(target.position);
                    }

                }
            }
        }
    }

    public IEnumerator CoFindEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            FindVisibleTargets();
        }

    }
    public IEnumerator CoDie()
    {
        _layerMask = 0;
        StartCoroutine(CoFadeOut(1f));
        yield return new WaitForSeconds(2f);
        Player.Instance._deadCreepScore++;
        if (_CC == CrowdControl.Freezing && Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
        {
            Player.Instance._jackfrostScore++;
            AchievementManager.instance.AddAchievementProgress("jackfrosttuna", Player.Instance._jackfrostScore);

        }
        
         if(Player.Instance._jackfrostScore >= 1000 && Player.Instance.jackfrosttuna == false)
         {
             Player.Instance.jackfrosttuna = true;
         }
        if(Player.Instance._playerTitle == Player.PlayerTitle.Dosa)
        {
            Player.Instance._dosaDieAvatar++;
            AchievementManager.instance.AddAchievementProgress("dosaskilldie20", Player.Instance._dosaDieAvatar);

            if(Player.Instance._dosaDieAvatar >= 20 && Player.Instance.dosaskilldie20 == false)
            {
                Player.Instance.dosaskilldie20 = true;
            }

        }



        _monsterpool.Release(this);
    }
    // 투명 -> 불투명
   public virtual IEnumerator CoFadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        yield return null;
    }

    // 불투명 -> 투명
    public virtual IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        yield return null;
    }

    public IEnumerator CoHit()
    {

        SoundManager.Instance.EffectPlay(SoundManager.Instance._monsterhit);
        if(_monster != MonsterKind.Slime)
        {

            for (int i = 0; i < _listMaterial.Count; ++i)
            {
                _listMaterial[i].material.color = _hitColor;

            }
        }
        else if(_monster == MonsterKind.Slime)
        {
            _onlySlime.material.color = _hitColor;
        }
        yield return new WaitForSeconds(0.3f);

        if(_monster != MonsterKind.Slime)
        {

            for (int i = 0; i < _listMaterial.Count; ++i)
            {
                _listMaterial[i].material.color = Color.white;


            }
        }
        else if(_monster == MonsterKind.Slime)
        {
            _onlySlime.material.color = _slimeColor;
        }
        _onHit = false;
    }


   private void OnTriggerEnter(Collider other)
   {


        if (other.CompareTag("Weapon"))
        {
            if(other.transform.root.gameObject.layer == 8)
            {
                if(_onHit == false && other.GetComponent<Weapon>() != null)
                {
                    if(other.GetComponent<Weapon>()._isOnce == true)
                    {
                        _onHit = true;

                        var damage = other.GetComponent<Weapon>()._damage - (_def * 3f);
                        if (damage <= 0f)
                        {
                            damage = 0f;
                        }
                        damage = Mathf.Round(damage);
                        _ingameHp -= damage;


                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                        StartCoroutine(CoHit());
                    }
                }
            }
            else if (_onHit == false && Player.Instance._isAttack == true && Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
            {
                

                    _onHit = true;
                    int _30 = Random.Range(0, 3); // 30퍼확률로 빙결
                    if (_30 == 0)
                    {
                        Freezing();

                    }

                    int rand = Random.Range(0, 100);



                    if (rand < Player.Instance._criticalProbability)
                    {

                        if (_category == MonsterCategory.Common)
                        {

                            var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;


                            _floatingTextSpawner.AnimateColorGradient = redgrad;
                            _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                        }
                        else if (_category == MonsterCategory.Boss)
                        {
                            var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
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
                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;
                            _floatingTextSpawner.AnimateColorGradient = whitegrad;
                            _mmfPlayer.PlayFeedbacks(transform.position, damage);
                        }

                        else if (_category == MonsterCategory.Boss)
                        {

                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;
                            _floatingTextSpawner.AnimateColorGradient = whitegrad;
                            _mmfPlayer.PlayFeedbacks(transform.position, damage);
                            GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                        }


                    }
                StartCoroutine(CoHit());
                

            }
            else if (_onHit == false && Player.Instance._isAttack == true && Player.Instance._playerTitle == Player.PlayerTitle.Druid)
            {

                
                    _onHit = true;

                    int rand = Random.Range(0, 100);



                    if (rand < Player.Instance._criticalProbability)
                    {

                        if (_category == MonsterCategory.Common)
                        {

                            var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;


                            _floatingTextSpawner.AnimateColorGradient = redgrad;
                            _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                        }
                        else if (_category == MonsterCategory.Boss)
                        {
                            var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
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
                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);

                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;
                            _floatingTextSpawner.AnimateColorGradient = whitegrad;
                            _mmfPlayer.PlayFeedbacks(transform.position, damage);
                        }

                        else if (_category == MonsterCategory.Boss)
                        {

                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;
                            _floatingTextSpawner.AnimateColorGradient = whitegrad;
                            _mmfPlayer.PlayFeedbacks(transform.position, damage);
                            GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                        }


                    }
                    int rand2 = Random.Range(0, 1/* - Player.Instance._skill1*/);
                    if (rand2 == 0 && _category == MonsterCategory.Common)
                    {

                        SoundManager.Instance.EffectPlay(SoundManager.Instance._fasniftion);
                        _fascination.SetActive(true);
                        m_targetMask = 64;
                        this.gameObject.layer = 8;
                        if (Player.Instance.druidfirstskill == false)
                        {
                            Player.Instance.druidfirstskill = true;
                            AchievementManager.instance.Unlock("druidfirstskill");
                        }
                        Player.Instance._druidScore++;
                        AchievementManager.instance.AddAchievementProgress("druidskill100", Player.Instance._druidScore);

                     


                    }
                    StartCoroutine(CoHit());
                
            }
            else if (_onHit == false && Player.Instance._isAttack == true && Player.Instance._playerTitle == Player.PlayerTitle.QRF && Player.Instance._skill2 >= 3f && Player.Instance._isHanger == true)
            {
                
                    _onHit = true;
                    int rand = Random.Range(0, 100);
                    if (rand < Player.Instance._criticalProbability)
                    {

                        if (_category == MonsterCategory.Common)
                        {

                            var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;


                            _floatingTextSpawner.AnimateColorGradient = redgrad;
                            _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                        }
                        else if (_category == MonsterCategory.Boss)
                        {
                            var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
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
                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;
                            _floatingTextSpawner.AnimateColorGradient = whitegrad;
                            _mmfPlayer.PlayFeedbacks(transform.position, damage);
                        }

                        else if (_category == MonsterCategory.Boss)
                        {

                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
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
                        if (Player.Instance.qrfhidden == false)
                        {
                            Player.Instance.qrfhidden = true;
                            AchievementManager.instance.Unlock("qrfhidden");
                        }
                    }
                    StartCoroutine(CoHit());
                
            }
            else if (_onHit == false && Player.Instance._isAttack == true && Player.Instance._playerTitle == Player.PlayerTitle.Acupuncturist)
            {
                
                    _onHit = true;
                    int rand = Random.Range(0, 100);
                    Player.Instance._comboInstantDie.Add(rand);

                    if (rand < Player.Instance._instantDeathProbablility)
                    {
                        if (_category == MonsterCategory.Common)
                        {

                            int damage = 999999;
                            if (damage <= 0f)
                            {
                                damage = 0;
                            }
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
                            var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
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
                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;
                            _floatingTextSpawner.AnimateColorGradient = whitegrad;
                            _mmfPlayer.PlayFeedbacks(transform.position, damage);
                        }

                        else if (_category == MonsterCategory.Boss)
                        {

                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
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
            else if (_onHit == false && Player.Instance._isAttack == true && Player.Instance._playerTitle == Player.PlayerTitle.DokeV)
            {
                
                    _onHit = true;
                    int rand = Random.Range(0, 100);


                    if (rand < Player.Instance._criticalProbability)
                    {

                        if (_category == MonsterCategory.Common)
                        {

                            var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;


                            _floatingTextSpawner.AnimateColorGradient = redgrad;
                            _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                        }
                        else if (_category == MonsterCategory.Boss)
                        {
                            var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
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
                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;
                            _floatingTextSpawner.AnimateColorGradient = whitegrad;
                            _mmfPlayer.PlayFeedbacks(transform.position, damage);
                        }

                        else if (_category == MonsterCategory.Boss)
                        {

                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;
                            _floatingTextSpawner.AnimateColorGradient = whitegrad;
                            _mmfPlayer.PlayFeedbacks(transform.position, damage);
                            GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                        }


                    }

                    if (rand < Player.Instance._dokevSkillProbability)
                    {
                        int rand2 = Random.Range(0, 7);
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


                        if (Player.Instance.dokevfirstskill == false)
                        {
                            Player.Instance.dokevfirstskill = true;
                            AchievementManager.instance.Unlock("dokevfirstskill");
                            Player.Instance.Save();
                        }

                        Player.Instance._ingameHp = 200f + (Player.Instance._hp * 10f);
                        Player.Instance._maxHp = 200f + (Player.Instance._hp * 10f);
                        Player.Instance._criticalProbability = Player.Instance._critical * 15f;
                        if (Player.Instance._criticalProbability >= 100)
                        {
                            Player.Instance._criticalProbability = 100;
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
                            var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;


                            _floatingTextSpawner.AnimateColorGradient = redgrad;


                            _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                        }
                        else if (rand >= Player.Instance._criticalProbability)
                        {
                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;
                            _floatingTextSpawner.AnimateColorGradient = whitegrad;
                            _mmfPlayer.PlayFeedbacks(transform.position, damage);


                        }
                    }
                    else if (_category == MonsterCategory.Boss)
                    {
                        int rand = Random.Range(0, 100);



                        if (rand < Player.Instance._criticalProbability)
                        {
                            var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;


                            _floatingTextSpawner.AnimateColorGradient = redgrad;


                            _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                            GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                        }
                        else if (rand >= Player.Instance._criticalProbability)
                        {
                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;
                            _floatingTextSpawner.AnimateColorGradient = whitegrad;
                            _mmfPlayer.PlayFeedbacks(transform.position, damage);
                            GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);


                        }
                    }

                    StartCoroutine(CoHit());
                
            }
            else if (_onHit == false && other.transform.root.GetComponent<Decoy>() != null)
            {
                

                    other.transform.root.GetComponent<Decoy>()._isAttack = false;

                    if (_category == MonsterCategory.Common)
                    {
                        int rand = Random.Range(0, 100);



                        if (rand < Player.Instance._criticalProbability)
                        {
                            var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;


                            _floatingTextSpawner.AnimateColorGradient = redgrad;


                            _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                        }
                        else if (rand >= Player.Instance._criticalProbability)
                        {
                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;
                            _floatingTextSpawner.AnimateColorGradient = whitegrad;
                            _mmfPlayer.PlayFeedbacks(transform.position, damage);


                        }
                    }
                    else if (_category == MonsterCategory.Boss)
                    {
                        int rand = Random.Range(0, 100);



                        if (rand < Player.Instance._criticalProbability)
                        {
                            var damage = (Player.Instance._weapon._damage + (Player.Instance._atk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
                            _ingameHp -= damage;

                            _floatingTextSpawner.AnimateColorGradient = redgrad;


                            _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
                            GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                        }
                        else if (rand >= Player.Instance._criticalProbability)
                        {
                            var damage = Player.Instance._weapon._damage + (Player.Instance._atk * 5f) - (_def * 3f);
                            if (damage <= 0f)
                            {
                                damage = 0f;
                            }
                            damage = Mathf.Round(damage);
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
  
                   var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 4f)) * Player.Instance._criticalDamage - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
                   _ingameHp -= damage;
  
  
                   _floatingTextSpawner.AnimateColorGradient = redgrad;
                   _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
  
               }
               else if (_category == MonsterCategory.Boss)
               {
                   var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 4f)) * Player.Instance._criticalDamage - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
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
                   var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 4f) - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
                   _ingameHp -= damage;
                   _floatingTextSpawner.AnimateColorGradient = whitegrad;
                   _mmfPlayer.PlayFeedbacks(transform.position, damage);
               }
  
               else if (_category == MonsterCategory.Boss)
               {
  
                   var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 4f) - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
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
  
                   var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
                   _ingameHp -= damage;
  
  
                   _floatingTextSpawner.AnimateColorGradient = redgrad;
                   _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
  
               }
               else if (_category == MonsterCategory.Boss)
               {
                   var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
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
                   var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5f) - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
                   _ingameHp -= damage;
                   _floatingTextSpawner.AnimateColorGradient = whitegrad;
                   _mmfPlayer.PlayFeedbacks(transform.position, damage);
               }
  
               else if (_category == MonsterCategory.Boss)
               {
  
                   var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5f) - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
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
  
                   var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
                   _ingameHp -= damage;
  
  
                   _floatingTextSpawner.AnimateColorGradient = redgrad;
                   _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
  
               }
               else if (_category == MonsterCategory.Boss)
               {
                   var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 5f)) * Player.Instance._criticalDamage - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
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
                   var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5f) - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
                   _ingameHp -= damage;
                   _floatingTextSpawner.AnimateColorGradient = whitegrad;
                   _mmfPlayer.PlayFeedbacks(transform.position, damage);
               }
  
               else if (_category == MonsterCategory.Boss)
               {
  
                   var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5f) - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
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

            if (other.GetComponent<SkillBase>() != null && _onHit == false)
            {

                _onHit = true;
                int rand = Random.Range(0, 100);



                if (rand < Player.Instance._criticalProbability)
                {

                    if (_category == MonsterCategory.Common)
                    {

                        var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 10f)) * Player.Instance._criticalDamage - (_def * 3f);
                        if (damage <= 0f)
                        {
                            damage = 0f;
                        }
                        damage = Mathf.Round(damage);
                        _ingameHp -= damage;


                        _floatingTextSpawner.AnimateColorGradient = redgrad;
                        _mmfPlayer.PlayFeedbacks(this.transform.position, damage);

                    }
                    else if (_category == MonsterCategory.Boss)
                    {
                        var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 10f)) * Player.Instance._criticalDamage - (_def * 3f);
                        if (damage <= 0f)
                        {
                            damage = 0f;
                        }
                        damage = Mathf.Round(damage);
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
                        var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5f) - (_def * 3f);
                        if (damage <= 0f)
                        {
                            damage = 0f;
                        }
                        damage = Mathf.Round(damage);
                        _ingameHp -= damage;
                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                    }

                    else if (_category == MonsterCategory.Boss)
                    {

                        var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 5f) - (_def * 3f);
                        if (damage <= 0f)
                        {
                            damage = 0f;
                        }
                        damage = Mathf.Round(damage);
                        _ingameHp -= damage;

                        _floatingTextSpawner.AnimateColorGradient = whitegrad;
                        _mmfPlayer.PlayFeedbacks(transform.position, damage);
                        GamePlay.Instance._bossHpbarPlayer.UpdateBar(_ingameHp, 0, _maxHp);
                    }


                }
                StartCoroutine(CoHit());
            }
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
               damage = Mathf.Round(damage);
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
  
               if (_category == MonsterCategory.Common)
               {
  
                   var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 8f)) * Player.Instance._criticalDamage - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
                   _ingameHp -= damage;
  
  
                   _floatingTextSpawner.AnimateColorGradient = redgrad;
                   _mmfPlayer.PlayFeedbacks(this.transform.position, damage);
  
               }
               else if (_category == MonsterCategory.Boss)
               {
                   var damage = (Player.Instance._weapon._damage + (Player.Instance._matk * 8f)) * Player.Instance._criticalDamage - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
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
                   var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 8f) - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
                   _ingameHp -= damage;
                   _floatingTextSpawner.AnimateColorGradient = whitegrad;
                   _mmfPlayer.PlayFeedbacks(transform.position, damage);
               }
  
               else if (_category == MonsterCategory.Boss)
               {
  
                   var damage = Player.Instance._weapon._damage + (Player.Instance._matk * 8f) - (_def * 3f);
                   if (damage <= 0f)
                   {
                       damage = 0f;
                   }
                   damage = Mathf.Round(damage);
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




}
