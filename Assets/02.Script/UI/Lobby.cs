using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Lobby : MonoBehaviour
{
    [SerializeField] Player player;



    public void ATKUP()
    {
        player._atk += 1;
        player.Save();

    }

    public void HPUP()
    {
        player._hp += 1;
        player.Save();
    }
    public void MATKUP()
    {
        player._matk += 1;
        player.Save();
    }
    public void ATKSPEEDUP()
    {
        player._atkSpeed += 1;
        player.Save();
    }
    public void DEFUP()
    {
        player._def += 1;
        player.Save();
    }
    public void SPEEDUP()
    {
        player._speed += 1;
        player.Save();
    }
    public void CRITICALUP()
    {
        player._critical += 1;
        player.Save();
    }
    public void HANDICRAFTUP()
    {
        player._handicraft += 1;
        player.Save();
    }
    public void CHARMUP()
    {
        player._charm += 1;
        player.Save();
    }

}
