using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonKingMeteor : SkillBase
{
    public SkillBase _effect;
    MeshRenderer _render;
    SphereCollider _collider;

    private void OnEnable()
    {
        _render = GetComponent<MeshRenderer>();
        _effect.gameObject.SetActive(false);
        _collider = GetComponent<SphereCollider>();
        _collider.enabled = true;
        _isOnce = false;
        StartCoroutine(Target());
    }

    private void Update()
    {
        if (transform.position.y <= 0)
        {
            _render.enabled = false;
            _collider.enabled = false;
            _effect.gameObject.SetActive(true);
            if (_isOnce == false)
            {
                _isOnce = true;
                SoundManager.Instance.EffectPlay(SoundManager.Instance._meteorex);

            }
        }
        transform.Rotate(Vector3.forward * Time.deltaTime * 100f);
    }




    public IEnumerator Target()
    {

        while (transform.position.y >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(Vector3.up * -Time.deltaTime * _skillSpeed,Space.World);
            transform.Translate(Vector3.left * Time.deltaTime * _skillSpeed , Space.World);
        }

    }

    public void Release()
    {
        _render.enabled = true;
        _skillPool.Release(this);
    }
}
