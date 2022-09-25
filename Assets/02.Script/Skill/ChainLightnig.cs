using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightnig : SkillBase
{


    [SerializeField] float m_speed;
    [SerializeField] float m_viewAngle;    //�þ߰�
    [SerializeField] float m_viewDistance; //�þ߰Ÿ�



    [SerializeField] LayerMask m_targetMask;  //Enemy ���̾��ũ ������ ���� ����
    [SerializeField] LayerMask m_obstacleMask; //Obstacle ���̾��ũ ������ ���� ����
    public List<Monster> _listMonster = new List<Monster>();
    public List<Vector3> _listMonsterPosition = new List<Vector3>();

    public GameObject _lightning;

    public int _jumpStack;


    Vector3 m_destination;
    private Transform m_transform;
    private void Start()
    {
        m_transform = GetComponent<Transform>();
        _jumpStack = 3;

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Lightning();

        }


        DrawView();
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
    public void Lightning()
    {
        //�þ߰Ÿ� ���� �����ϴ� ��� �ö��̴� �޾ƿ���
        Collider[] targets = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);

        for(int i = 0; i < _jumpStack; ++i)
        {
            if(targets[i].GetComponent<Monster>() != null)
            {
                _listMonster.Add(targets[i].GetComponent<Monster>());
                _listMonsterPosition.Add(_listMonster[i].transform.position);

                _listMonster[i]._hp -= 1f;
            }

            if(i == 0)
            {
                var obj = Instantiate(_lightning);
                var light = obj.GetComponent<LightningBoltScript>();
                light.StartObject = this.gameObject;
                light.EndObject = _listMonster[i].gameObject;
            }
            else if(i != 0&&i < _jumpStack - 1)
            {

                var obj = Instantiate(_lightning);
                var light = obj.GetComponent<LightningBoltScript>();
                light.StartObject = _listMonster[i-1].gameObject;
                light.EndObject = _listMonster[i ].gameObject;
            }


        }

        

        



    }
   

    

}
