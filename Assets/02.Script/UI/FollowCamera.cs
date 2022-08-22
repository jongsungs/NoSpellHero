using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform m_target;        //���� Ÿ��
    [SerializeField] float m_distance = 10f;    //Ÿ�ٰ��� �Ÿ� 
    [SerializeField] float m_height = 5f;       //ī�޶� ����
    [SerializeField] float m_targetHeight = 2f; //���� ��ǥ�� ����
    [SerializeField] float m_targetEulerAngleY = 0f;    //Ÿ�� �߽����� ȸ���� ȸ����
    [SerializeField] float m_rotateSpeed = 5f;  //ȸ�� ���ǵ�

    //Update�� ������ ����Ǵ°� LateUpdate
    private void LateUpdate()
    {
        //Quaternion.Euler : ���Ϸ������� ���ʹϾ����� ��ȯ���ִ� �Լ�
        Quaternion rotation = Quaternion.Euler(0f, m_targetEulerAngleY, 0f);

        //� ���ʹϾ� �� * ���⺤��
        Vector3 toTarget = rotation * Vector3.forward * m_distance;
        //ī�޶��� ���� ����
        Vector3 up = Vector3.up * m_height;
        //Ÿ���� ���� ���� 
        Vector3 targetUp = Vector3.up * m_targetHeight;

        transform.position = (m_target.position + targetUp) - toTarget + up;
        //LookAt : � ���� forward���� �ٶ󺸰� ���ִ� �Լ�
        transform.LookAt(m_target.position + targetUp);
    }

    private void OnDrawGizmos()
    {
        if (m_target == null)
            return;

        Vector3 targetUp = Vector3.up * m_targetHeight;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, m_target.position + targetUp);
    }
}