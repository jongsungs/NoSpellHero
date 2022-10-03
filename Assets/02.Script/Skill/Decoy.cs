using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class Decoy : BaseObject
{
    public Player _player;
    public Rigidbody rb;
    public NavMeshAgent _nav;
    public List<Weapon> _myWeapon = new List<Weapon>();
    
    public bool _attackOnce;
    public float _attackDistance = 2f;


    [SerializeField] float m_speed;
    [SerializeField] float m_viewAngle;    //시야각
    [SerializeField] float m_viewDistance; //시야거리

    [SerializeField] LayerMask m_targetMask;  //Enemy 레이어마스크 지정을 위한 변수
    [SerializeField] LayerMask m_obstacleMask; //Obstacle 레이어마스크 지정을 위한 변수


    Vector3 m_destination;
    private Transform m_transform;


    private IObjectPool<Decoy> _decoypool;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _myWeapon = _player._myWeapon;
        _animator = GetComponent<Animator>();
        _nav = GetComponent<NavMeshAgent>();
        m_transform = GetComponent<Transform>();


        _hp = _player._hp;
        _atk = _player._atk;
        _matk = _player._matk;
        _atkSpeed = _player._atkSpeed;
        _def = _player._def;
        _speed = _player._speed;
        _critical = _player._critical;
        _handicraft = _player._handicraft;
        _charm = _player._charm;
        _nav.stoppingDistance = 2f;
        _attackOnce = true;
        StartCoroutine(CoFindEnemy());
    }

    private void Update()
    {
        if (_animator != null)
        {
            _animator.speed = 0.5f + (_atkSpeed / 10f);
             _animator.SetFloat("AtkSpeed", _animator.speed);
        }

        DrawView();  // Scene뷰에 시야범위 그리기
      // FindVisibleTargets(); // Enemy인지 장애물인지 판별

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
                if (!Physics.Raycast(m_transform.position + m_transform.transform.up, dirToTarget, distToTarget, m_obstacleMask) )
                {
                    Debug.DrawLine(m_transform.position, target.position, Color.red);
                    
                    if(distToTarget <= _attackDistance && _attackOnce == true)
                    {
                        transform.LookAt(target);
                        ChangeState(State.Attack);
                    }
                    else if(distToTarget > _attackDistance)
                    {
                        ChangeState(State.Walk);
                        _nav.SetDestination(target.position);
                    }

                }
            }
        }
    }

    public override void Idle()
    {
        
        ChangeState(State.Idle);
    }
    public override void Attack()
    {
        //_isIdle = false;
        ChangeState(State.Attack);
    }
    public override void Walk()
    {
        ChangeState(State.Walk);
    }
    public override void Hit()
    {
        ChangeState(State.Hit);
    }
    public override void Die()
    {
        ChangeState(State.Die);
    }
    

    public void AttackOn()
    {
        _isAttack = true;
    }
    public void AttackOff()
    {
        _isAttack = false;
        _attackOnce = true;
        Idle();
    }


    protected override void ChangeState(State state)
    {
        base.ChangeState(state);
        _animator.SetInteger(_aniHashKeyState, (int)_state);
        switch (_state)
        {
            case State.Idle:
                _nav.speed = 0f;
                _attackOnce = true;
                break;
            case State.Walk:
                _attackOnce= true;
                _nav.speed = _speed;
                break;
            case State.Attack:
                _isAttack = true;
                _attackOnce = false;
                _nav.speed = 0f;
                break;
            case State.Hit:
                _nav.speed = 0f;
                break;
            case State.Die:
                _nav.speed = _speed;
                break;
            case State.Attack2:
                _isAttack = true;
                break;
        }
    }
    public void SetPool(IObjectPool<Decoy> pool)
    {
        _decoypool = pool;
    }
    IEnumerator CoFindEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            FindVisibleTargets();
        }

    }
}
