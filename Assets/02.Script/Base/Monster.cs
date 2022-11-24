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
    public MoreMountains.Feedbacks.MMFloatingTextSpawner _floatingTextSpawner;
    public MoreMountains.Feedbacks.MMF_Player _mmfPlayer;

   



    protected Transform m_transform;
    [SerializeField] float m_viewAngle;    //�þ߰�
    [SerializeField] float m_viewDistance; //�þ߰Ÿ�

    public LayerMask m_targetMask;  //Enemy ���̾��ũ ������ ���� ����
    public LayerMask m_obstacleMask; //Obstacle ���̾��ũ ������ ���� ����

    public bool _attackOnce;
    public float _attackDistance;
    public List<SkinnedMeshRenderer> _listMaterial;


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
        _attackOnce = true;
        GamePlay._eventHandler += MonsterRelease;
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


        StartCoroutine(CoFindEnemy());
        Debug.Log("���� ����");

    }

    private void LateUpdate()
    {
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
            _hp -= (Player.Instance._matk / 10f) * Time.deltaTime ;
        }
        


    }

    
   

    public void SetPool(IObjectPool<Monster> pool)
    {
        _monsterpool = pool;
    }

    

    

    public virtual void Freezing()
    {
        CCrecovery();
        _CC = CrowdControl.Freezing;
        Debug.Log("�����");
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

    }
    public virtual void Burn()
    {
        CCrecovery();
        _CC = CrowdControl.Burn;
        _ccDurationTime += 3f;
        Debug.Log("���̱� �� ȭ���");
        _atk = _basicAtk / 2;
        _ccOn = true;
        _burn.SetActive(true);

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
        Debug.Log("����");
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

    // ���� -> ������
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

                    if(_CC == CrowdControl.Stun || _CC == CrowdControl.Freezing)
                    {
                        _speed = 0f;
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
            Debug.Log("���� �ȳ�����.");
        }

    }
    public IEnumerator CoDie()
    {
        _layerMask = 0;
        StartCoroutine(CoFadeOut(1f));
        yield return new WaitForSeconds(2f);
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
    // ���� -> ������
   public virtual IEnumerator CoFadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        yield return null;
    }

    // ������ -> ����
    public virtual IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        yield return null;
    }


}
