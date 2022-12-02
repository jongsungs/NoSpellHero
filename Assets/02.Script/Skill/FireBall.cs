using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : SkillBase
{
    private void OnEnable()
    {
        StartCoroutine(CoRelease());
    }


    public IEnumerator CoRelease()
    {
        yield return new WaitForSeconds(_skillDurationTime);
        _skillPool.Release(this);
    }
}
