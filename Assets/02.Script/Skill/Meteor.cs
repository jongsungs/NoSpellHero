using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : SkillBase
{

    public SkillBase _effect;
    MeshRenderer _render;
   
    private void OnEnable()
    {
        _render = GetComponent<MeshRenderer>();
        _effect.gameObject.SetActive(false);
        _target = GamePlay.Instance._listMeteorTarget[0];
        StartCoroutine(Target());
    }

    private void Update()
    {
        if(transform.position.y  <= _target.transform.position.y)
        {
            _render.enabled = false;
            _effect.gameObject.SetActive(true);
            if(_isOnce == false)
            {
                _isOnce = true;
            SoundManager.Instance.EffectPlay(SoundManager.Instance._meteorex);

            }
        }
        transform.Rotate(Vector3.forward * Time.deltaTime * 100f);
    }




    public IEnumerator Target()
    {
        
        while(transform.position.y >= _target.transform.position.y)
        {
            yield return new WaitForSeconds(0.01f);
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _skillSpeed * Time.deltaTime);
        }

    }

    public void Release()
    {
        _render.enabled = true ;
        _target.SetActive(false);
        _skillPool.Release(this);
    }
}
