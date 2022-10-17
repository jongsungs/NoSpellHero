using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectCollider : SkillBase
{
    public Meteor _meteor;

    private void OnEnable()
    {
        StartCoroutine(CoFadeOut());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Monster>()._hp -= 1f;
        }
    }


    IEnumerator CoFadeOut()
    {
        yield return new WaitForSeconds(1f);
        _meteor.Release();
    }



}
