using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : SkillBase
{

    private void Update()
    {
        if(transform.position == _target.transform.position)
        {
            _skillPool.Release(this);
        }
    }




    public IEnumerator Target(GameObject obj)
    {
        _target = obj;
        while(transform.position.z != obj.transform.position.z)
        {
            yield return new WaitForSeconds(0.1f);
            transform.position = Vector3.MoveTowards(transform.position, obj.transform.position, _skillSpeed * Time.deltaTime);
        }

    }
}
