using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : SkillBase
{
    private void Update()
    {
        transform.Translate(Vector3.forward * _skillSpeed * Time.deltaTime, Space.Self);
    }
}
