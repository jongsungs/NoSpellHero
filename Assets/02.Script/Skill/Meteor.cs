using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : SkillBase
{

    public SkillBase _effect;
    MeshRenderer _render;
    private void OnEnable()
    {
        _render = GetComponent<MeshRenderer>();
        _effect.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(transform.position == _target.transform.position)
        {
            _render.enabled = false;
            _effect.gameObject.SetActive(true);
        }
    }




    public IEnumerator Target(GameObject obj)
    {
        _target = obj;
        while(transform.position.z != obj.transform.position.z)
        {
            yield return new WaitForSeconds(0.01f);
            transform.position = Vector3.MoveTowards(transform.position, obj.transform.position, _skillSpeed * Time.deltaTime);
        }

    }

    public void Release()
    {
        _render.enabled = true ;

        _skillPool.Release(this);
    }
}
