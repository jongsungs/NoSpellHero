using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : SkillBase
{

    [SerializeField] bool _end = false;

    private void Start()
    {
        StartCoroutine(CoCreatWall());
        Debug.Log("½ÃÀÛ");
    }


    IEnumerator CoCreatWall()
    {
        while(_end == false)
        {

            yield return new WaitForSeconds(0.1f);
            transform.localScale += new Vector3(0.15f, 0.15f, 0.15f);

            if (transform.localScale.x >= 1.5f && transform.localScale.z >= 1.5f)
            {
                _end = true;
            }
        }

        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);

    }
}
