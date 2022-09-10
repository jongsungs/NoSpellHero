using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roar : SkillBase
{


    private void Update()
    {
        

        if(transform.localScale.x <= 9f && transform.localScale.z <= 9f)
        {
            this.transform.localScale += new Vector3(25f*Time.deltaTime,0,25f*Time.deltaTime);

        }
        else if(transform.localScale.x >=9f && transform.localScale.z >= 9f)
        {
            gameObject.SetActive(false);
            transform.localScale = new Vector3(0f, 0.1f, 0f);
        }
    }
}
