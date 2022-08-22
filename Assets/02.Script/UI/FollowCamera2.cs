using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera2 : MonoBehaviour
{
    public GameObject _target;

    public float _offsetX;
    public float _offsetY;
    public float _offsetZ;

    public float _delayTime;

    private void LateUpdate()
    {
        Vector3 fixedPos = new Vector3(_target.transform.position.x + _offsetX, _target.transform.position.y + _offsetY, _target.transform.position.z + _offsetZ);

        transform.position = Vector3.Lerp(transform.position, fixedPos, Time.deltaTime * _delayTime);
    }
}
