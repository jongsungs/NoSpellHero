using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    public float _speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    [SerializeField] float _rotateSpeed;
   

    public void FixedUpdate()
    {
        if (variableJoystick._isStop)
        {
            rb.velocity = Vector3.zero;
           rb.angularVelocity = Vector3.zero;
        }
        else if(variableJoystick._isStop == false)
        {
            _speed = 10f;
        }
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * _speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        //float x = variableJoystick.Vertical;
        //float z = variableJoystick.Horizontal;
        //Vector3 dir;
        //dir = 
        transform.rotation = Quaternion.LookRotation(direction);
        transform.Translate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }

   
}
