using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Decoy : BaseObject
{
    public Player _player;
    public Rigidbody rb;
    public NavMeshAgent _nav;
    public List<Weapon> _myWeapon = new List<Weapon>();
    public bool _isAttack;
    public bool _isIdle = true;


    [SerializeField] float m_speed;
    [SerializeField] float m_viewAngle;    //시야각
    [SerializeField] float m_viewDistance; //시야거리

    [SerializeField] LayerMask m_targetMask;  //Enemy 레이어마스크 지정을 위한 변수
    [SerializeField] LayerMask m_obstacleMask; //Obstacle 레이어마스크 지정을 위한 변수


    Vector3 m_destination;
    private Transform m_transform;


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

    }

    private void Update()
    {

        
        DrawView();  // Scene뷰에 시야범위 그리기
        FindVisibleTargets(); // Enemy인지 장애물인지 판별

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
                    _nav.SetDestination(target.position);

                }
            }
        }
    }

    public override void Idle()
    {
        _isIdle = true;
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
    }


    protected override void ChangeState(State state)
    {
        base.ChangeState(state);
        _animator.SetInteger(_aniHashKeyState, (int)_state);
        switch (_state)
        {
            case State.Idle:
                

                break;
            case State.Walk:
               

                break;
            case State.Attack:
                _isAttack = true;

                break;
            case State.Hit:

                break;
            case State.Die:
                break;
            case State.Attack2:
                _isAttack = true;
                break;
        }
    }
}
