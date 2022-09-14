using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Lobby : MonoBehaviour
{
    [SerializeField] Player _player;
    public GameObject _inGameTitlePopUp;
    public GameObject _achivementPopUp;
    public GameObject _playerTitleText;
    public bool _OnTitle;
    public bool _isSet;

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


    private void Update()
    {

        #region PlayerTitle
        if (_OnTitle == false)
        {
            
            if (_player._atk == 5 && _player._matk == 5 && _player._hp == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.MagicalBlader;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._matk == 5 && _player._critical == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.MadMan;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._matk == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.StrongMan;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Warrior;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Dwarf;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.JackFrost;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.AssaultCaptain;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.ZhangFei;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._critical == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Berserker;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._critical == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Critialer;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._critical == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Druid;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._critical == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Assassin;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._atkSpeed == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Ambidextrous;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._handicraft == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.LuBu;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atk == 5 && _player._speed == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.HeavyCavalry;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._matk == 5 && _player._hp == 5 && _player._critical == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.HealthMagician;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._matk == 5 && _player._hp == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Priest;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._matk == 5 && _player._critical == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Warlock;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._matk == 5 && _player._critical == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Salamander;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._matk == 5 && _player._critical == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Zeus;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._matk == 5 && _player._atkSpeed == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.PracticeBug;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._matk == 5 && _player._charm == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Stranger;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._matk == 5 && _player._handicraft == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.GateKeeper;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._hp == 5 && _player._atkSpeed == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Cook;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._hp == 5 && _player._atkSpeed == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.QRF;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._hp == 5 && _player._handicraft == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Servant;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._hp == 5 && _player._handicraft == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Servant;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._hp == 5 && _player._handicraft == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Athlete;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._hp == 5 && _player._handicraft == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Versatile;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._hp == 5 && _player._speed == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Shieldbearer;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._critical == 5 && _player._atkSpeed == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Acupuncturist;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._critical == 5 && _player._speed == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.SpoonKiller;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._critical == 5 && _player._handicraft == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Helen;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._critical == 5 && _player._speed == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Slicker;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._critical == 5 && _player._speed == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Idol;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atkSpeed == 5 && _player._handicraft == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Swell;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atkSpeed == 5 && _player._handicraft == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Delivery;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atkSpeed == 5 && _player._handicraft == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Repairman;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._atkSpeed == 5 && _player._charm == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Taoist;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._handicraft == 5 && _player._charm == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Gambler;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._handicraft == 5 && _player._charm == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.SlowStarter;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._handicraft == 5 && _player._def == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Orpheus;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
            else if (_player._charm == 5 && _player._def == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.DokeV;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
            }
        }
        #endregion
        
        if(_OnTitle == true)
        {
           if(_isSet == false)
            {
                ReState();
            }



            for(int i = 0; i < _player._listState.Count; ++i)
            {

                for (int z = 0;  z < _player._listState[i]; ++z)
                {
                    _listStatSpace[i].transform.GetChild((int)z).gameObject.SetActive(true);

                }





            }
            if (_player._playerTitle != Player.PlayerTitle.Normal)
            {
                if (_player._hp >= 5)
                {
                    _player._hp = 5;
                }
                else if (_player._hp >= 3 && _player._hp != 5)
                {
                    _player._hp = 3;
                    _listStatSpace[0].transform.GetChild(4).gameObject.SetActive(false);
                }
            }
        }
    }

    public void ATKUP()
    {
        
        _player._atk += 1;
        if(_player._atk >= 5)
        {
            _player._atk = 5f;
        }
        _player.Save();
        for(int i = 0; i <_player._atk; ++i)
        {
            _listStatSpace[0].transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void HPUP()
    {
        _player._hp += 1;
        if (_player._hp >= 5)
        {
            _player._hp = 5f;
        }
        
        _player.Save();
        for (int i = 0; i < _player._hp; ++i)
        {
            _listStatSpace[3].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void MATKUP()
    {
        _player._matk += 1;
        if (_player._matk >= 5)
        {
            _player._matk = 5f;
        }
        _player.Save();
        for (int i = 0; i < _player._matk; ++i)
        {
            _listStatSpace[1].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void ATKSPEEDUP()
    {
        _player._atkSpeed += 1;
        if (_player._atkSpeed >= 5)
        {
            _player._atkSpeed = 5f;
        }
        _player.Save();
        for (int i = 0; i < _player._atkSpeed; ++i)
        {
            _listStatSpace[2].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void DEFUP()
    {
        _player._def += 1;
        if (_player._def >= 5)
        {
            _player._def = 5f;
        }
        _player.Save();
        for (int i = 0; i < _player._def; ++i)
        {
            _listStatSpace[4].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void SPEEDUP()
    {
        _player._speed += 1;

        if (_player._speed >= 5)
        {
            _player._speed = 5f;
        }
        _player.Save();
        for (int i = 0; i < _player._speed; ++i)
        {
            _listStatSpace[5].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void CRITICALUP()
    {
        _player._critical += 1;
        if (_player._critical >= 5)
        {
            _player._critical = 5f;
        }
        _player.Save();
        for (int i = 0; i < _player._critical; ++i)
        {
            _listStatSpace[6].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void HANDICRAFTUP()
    {
        _player._handicraft += 1;
        if (_player._handicraft >= 5)
        {
            _player._handicraft = 5f;
        }
        _player.Save();
        for (int i = 0; i < _player._handicraft; ++i)
        {
            _listStatSpace[7].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void CHARMUP()
    {
        _player._charm += 1;
        if (_player._charm >= 5)
        {
            _player._charm = 5f;
        }
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
        _player._basicAtk = 0;
        _player._basicAtkSpeed = 0;
        _player._basicCharm = 0;
        _player._basicCritical = 0;
        _player._basicDef = 0;
        _player._basicHandicraft = 0;
        _player._basicHp = 0;
        _player._basicMatk = 0;
        _player._basicSpeed = 0;
        _player._maxHp = 0;
        _player.Save();
        for(int i = 0; i <_listStatSpace.Count; ++i)
        {
            for(int j= 0; j < _listStatSpace[i].transform.childCount; ++j)
            {
                _listStatSpace[i].transform.GetChild(j).gameObject.SetActive(false);
            }
        }
        _player._playerTitle = Player.PlayerTitle.Normal;
        _OnTitle = false;
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
    public void ReState()
    {
        _isSet = true;
        for (int i = 0; i < _listStatSpace.Count; ++i)
        {
            for (int z = 0; z < _listStatSpace[i].transform.childCount; ++z)
            {
                _listStatSpace[i].transform.GetChild(z).gameObject.SetActive(false);
            }
        }
    }



}
