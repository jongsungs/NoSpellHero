using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : SkillBase
{

    [SerializeField] bool _end = false;
    public Transform m_transform;
    [SerializeField] float m_viewDistance; //시야거리
    public LayerMask m_targetMask;  //Enemy 레이어마스크 지정을 위한 변수


    private void Start()
    {
        m_transform = GetComponent<Transform>();
        m_viewDistance = 2f;


        StartCoroutine(CoCreatWall());
        StartCoroutine(Immolation());
    }


    IEnumerator CoCreatWall()
    {
        while(_end == false)
        {

            yield return new WaitForSeconds(0.1f);
            transform.localScale += new Vector3(0.15f, 0.15f, 0.15f);

            if (transform.localScale.x >= 1.5f && transform.localScale.z >= 1.5f)
            {
                _end = true;
            }
        }

        yield return new WaitForSeconds(2f);

        _skillPool.Release(this);
    }
    public IEnumerator Immolation()
    {
        while (true)
        {
            var obj = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);
            for (int i = 0; i < obj.Length; ++i)
            {
                obj[i].GetComponent<Monster>()._hp -= 1f - Player.Instance._skill1;
            }

            yield return new WaitForSeconds(1f);


        }
    }


}
