using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : SkillBase
{

    public GameObject _object;
    public float _rotateSpeed;



  
    private void OnEnable()
    {
        StartCoroutine(CoRotate());
        StartCoroutine(CoFoward());
    }

    public IEnumerator CoRotate()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.05f);
            _object.transform.Rotate(Vector3.up * _rotateSpeed, Space.Self);
        }
    }
    public IEnumerator CoFoward()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.05f);
            transform.Translate(Vector3.forward* _skillSpeed * Time.deltaTime, Space.Self);
        }
    }

}