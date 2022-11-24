using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : SkillBase
{

    Collider _collider;

    private void OnEnable()
    {
        StopAllCoroutines();
        _collider = GetComponent<Collider>();
        _collider.enabled = true;
        StartCoroutine(IsDamage());
    }



    public IEnumerator IsDamage()
    {
        yield return new WaitForSeconds(0.25f);
        _collider.enabled = false;

        yield return new WaitForSeconds(1.5f);
        _skillPool.Release(this);

    }




}
