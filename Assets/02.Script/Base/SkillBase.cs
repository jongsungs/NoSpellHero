using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class SkillBase : MonoBehaviour
{
    public float _skillDamage;
    public float _skillDurationTime;
    public float _skillSpeed;

    public IObjectPool<SkillBase> _skillPool;
    public GameObject _target;
    public bool _isOnce;
    public void SetPool(IObjectPool<SkillBase> pool)
    {
        _skillPool = pool;
    }


    public void SkillRelease()
    {
        _skillPool.Release(this);
    }
}
