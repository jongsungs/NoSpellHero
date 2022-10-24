using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummy : MonoBehaviour
{
    public void AttackOn()
    {
        Player.Instance.AttackOn();
    }

    public void AttackOff()
    {
        Player.Instance.AttackOff();
    }
}
