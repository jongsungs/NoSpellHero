using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightnig : SkillBase
{


    [SerializeField] float m_speed;
    [SerializeField] float m_viewAngle;    //시야각
    [SerializeField] float m_viewDistance; //시야거리



    [SerializeField] LayerMask m_targetMask;  //Enemy 레이어마스크 지정을 위한 변수
    [SerializeField] LayerMask m_obstacleMask; //Obstacle 레이어마스크 지정을 위한 변수
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
    public void Lightning()
    {
        //시야거리 내에 존재하는 모든 컬라이더 받아오기
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
