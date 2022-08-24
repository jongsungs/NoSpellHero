using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Lobby : MonoBehaviour
{
    [SerializeField] Player _player;
    public GameObject _inGameTitlePopUp;
    public GameObject _achivementPopUp;

    public List<GameObject> _listStatSpace = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _player._atk; ++i)
        {
            _listStatSpace[0].transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < _player._matk; ++i)
        {
            _listStatSpace[1].transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < _player._atkSpeed; ++i)
        {
            _listStatSpace[2].transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < _player._hp; ++i)
        {
            _listStatSpace[3].transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < _player._def; ++i)
        {
            _listStatSpace[4].transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < _player._speed; ++i)
        {
            _listStatSpace[5].transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < _player._critical; ++i)
        {
            _listStatSpace[6].transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < _player._handicraft; ++i)
        {
            _listStatSpace[7].transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < _player._charm; ++i)
        {
            _listStatSpace[8].transform.GetChild(i).gameObject.SetActive(true);
        }

    }



    public void ATKUP()
    {
        
        _player._atk += 1;
        _player.Save();
        for(int i = 0; i <_player._atk; ++i)
        {
            _listStatSpace[0].transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void HPUP()
    {
        _player._hp += 1;
        _player.Save();
        for (int i = 0; i < _player._hp; ++i)
        {
            _listStatSpace[3].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void MATKUP()
    {
        _player._matk += 1;
        _player.Save();
        for (int i = 0; i < _player._matk; ++i)
        {
            _listStatSpace[1].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void ATKSPEEDUP()
    {
        _player._atkSpeed += 1;
        _player.Save();
        for (int i = 0; i < _player._atkSpeed; ++i)
        {
            _listStatSpace[2].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void DEFUP()
    {
        _player._def += 1;
        _player.Save();
        for (int i = 0; i < _player._def; ++i)
        {
            _listStatSpace[4].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void SPEEDUP()
    {
        _player._speed += 1;
        _player.Save();
        for (int i = 0; i < _player._speed; ++i)
        {
            _listStatSpace[5].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void CRITICALUP()
    {
        _player._critical += 1;
        _player.Save();
        for (int i = 0; i < _player._critical; ++i)
        {
            _listStatSpace[6].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void HANDICRAFTUP()
    {
        _player._handicraft += 1;
        _player.Save();
        for (int i = 0; i < _player._handicraft; ++i)
        {
            _listStatSpace[7].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void CHARMUP()
    {
        _player._charm += 1;
        _player.Save();
        for (int i = 0; i < _player._charm; ++i)
        {
            _listStatSpace[8].transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void StatReset()
    {
        _player._atk = 0;
        _player._atkSpeed = 0;
        _player._charm = 0;
        _player._critical = 0;
        _player._def = 0;
        _player._handicraft = 0;
        _player._hp = 0;
        _player._matk = 0;
        _player._speed = 0;
        _player.Save();
        for(int i = 0; i <_listStatSpace.Count; ++i)
        {
            for(int j= 0; j < _listStatSpace[i].transform.childCount; ++j)
            {
                _listStatSpace[i].transform.GetChild(j).gameObject.SetActive(false);
            }
        }

    }

    public void EnterInGameTitlePopUP()
    {
        _inGameTitlePopUp.SetActive(true);
    }
    public void ExitInGameTitlePopUP()
    {
        _inGameTitlePopUp.SetActive(false);
    }
    public void EnterAchivementPopUp()
    {
        _achivementPopUp.SetActive(true);
    }
    public void ExitAchivemntPopUp()
    {
        _achivementPopUp.SetActive(false);
    }
    public void StartGame()
    {
        LoadSceneManager.LoadScene("GamePlay");
        GameFlowManager.Instance._isLobby = true;
    }



}
