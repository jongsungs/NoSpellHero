using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player : BaseObject
{
    [SerializeField] float _preSpeed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    [SerializeField] float _rotateSpeed;
    private void Awake()
    {
        _preSpeed = _speed;
    }



    public void FixedUpdate()
    {
        if (variableJoystick._isStop)
        {
            // rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;
            _speed = 0f;
        }
        else if(variableJoystick._isStop == false)
        {
            _speed = _preSpeed;
        }
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.velocity = (direction * _speed * Time.fixedDeltaTime);

        transform.rotation = Quaternion.LookRotation(direction);
        transform.Translate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }

   
}
