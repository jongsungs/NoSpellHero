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
    [SerializeField] float m_viewAngle;    //�þ߰�
    [SerializeField] float m_viewDistance; //�þ߰Ÿ�

    public LayerMask m_targetMask;  //Enemy ���̾��ũ ������ ���� ����
    public LayerMask m_obstacleMask; //Obstacle ���̾��ũ ������ ���� ����

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
        Debug.Log("���� ����");

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
        Debug.Log("�����");
        _animator.speed = 0f;
        _navimeshAgent.speed = 0f;
        _ccDurationTime += 3f;
        _ccOn = true;

    }
    public virtual void Burn()
    {
        _CC = CrowdControl.Burn;
        _ccDurationTime += 3f;
        Debug.Log("���̱� �� ȭ���");
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

    // ���� -> ������
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
        // �¿� ȸ���� ����
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
        //�þ߰Ÿ� ���� �����ϴ� ��� �ö��̴� �޾ƿ���
        Collider[] targets = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);

        for (int i = 0; i < targets.Length; i++)
        {
            Transform target = targets[i].transform;

            //Ÿ�ٱ����� ��������
            Vector3 dirToTarget = (target.position - m_transform.position).normalized;
            //transform.forward�� dirToTarget�� ��� ���������̹Ƿ� �������� �� ���Ͱ� �̷�� ���� Cos���� ����.
            //�������� �þ߰�/2�� Cos������ ũ�� �þ߿� ���� ���̴�.
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
            Debug.Log("���� �ȳ�����.");
        }

    }

}
