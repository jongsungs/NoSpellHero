using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpBar : MonoBehaviour
{

    public Camera _maincam;

    void Update()
    {
        transform.position = _maincam.WorldToScreenPoint(Player.Instance.m_transform.position) + new Vector3(0f, -120f, 0f);
    }
}
