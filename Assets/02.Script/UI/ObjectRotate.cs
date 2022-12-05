using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{

    public float _rotateSpeed;
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _rotateSpeed);
    }
}
