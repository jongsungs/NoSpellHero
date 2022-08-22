using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform m_target;        //따라갈 타겟
    [SerializeField] float m_distance = 10f;    //타겟과의 거리 
    [SerializeField] float m_height = 5f;       //카메라 높이
    [SerializeField] float m_targetHeight = 2f; //따라갈 목표점 높이
    [SerializeField] float m_targetEulerAngleY = 0f;    //타겟 중심으로 회전할 회전값
    [SerializeField] float m_rotateSpeed = 5f;  //회전 스피드

    //Update가 끝나고 실행되는게 LateUpdate
    private void LateUpdate()
    {
        //Quaternion.Euler : 오일러각도를 쿼터니언으로 변환해주는 함수
        Quaternion rotation = Quaternion.Euler(0f, m_targetEulerAngleY, 0f);

        //어떤 쿼터니언 값 * 방향벡터
        Vector3 toTarget = rotation * Vector3.forward * m_distance;
        //카메라의 높이 벡터
        Vector3 up = Vector3.up * m_height;
        //타겟의 높이 벡터 
        Vector3 targetUp = Vector3.up * m_targetHeight;

        transform.position = (m_target.position + targetUp) - toTarget + up;
        //LookAt : 어떤 점을 forward축이 바라보게 해주는 함수
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