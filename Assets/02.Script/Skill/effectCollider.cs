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

   

    IEnumerator CoFadeOut()
    {
        yield return new WaitForSeconds(_skillDurationTime);
        _meteor.Release();
    }



}
