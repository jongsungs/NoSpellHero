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

    }
    


    protected IObjectPool<Monster> _monsterpool;
    protected GameObject _player;
    public NavMeshAgent _navimeshAgent;
    public bool _onHit;
    public float _ccDurationTime;
    protected bool _ccOn = false;
    public bool _isDead;
    public MonsterKind _monster;
    public MonsterCategory _category;
    public LayerMask _layerMask;


    protected Transform m_transform;
    [SerializeField] float m_speed;
    [SerializeField] float m_viewAngle;    //시야각
    [SerializeField] float m_viewDistance; //시야거리

    public LayerMask m_targetMask;  //Enemy 레이어마스크 지정을 위한 변수
    public LayerMask m_obstacleMask; //Obstacle 레이어마스크 지정을 위한 변수

    public bool _attackOnce;
    public float _attackDistance = 2f;


    private void Awake()
    {
        _player = GameObject.Find("Player");
        _navimeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        m_transform = GetComponent<Transform>();

        _navimeshAgent.stoppingDistance = 2f;
        _attackOnce = true;
    }
    protected virtual void Start()
    {
        
        _maxHp = _hp;
        _basicAtk = _atk;
        _basicMatk = _matk;
        _basicAtkSpeed = _atkSpeed;
        _basicDef = _def;
        _basicSpeed = _speed;
        _basicCritical = _critical;
        _basicHandicraft = _handicraft;
        _basicCharm = _charm;


        StartCoroutine(CoFindEnemy());
        Debug.Log("몬스터 시작");

    }

    private void LateUpdate()
    {

       
        if (_ccDurationTime <= 0)
        {
            _ccDurationTime = 0f;
        }
        if (_ccDurationTime <= 0 && _ccOn == true)
        {
            CCrecovery();
        }
        if(_CC == CrowdControl.Burn)
        {
            _hp -= (_player.GetComponent<Player>()._matk / 10f) * Time.deltaTime ;
        }
        


    }

    
   

    public void SetPool(IObjectPool<Monster> pool)
    {
        _monsterpool = pool;
    }

    private void OnBecameInvisible()
    {
        _monsterpool.Release(this);
    }

    

    public virtual void Freezing()
    {
        _CC = CrowdControl.Freezing;
        Debug.Log("얼었다");
        _animator.speed = 0f;
        _navimeshAgent.speed = 0f;
        _ccDurationTime += 3f;
        _ccOn = true;

    }
    public virtual void Burn()
    {
        _CC = CrowdControl.Burn;
        _ccDurationTime += 3f;
        Debug.Log("으이구 이 화상아");
        _atk = _basicAtk / 2;
        _ccOn = true;

    }
    public virtual void Roar()
    {
        _CC = CrowdControl.Stun;
        //_ccDurationTime += 1f;
        _animator.speed = 0f;
        _navimeshAgent.speed = 0f;
        _ccOn = true;
    }
    public virtual void CCrecovery()
    {
        _CC = CrowdControl.Normal;
        _animator.speed = 1f;
        _navimeshAgent.speed = _speed;
        _atk = _basicAtk;
        _ccOn = false;
    }

    public virtual void MonsterRelease()
    {
       
    }

    // 투명 -> 불투명
    public void FadeIn()
    {
        var sr = this.gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
        Color tempColor = sr.material.color;
        while (tempColor.a < 1f)
        {
            tempColor.a += 1f;
            sr.material.color = tempColor;

            if (tempColor.a >= 1f) tempColor.a = 1f;


        }

        sr.material.color = tempColor;
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

                    if (distToTarget <= _attackDistance && _attackOnce == true)
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

}
