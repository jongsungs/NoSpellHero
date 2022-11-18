using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roar : SkillBase
{
    public List<Monster> _listBlizzardMonster = new List<Monster>();
    private Transform m_transform;
    [SerializeField] float m_viewDistance; //시야거리
    [SerializeField] LayerMask m_targetMask;  //Enemy 레이어마스크 지정을 위한 변수

   



    public void RoarOn(int skill1, int skill2 )
    {
        StartCoroutine(RoarOff());

        m_viewDistance = 2 + skill2;

        if (skill2 >= 3)
        {
            m_viewDistance = 60f;
        }



        Collider[] targets = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);

        for (int i = 0; i < targets.Length; ++i)
        {
            _listBlizzardMonster.Add(targets[i].GetComponent<Monster>());
        }

        for (int i = 0; i < _listBlizzardMonster.Count; ++i)
        {
            _listBlizzardMonster[i]._ccDurationTime = 1 + skill1;
            _listBlizzardMonster[i].Stun();

        }


        _listBlizzardMonster.Clear();

    }
    public IEnumerator RoarOff()
    {
        GamePlay.Instance._roarPool.Get();

        yield return new WaitForSeconds(4f);
        GamePlay.Instance._roarPool.Release(this);
    }

   
}
