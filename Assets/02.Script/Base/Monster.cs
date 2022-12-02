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
    public Weapon _monsterAttack;


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
        _isAttack = false;

        if (_burn != null)
        _burn.SetActive(false);
        if(_frozen != null)
        _frozen.SetActive(false);
        if (_sturn != null)
            _sturn.SetActive(false);
        if (_fascination != null)
            _fascination.SetActive(false);
        _attackOnce = true;
        GamePlay._eventHandler += MonsterRelease;
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
        _ingameHp = 50 + (_hp * 10);
        _maxHp = 50 + (_hp * 10);
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
        _isDead = false;

        StartCoroutine(CoFindEnemy());
        Debug.Log("몬스터 시작");

    }

    private void LateUpdate()
    {
        if(_monsterAttack != null)
        {
            _monsterAttack._damage = _atk * 5;

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
        if(_monsterAttack != null)
        _monsterAttack._isOnce = true;
        _isAttack = true;
    }
    public virtual void AttackOff()
    {
        if (_monsterAttack != null)
            _monsterAttack._isOnce = false;
        _isAttack = true;
    }

   
    public virtual void Freezing()
    {
        CCrecovery();
        _CC = CrowdControl.Freezing;
        Debug.Log("얼었다");
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
        Debug.Log("으이구 이 화상아");
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
        Debug.Log("스턴");
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
                    else if (_monster == MonsterKind.CaptainSkull && _category == MonsterCategory.Boss && _attackStack >= 500)
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
            Debug.Log("아직 안끝났다.");
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
        Debug.Log("깜빡");
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
    }
   
}
