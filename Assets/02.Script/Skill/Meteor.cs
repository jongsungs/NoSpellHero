using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : SkillBase
{






    public IEnumerator Target(GameObject obj)
    {
        while(transform.position.z != obj.transform.position.z)
        {
            yield return new WaitForSeconds(0.1f);
            transform.position = Vector3.MoveTowards(transform.position, obj.transform.position, 2 * Time.deltaTime);
        }

    }
}
