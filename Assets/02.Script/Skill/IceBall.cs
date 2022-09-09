using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : SkillBase
{


    private void Update()
    {
        transform.Translate(Vector3.forward * _skillSpeed * Time.deltaTime,Space.Self);   
    }

}
