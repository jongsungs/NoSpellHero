using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightnig : SkillBase
{


    [SerializeField] float m_viewDistance; //시야거리
    [SerializeField] LayerMask m_targetMask;  //Enemy 레이어마스크 지정을 위한 변수

    public List<Monster> _listMonster = new List<Monster>();
    public List<Vector3> _listMonsterPosition = new List<Vector3>();

    public GameObject _lightning;

    public int _jumpStack;

    private Transform m_transform;
    private void Start()
    {
        m_transform = GetComponent<Transform>();
        _jumpStack = 3;

    }

    private void Update()
    {
        


     
    }
   
    

    public IEnumerator CoLightning()
    {
        Collider[] targets = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);

        for (int i = 0; i < _jumpStack; ++i)
        {
            if (targets[i].GetComponent<Monster>() != null)
            {
                _listMonster.Add(targets[i].GetComponent<Monster>());
                _listMonsterPosition.Add(_listMonster[i].transform.position);
                
            }

            if (i == 0)
            {
                var obj = Instantiate(_lightning);
                var light = obj.GetComponent<LightningBoltScript>();
                light.StartObject = this.gameObject;
                light.EndObject = _listMonster[i].gameObject;
                light.EndObject.GetComponent<Monster>()._hp -= 1f;

            }
            else if (i != 0 && i < _jumpStack - 1)
            {

                yield return new WaitForSeconds(0.05f);
                var obj = Instantiate(_lightning);
                var light = obj.GetComponent<LightningBoltScript>();
                light.StartObject = _listMonster[i - 1].gameObject;
                light.EndObject = _listMonster[i].gameObject;
                light.EndObject.GetComponent<Monster>()._hp -= 1f;
            }


        }

        _listMonster.Clear();
        _listMonsterPosition.Clear();
    }

    

}
