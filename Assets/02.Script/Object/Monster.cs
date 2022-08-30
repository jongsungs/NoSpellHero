
using UnityEngine;
using UnityEngine.Pool;

public class Monster : BaseObject
{
    private IObjectPool<Monster> _monsterpool;
    [SerializeField] Vector3 m_spped;

    private void Update()
    {
        transform.position += m_spped * Time.deltaTime;
    }

    public void SetPool(IObjectPool<Monster> pool)
    {
        _monsterpool = pool;
    }

    private void OnBecameInvisible()
    {
        _monsterpool.Release(this);
    }
}
