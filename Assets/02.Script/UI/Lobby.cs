using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Lobby : MonoBehaviour
{
    [SerializeField] Player _player;
    public GameObject _closetPopUp;
    public GameObject _achivementPopUp;
    public GameObject _playerTitleText;
    public GameObject _statePopUp;
    public GameObject _checkOutPopUp;
    public GameObject _alarmPopUp;

    public List<GameObject> _listWeapon = new List<GameObject>();
    public List<GameObject> _listHelmet = new List<GameObject>();
    public List<GameObject> _listHair = new List<GameObject>();
    public List<GameObject> _listTop = new List<GameObject>();
    public List<GameObject> _listBottom = new List<GameObject>();
    public List<GameObject> _listShoes = new List<GameObject>();

    public List<GameObject> _listScreen = new List<GameObject>();

    public bool _OnTitle;
    public bool _isSet;
    public int _3master;

    public int _choiceNumber;


    public List<GameObject> _listStatSpace = new List<GameObject>();
    
    private void OnEnable()
    {

        _statePopUp.SetActive(true);
        _closetPopUp.SetActive(false);
        _checkOutPopUp.SetActive(false);
        _alarmPopUp.SetActive(false);
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
                achivementCheck(_player.getmagicalblader, "getmagicalblader");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._atk == 5 && _player._matk == 5 && _player._critical == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.MadMan;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getmadman, "getmadman");
                achivementCheck(_player.firstjob, "firstjob");



            }
            else if (_player._atk == 5 && _player._matk == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.StrongMan;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                
                achivementCheck(_player.getstrongman, "getstrongman");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Warrior;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
               
                achivementCheck(_player.getwarrior, "getwarrior");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Dwarf;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
           
                achivementCheck(_player.getdwarf, "getdwarf");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.JackFrost;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                
                achivementCheck(_player.getjackfrost, "getjackfrost");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.AssaultCaptain;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
               
                achivementCheck(_player.getassaultcaptain, "getassaultcaptain");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.ZhangFei;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
               
                achivementCheck(_player.getzhangfei, "getzhangfei");
                achivementCheck(_player.firstjob, "firstjob");

            }
            else if (_player._atk == 5 && _player._critical == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Berserker;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                
                achivementCheck(_player.getberserker, "getberserker");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._atk == 5 && _player._critical == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Critialer;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
               
                achivementCheck(_player.getcriticaler, "getcriticaler");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._atk == 5 && _player._critical == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Druid;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                
                achivementCheck(_player.getdruid, "getdruid");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._atk == 5 && _player._critical == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Assassin;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
               
                achivementCheck(_player.getassassin,"getassassin");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._atk == 5 && _player._atkSpeed == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Ambidextrous;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
               
                achivementCheck(_player.getambidextrous, "getambidextrous");
                achivementCheck(_player.firstjob, "firstjob");

            }
            else if (_player._atk == 5 && _player._handicraft == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.LuBu;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
               
                achivementCheck(_player.getlubu, "getlubu");
                achivementCheck(_player.firstjob, "firstjob");

            }
            else if (_player._atk == 5 && _player._speed == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.HeavyCavalry;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getheavycavalry, "getheavycavalry");
                achivementCheck(_player.firstjob, "firstjob");

            }
            else if (_player._matk == 5 && _player._hp == 5 && _player._critical == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.HealthMagician;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.gethealthmagician, "gethealthmagician");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._matk == 5 && _player._hp == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Priest;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getprist, "getprist");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._matk == 5 && _player._critical == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Warlock;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getwarlock, "getwarlock");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._matk == 5 && _player._critical == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Salamander;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getsalamander, "getsalamander");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._matk == 5 && _player._critical == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Zeus;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getzeus, "getzeus");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._matk == 5 && _player._atkSpeed == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.PracticeBug;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getpracticebug, "getpracticebug");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._matk == 5 && _player._charm == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Stranger;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getstranger, "getstranger");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._matk == 5 && _player._handicraft == 5 && _player._def == 5)
            {
                //아직 미구현
              //  _OnTitle = true;
              //  _player._playerTitle = Player.PlayerTitle.GateKeeper;
              //  _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                
            }
            else if (_player._hp == 5 && _player._atkSpeed == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Cook;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getcook, "getcook");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._hp == 5 && _player._atkSpeed == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.QRF;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getqrf, "getqrf");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._hp == 5 && _player._handicraft == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Servant;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getservant, "getservant");
                achivementCheck(_player.firstjob, "firstjob");
            }
            
            else if (_player._hp == 5 && _player._handicraft == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Athlete;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getathlete, "getathlete");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._hp == 5 && _player._handicraft == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Versatile;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getversatile, "getversatile");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._hp == 5 && _player._speed == 5 && _player._def == 5)
            {
                //미구현
               // _OnTitle = true;
               // _player._playerTitle = Player.PlayerTitle.Shieldbearer;
               // _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
               // achivementCheck(_player.getshield)
            }
            else if (_player._critical == 5 && _player._atkSpeed == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Acupuncturist;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getacupuncturist, "getacupuncturist");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._critical == 5 && _player._speed == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.SpoonKiller;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getspoonkiller, "getspoonkiller");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._critical == 5 && _player._handicraft == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Helen;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.gethelen, "gethelen");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._critical == 5 && _player._speed == 5 && _player._handicraft == 5)
            {
               //미구현
               // _OnTitle = true;
               // _player._playerTitle = Player.PlayerTitle.Slicker;
               // _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
               // achivementCheck(_player.getsli)
            }
            else if (_player._critical == 5 && _player._speed == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Rich;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getrich, "getrich");
                achivementCheck(_player.firstjob, "firstjob");

            }
            else if (_player._atkSpeed == 5 && _player._handicraft == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Swell;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getswell, "getswell");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._atkSpeed == 5 && _player._handicraft == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Delivery;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getdelivery, "getdelivery");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._atkSpeed == 5 && _player._handicraft == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Repairman;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getrepairman, "getrepairman");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._atkSpeed == 5 && _player._charm == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Dosa;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getdosa, "getdosa");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._handicraft == 5 && _player._charm == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Gambler;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getgambler, "getgambler");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._handicraft == 5 && _player._charm == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.SlowStarter;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getslowstarter, "getslowstarter");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._handicraft == 5 && _player._def == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Orpheus;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getorpheus, "getorpheus");
                achivementCheck(_player.firstjob, "firstjob");
            }
            else if (_player._charm == 5 && _player._def == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.DokeV;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
                achivementCheck(_player.getdokev, "getdokev");
                achivementCheck(_player.firstjob, "firstjob");
            }
        }
        #endregion
        
        if ((_player._hp > 0 || _player._atk > 0 || _player._matk > 0 || _player._atkSpeed > 0 || _player._def > 0 || _player._speed > 0 || _player._critical > 0 || _player._handicraft > 0 || _player._charm > 0) &&
            _player.firststat == false)
        {
            achivementCheck(_player.firststat, "firststat");
        }
        if ((_player._hp > 4 || _player._atk > 4 || _player._matk > 4 || _player._atkSpeed > 4 || _player._def > 4 || _player._speed > 4 || _player._critical > 4 || _player._handicraft > 4 || _player._charm > 4) &&
            _player.firstmaster == false)
        {
            achivementCheck(_player.firststat, "firstmaster");
        }

        if (_OnTitle == true)
        {
            if (_isSet == false)
            {
                //ReState();
            }



            
            if (_player._playerTitle != Player.PlayerTitle.Normal)
            {

                if (_player._atk >= 5)
                {
                    _player._atk = 5;
                }
                else if (_player._atk >= 3 /*&& _player._atk != 5*/)
                {
                    _player._atk = 3;
                    _listStatSpace[0].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[0].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._matk >= 5)
                {
                    _player._matk = 5;
                }
                else if (_player._matk >= 3 /*&& _player._matk != 5*/)
                {
                    _player._matk = 3;
                    _listStatSpace[1].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[1].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._atkSpeed >= 5)
                {
                    _player._atkSpeed = 5;
                }
                else if (_player._atkSpeed >= 3 /*&& _player._atkSpeed != 5*/)
                {
                    _player._atkSpeed = 3;
                    _listStatSpace[2].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[2].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._hp >= 5)
                {
                    _player._hp = 5;
                }
                else if (_player._hp >= 3 /*&& _player._hp != 5*/)
                {
                    _player._hp = 3;
                    _listStatSpace[3].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[3].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._def >= 5)
                {
                    _player._def = 5;
                }
                else if (_player._def >= 3 /*&& _player._def != 5*/)
                {
                    _player._def = 3;
                    _listStatSpace[4].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[4].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._speed >= 5)
                {
                    _player._speed = 5;
                }
                else if (_player._speed >= 3 /*&& _player._speed != 5*/)
                {
                    _player._speed = 3;
                    _listStatSpace[5].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[5].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._critical >= 5)
                {
                    _player._critical = 5;
                }
                else if (_player._critical >= 3 /*&& _player._critical != 5*/)
                {
                    _player._critical = 3;
                    _listStatSpace[6].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[6].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._handicraft >= 5)
                {
                    _player._handicraft = 5;
                }
                else if (_player._handicraft >= 3 /*&& _player._handicraft != 5*/)
                {
                    _player._handicraft = 3;
                    _listStatSpace[7].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[7].transform.GetChild(3).gameObject.SetActive(false);
                }
                if (_player._charm >= 5)
                {
                    _player._charm = 5;
                }
                else if (_player._charm >= 3 /*&& _player._charm != 5*/)
                {
                    _player._charm = 3;
                    _listStatSpace[8].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[8].transform.GetChild(3).gameObject.SetActive(false);
                }

            }
        }
        #region Weapon
        if (_player._isStick == true)
        {
            _listWeapon[0].SetActive(true);
        }
        else if (_player._isStick == false)
        {
            _listWeapon[0].SetActive(false);
        }

        if (_player._isSward1 == true)
        {
            _listWeapon[1].SetActive(true);
        }
        else if (_player._isSward1 == false)
        {
            _listWeapon[1].SetActive(false);
        }

        if (_player._isSward2 == true)
        {
            _listWeapon[2].SetActive(true);
        }
        else if (_player._isSward2 == false)
        {
            _listWeapon[2].SetActive(false);
        }

        if (_player._isBroom == true)
        {
            _listWeapon[3].SetActive(true);
        }
        else if (_player._isBroom == false)
        {
            _listWeapon[3].SetActive(false);
        }

        if (_player._isClub == true)
        {
            _listWeapon[4].SetActive(true);
        }
        else if (_player._isClub == false)
        {
            _listWeapon[4].SetActive(false);
        }
        if (_player._isShortSward == true)
        {
            _listWeapon[5].SetActive(true);
        }
        else if (_player._isShortSward == false)
        {
            _listWeapon[5].SetActive(false);
        }
        if (_player._isHanger == true)
        {
            _listWeapon[6].SetActive(true);
        }
        else if (_player._isHanger == false)
        {
            _listWeapon[6].SetActive(false);
        }
        if (_player._isMace == true)
        {
            _listWeapon[7].SetActive(true);
        }
        else if (_player._isMace == false)
        {
            _listWeapon[7].SetActive(false);
        }
        if (_player._isShield == true)
        {
            _listWeapon[8].SetActive(true);
        }
        else if (_player._isShield == false)
        {
            _listWeapon[8].SetActive(false);
        }
        if (_player._isSpear == true)
        {
            _listWeapon[9].SetActive(true);
        }
        else if (_player._isSpear == false)
        {
            _listWeapon[9].SetActive(false);
        }
        if (_player._isUmbrella == true)
        {
            _listWeapon[10].SetActive(true);
        }
        else if (_player._isUmbrella == false)
        {
            _listWeapon[10].SetActive(false);
        }
        if (_player._isWaldo == true)
        {
            _listWeapon[11].SetActive(true);
        }
        else if (_player._isWaldo == false)
        {
            _listWeapon[11].SetActive(false);
        }
        


        #endregion
        #region Hair
        if (_player._isnormalHair == true)
        {
            _listHair[0].SetActive(true);
        }
        else if (_player._isnormalHair == false)
        {
            _listHair[0].SetActive(false);
        }

        if (_player._isSkinHead == true)
        {
            _listHair[1].SetActive(true);
        }
        else if (_player._isSkinHead == false)
        {
            _listHair[1].SetActive(false);
        }

        
        #endregion
        #region Helmet
        if (_player._isEmptyHelmet == true)
        {
            _listHelmet[0].SetActive(true);
        }
        else if (_player._isEmptyHelmet == false)
        {
            _listHelmet[0].SetActive(false);
        }

        if (_player._isKightHelmet == true)
        {
            _listHelmet[1].SetActive(true);
        }
        else if (_player._isKightHelmet == false)
        {
            _listHelmet[1].SetActive(false);
        }

        if (_player._masicianHat == true)
        {
            _listHelmet[2].SetActive(true);
        }
        else if (_player._masicianHat == false)
        {
            _listHelmet[2].SetActive(false);
        }

        if (_player._isGat == true)
        {
            _listHelmet[3].SetActive(true);
        }
        else if (_player._isGat == false)
        {
            _listHelmet[3].SetActive(false);
        }
        #endregion
        #region Top
        if (_player._isNormalTop == true)
        {
            _listTop[0].SetActive(true);
        }
        else if(_player._isNormalTop == false)
        {
            _listTop[0].SetActive(false);
        }

        if (_player._isKnightTop == true)
        {
            _listTop[1].SetActive(true);
        }
        else if (_player._isKnightTop == false)
        {
            _listTop[1].SetActive(false);
        }

        if (_player._isMasicianTop == true)
        {
            _listTop[2].SetActive(true);
        }
        else if (_player._isMasicianTop == false)
        {
            _listTop[2].SetActive(false);
        }

        if (_player._isDurumagiTop == true)
        {
            _listTop[3].SetActive(true);
        }
        else if (_player._isDurumagiTop == false)
        {
            _listTop[3].SetActive(false);
        }
        #endregion
        #region Bottom
        if (_player._isTrunkBottom == true)
        {
            _listBottom[0].SetActive(true);
        }
        else if (_player._isTrunkBottom == false)
        {
            _listBottom[0].SetActive(false);
        }

        if (_player._isKnightBottom == true)
        {
            _listBottom[1].SetActive(true);
        }
        else if (_player._isKnightBottom == false)
        {
            _listBottom[1].SetActive(false);
        }

        if (_player._isMasicianBottom == true)
        {
            _listBottom[2].SetActive(true);
        }
        else if (_player._isMasicianBottom == false)
        {
            _listBottom[2].SetActive(false);
        }

        if (_player._isdurumagiBottom == true)
        {
            _listBottom[3].SetActive(true);
        }
        else if (_player._isdurumagiBottom == false)
        {
            _listBottom[3].SetActive(false);
        }
        #endregion
        #region Shoes
        if (_player._isnormalShoes == true)
        {
            _listShoes[0].SetActive(true);
        }
        else if (_player._isnormalShoes == false)
        {
            _listShoes[0].SetActive(false);
        }

        if (_player._isKnightShoes == true)
        {
            _listShoes[1].SetActive(true);
        }
        else if (_player._isKnightShoes == false)
        {
            _listShoes[1].SetActive(false);
        }

        if (_player._isSandal == true)
        {
            _listShoes[2].SetActive(true);
        }
        else if (_player._isSandal == false)
        {
            _listShoes[2].SetActive(false);
        }

        if (_player._isOldShoes == true)
        {
            _listShoes[3].SetActive(true);
        }
        else if (_player._isOldShoes == false)
        {
            _listShoes[3].SetActive(false);
        }
        #endregion
        #region UnpackItem
        if(Player.Instance._buyStick == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[0].SetActive(true);
        }
        else if(Player.Instance._buyStick == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[0].SetActive(false);
        }

        if (Player.Instance._buySward1 == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[1].SetActive(true);
        }
        else if (Player.Instance._buySward1 == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[1].SetActive(false);
        }

        if (Player.Instance._buySward2 == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[2].SetActive(true);
        }
        else if (Player.Instance._buySward2 == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[2].SetActive(false);
        }

        if (Player.Instance._buyBroom == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[3].SetActive(true);
        }
        else if (Player.Instance._buyBroom == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[3].SetActive(false);
        }

        if (Player.Instance._buyClub == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[4].SetActive(true);
        }
        else if (Player.Instance._buyClub == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[4].SetActive(false);
        }

        if (Player.Instance._buyShortSward == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[5].SetActive(true);
        }
        else if (Player.Instance._buyShortSward == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[5].SetActive(false);
        }

        if (Player.Instance._buyHanger == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[6].SetActive(true);
        }
        else if (Player.Instance._buyHanger == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[6].SetActive(false);
        }

        if (Player.Instance._buyMace == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[7].SetActive(true);
        }
        else if (Player.Instance._buyMace == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[7].SetActive(false);
        }

        if (Player.Instance._buyShield == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[8].SetActive(true);
        }
        else if (Player.Instance._buyShield == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[8].SetActive(false);
        }

        if (Player.Instance._buySpear == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[9].SetActive(true);
        }
        else if (Player.Instance._buySpear == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[9].SetActive(false);
        }

        if (Player.Instance._buyUmbrella == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[10].SetActive(true);
        }
        else if (Player.Instance._buyUmbrella == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[10].SetActive(false);
        }

        if (Player.Instance._buyWaldo == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[11].SetActive(true);
        }
        else if (Player.Instance._buyWaldo == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[11].SetActive(false);
        }

        if (Player.Instance._buyEmptyHelmet == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[12].SetActive(true);
        }
        else if (Player.Instance._buyEmptyHelmet == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[12].SetActive(false);
        }

        if (Player.Instance._buyKightHelmet == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[13].SetActive(true);
        }
        else if (Player.Instance._buyKightHelmet == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[13].SetActive(false);
        }

        if (Player.Instance._buyMasicianHat == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[14].SetActive(true);
        }
        else if (Player.Instance._buyMasicianHat == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[14].SetActive(false);
        }

        if (Player.Instance._buyGat == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[15].SetActive(true);
        }
        else if (Player.Instance._buyGat == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[15].SetActive(false);
        }

        if (Player.Instance._buynormalHair == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[16].SetActive(true);
        }
        else if (Player.Instance._buynormalHair == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[16].SetActive(false);
        }

        if (Player.Instance._buySkinHead == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[17].SetActive(true);
        }
        else if (Player.Instance._buySkinHead == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[17].SetActive(false);
        }

        if (Player.Instance._buyNormalTop == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[18].SetActive(true);
        }
        else if (Player.Instance._buyNormalTop == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[18].SetActive(false);
        }

        if (Player.Instance._buyKnightTop == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[19].SetActive(true);
        }
        else if (Player.Instance._buyKnightTop == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[19].SetActive(false);
        }

        if (Player.Instance._buyMasicianTop == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[20].SetActive(true);
        }
        else if (Player.Instance._buyMasicianTop == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[20].SetActive(false);
        }

        if (Player.Instance._buyDurumagiTop == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[21].SetActive(true);
        }
        else if (Player.Instance._buyDurumagiTop == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[21].SetActive(false);
        }

        if (Player.Instance._buyTrunkBottom == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[22].SetActive(true);
        }
        else if (Player.Instance._buyTrunkBottom == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[22].SetActive(false);
        }

        if (Player.Instance._buyKnightBottom == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[23].SetActive(true);
        }
        else if (Player.Instance._buyKnightBottom == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[23].SetActive(false);
        }

        if (Player.Instance._buyMasicianBottom == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[24].SetActive(true);
        }
        else if (Player.Instance._buyMasicianBottom == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[24].SetActive(false);
        }

        if (Player.Instance._buydurumagiBottom == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[25].SetActive(true);
        }
        else if (Player.Instance._buydurumagiBottom == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[25].SetActive(false);
        }

        if (Player.Instance._buynormalShoes == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[26].SetActive(true);
        }
        else if (Player.Instance._buynormalShoes == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[26].SetActive(false);
        }

        if (Player.Instance._buyKnightShoes == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[27].SetActive(true);
        }
        else if (Player.Instance._buyKnightShoes == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[27].SetActive(false);
        }

        if (Player.Instance._buySandal == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[28].SetActive(true);
        }
        else if (Player.Instance._buySandal == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[28].SetActive(false);
        }

        if (Player.Instance._buyOldShoes == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[29].SetActive(true);
        }
        else if (Player.Instance._buyOldShoes == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[29].SetActive(false);
        }



        #endregion

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
        _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
        _OnTitle = false;
    }

    public void EnterClosetPopUP()
    {
        _closetPopUp.SetActive(true);
        _statePopUp.SetActive(false);
    }
    public void ExitClosetPopUP()
    {
        _closetPopUp.SetActive(false);
        _statePopUp.SetActive(true);
    }
    public void EnterAchivementPopUp()
    {
        _achivementPopUp.SetActive(true);
    }
    public void ExitAchivemntPopUp()
    {
        _achivementPopUp.SetActive(false);
    }

    public void ChoiceWeapon(int cnt)
    {
        _choiceNumber = cnt;
        if (cnt == 0 && _listScreen[0].activeSelf == false)
        {
            _player._isStick = true;
            _player._isSward1 = false;
            _player._isSward2 = false;
            _player._isBroom = false;
            _player._isClub = false;
            _player._isShortSward = false;
            _player._isHanger = false;
            _player._isMace = false;
            _player._isShield = false;
            _player._isSpear = false;
            _player._isUmbrella = false;
            _player._isWaldo = false;

        }
        else if(cnt == 0 && _listScreen[0].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 1&& _listScreen[1].activeSelf == false)
        {
            _player._isStick = false;
            _player._isSward1 = true;
            _player._isSward2 = false;
            _player._isBroom = false;
            _player._isClub = false;
            _player._isShortSward = false;
            _player._isHanger = false;
            _player._isMace = false;
            _player._isShield = false;
            _player._isSpear = false;
            _player._isUmbrella = false;
            _player._isWaldo = false;
        }
        else if (cnt == 1 && _listScreen[1].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 2 && _listScreen[2].activeSelf == false)
        {
            _player._isStick = false;
            _player._isSward1 = false;
            _player._isSward2 = true;
            _player._isBroom = false;
            _player._isClub = false;
            _player._isShortSward = false;
            _player._isHanger = false;
            _player._isMace = false;
            _player._isShield = false;
            _player._isSpear = false;
            _player._isUmbrella = false;
            _player._isWaldo = false;
        }
        else if (cnt == 2 && _listScreen[2].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 3 && _listScreen[3].activeSelf == false)
        {
            _player._isStick = false;
            _player._isSward1 = false;
            _player._isSward2 = false;
            _player._isBroom = true;
            _player._isClub = false;
            _player._isShortSward = false;
            _player._isHanger = false;
            _player._isMace = false;
            _player._isShield = false;
            _player._isSpear = false;
            _player._isUmbrella = false;
            _player._isWaldo = false;
        }
        else if (cnt == 3 && _listScreen[3].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 4 && _listScreen[4].activeSelf == false)
        {
            _player._isStick = false;
            _player._isSward1 = false;
            _player._isSward2 = false;
            _player._isBroom = false;
            _player._isClub = true;
            _player._isShortSward = false;
            _player._isHanger = false;
            _player._isMace = false;
            _player._isShield = false;
            _player._isSpear = false;
            _player._isUmbrella = false;
            _player._isWaldo = false;
        }
        else if (cnt == 4 && _listScreen[4].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 5 && _listScreen[5].activeSelf == false)
        {
            _player._isStick = false;
            _player._isSward1 = false;
            _player._isSward2 = false;
            _player._isBroom = false;
            _player._isClub = false;
            _player._isShortSward = true;
            _player._isHanger = false;
            _player._isMace = false;
            _player._isShield = false;
            _player._isSpear = false;
            _player._isUmbrella = false;
            _player._isWaldo = false;
        }
        else if (cnt == 5 && _listScreen[5].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 6 && _listScreen[6].activeSelf == false)
        {
            _player._isStick = false;
            _player._isSward1 = false;
            _player._isSward2 = false;
            _player._isBroom = false;
            _player._isClub = false;
            _player._isShortSward = false;
            _player._isHanger = true;
            _player._isMace = false;
            _player._isShield = false;
            _player._isSpear = false;
            _player._isUmbrella = false;
            _player._isWaldo = false;
        }
        else if (cnt == 6 && _listScreen[6].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 7 && _listScreen[7].activeSelf == false)
        {
            _player._isStick = false;
            _player._isSward1 = false;
            _player._isSward2 = false;
            _player._isBroom = false;
            _player._isClub = false;
            _player._isShortSward = false;
            _player._isHanger = false;
            _player._isMace = true;
            _player._isShield = false;
            _player._isSpear = false;
            _player._isUmbrella = false;
            _player._isWaldo = false;
        }
        else if (cnt == 7 && _listScreen[7].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 8 && _listScreen[8].activeSelf == false)
        {
            _player._isStick = false;
            _player._isSward1 = false;
            _player._isSward2 = false;
            _player._isBroom = false;
            _player._isClub = false;
            _player._isShortSward = false;
            _player._isHanger = false;
            _player._isMace = false;
            _player._isShield = true;
            _player._isSpear = false;
            _player._isUmbrella = false;
            _player._isWaldo = false;
        }
        else if (cnt == 8 && _listScreen[8].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 9 && _listScreen[9].activeSelf == false)
        {
            _player._isStick = false;
            _player._isSward1 = false;
            _player._isSward2 = false;
            _player._isBroom = false;
            _player._isClub = false;
            _player._isShortSward = false;
            _player._isHanger = false;
            _player._isMace = false;
            _player._isShield = false;
            _player._isSpear = true;
            _player._isUmbrella = false;
            _player._isWaldo = false;
        }
        else if (cnt == 9 && _listScreen[9].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 10 && _listScreen[10].activeSelf == false)
        {
            _player._isStick = false;
            _player._isSward1 = false;
            _player._isSward2 = false;
            _player._isBroom = false;
            _player._isClub = false;
            _player._isShortSward = false;
            _player._isHanger = false;
            _player._isMace = false;
            _player._isShield = false;
            _player._isSpear = false;
            _player._isUmbrella = true;
            _player._isWaldo = false;
        }
        else if (cnt == 10 && _listScreen[10].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 11 && _listScreen[11].activeSelf == false)
        {
            _player._isStick = false;
            _player._isSward1 = false;
            _player._isSward2 = false;
            _player._isBroom = false;
            _player._isClub = false;
            _player._isShortSward = false;
            _player._isHanger = false;
            _player._isMace = false;
            _player._isShield = false;
            _player._isSpear = false;
            _player._isUmbrella = false;
            _player._isWaldo = true;
        }
        else if (cnt == 11 && _listScreen[11].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        _player.Save();
    }
    public void ChoiceHelmet(int cnt)
    {
        _choiceNumber = cnt;
        if (cnt == 26 && _listScreen[12].activeSelf == false )
        {
            _player._isEmptyHelmet = true;
            _player._isKightHelmet = false;
            _player._isMasicianHat = false;
            _player._isGat = false;

        }
        else if(cnt == 26 && _listScreen[12].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 12 && _listScreen[13].activeSelf == false)
        {
            _player._isEmptyHelmet = false;
            _player._isKightHelmet = true;
            _player._isMasicianHat = false;
            _player._isGat = false;
        }
        else if (cnt == 12 && _listScreen[13].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 13 && _listScreen[14].activeSelf == false)
        {
            _player._isEmptyHelmet = false;
            _player._isKightHelmet = false;
            _player._isMasicianHat = true;
            _player._isGat = false;
        }
        else if (cnt == 13 && _listScreen[14].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 14 && _listScreen[15].activeSelf == false)
        {
            _player._isEmptyHelmet = false;
            _player._isKightHelmet = false;
            _player._isMasicianHat = false;
            _player._isGat = true;
        }
        else if (cnt == 14 && _listScreen[15].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        _player.Save();
    }
    public void ChoiceHair(int cnt)
    {
        _choiceNumber = cnt;

        if (cnt == 16 &&_listScreen[16].activeSelf == false)
        {
            _player._isnormalHair = true;
            _player._isSkinHead = false;
        }
        else if (cnt == 16 && _listScreen[16].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 15 && _listScreen[17].activeSelf == false)
        {
            _player._isnormalHair = false;
            _player._isSkinHead = true;
        }
        else if(cnt == 15 && _listScreen[17].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }

        _player.Save();

    }

    public void ChoiceTop(int cnt)
    {
        _choiceNumber = cnt;

        if (cnt == 27 && _listScreen[18].activeSelf == false)
        {
            _player._isNormalTop = true;
            _player._isKnightTop = false;
            _player._isMasicianTop = false;
            _player._isDurumagiTop = false;

        }
        else if (cnt == 27 && _listScreen[18].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if(cnt == 17 && _listScreen[19].activeSelf == false)
        {
            _player._isNormalTop = false;
            _player._isKnightTop = true;
            _player._isMasicianTop = false;
            _player._isDurumagiTop = false;
        }
        else if (cnt == 17 && _listScreen[19].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if(cnt == 18 && _listScreen[20].activeSelf == false)
        {
            _player._isNormalTop = false;
            _player._isKnightTop = false;
            _player._isMasicianTop = true;
            _player._isDurumagiTop = false;
        }
        else if (cnt == 18 && _listScreen[20].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 19 && _listScreen[21].activeSelf == false)
        {
            _player._isNormalTop = false;
            _player._isKnightTop = false;
            _player._isMasicianTop = false;
            _player._isDurumagiTop = true;
        }
        else if (cnt == 19 && _listScreen[21].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        _player.Save();
    }
    public void ChoiceBottom(int cnt)
    {
        _choiceNumber = cnt;

        if (cnt == 28 && _listScreen[22].activeSelf == false)
        {
            _player._isTrunkBottom = true;
            _player._isKnightBottom = false;
            _player._isMasicianBottom = false;
            _player._isdurumagiBottom = false;

        }
        else if (cnt == 28 && _listScreen[22].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 20 && _listScreen[23].activeSelf == false)
        {
            _player._isTrunkBottom = false;
            _player._isKnightBottom = true;
            _player._isMasicianBottom = false;
            _player._isdurumagiBottom = false;
        }
        else if (cnt == 20 && _listScreen[23].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 21 && _listScreen[24].activeSelf == false)
        {
            _player._isTrunkBottom = false;
            _player._isKnightBottom = false;
            _player._isMasicianBottom = true;
            _player._isdurumagiBottom = false;
        }
        else if (cnt == 21 && _listScreen[24].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 22 && _listScreen[25].activeSelf == false)
        {
            _player._isTrunkBottom = false;
            _player._isKnightBottom = false;
            _player._isMasicianBottom = false;
            _player._isdurumagiBottom = true;
        }
        else if (cnt == 22 && _listScreen[25].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        _player.Save();
    }
    public void ChoiceShoes(int cnt)
    {
        _choiceNumber = cnt;

        if (cnt == 29 && _listScreen[26].activeSelf == false)
        {
            _player._isnormalShoes = true;
            _player._isKnightShoes = false;
            _player._isSandal = false;
            _player._isOldShoes = false;

        }
        else if (cnt == 29 && _listScreen[26].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 23 && _listScreen[27].activeSelf == false)
        {
            _player._isnormalShoes = false;
            _player._isKnightShoes = true;
            _player._isSandal = false;
            _player._isOldShoes = false;
        }
        else if (cnt == 23 && _listScreen[27].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 24 && _listScreen[28].activeSelf == false)
        {
            _player._isnormalShoes = false;
            _player._isKnightShoes = false;
            _player._isSandal = true;
            _player._isOldShoes = false;
        }
        else if (cnt == 24 && _listScreen[28].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
        else if (cnt == 25 && _listScreen[29].activeSelf == false)
        {
            _player._isnormalShoes = false;
            _player._isKnightShoes = false;
            _player._isSandal = false;
            _player._isOldShoes = true;
        }
        else if (cnt == 25 && _listScreen[29].activeSelf == true)
        {
            EnterCheckOutPopUp();
        }
    }

    public int SelectNumber(int i)
    {
        _choiceNumber = i;
        return _choiceNumber;
    }
    public void EnterCheckOutPopUp()
    {
        _checkOutPopUp.SetActive(true);
    }
    public void ExitCheckOutPopUp()
    {
        _checkOutPopUp.SetActive(false);
    }
    public void CheckOutPopUpYes()
    {
        if(_choiceNumber  == 0)
        {
            Player.Instance._buyStick = true;
        }
        else if (_choiceNumber == 1)
        {
            Player.Instance._buySward1 = true;
        }
        else if (_choiceNumber == 2)
        {
            Player.Instance._buySward2 = true;
        }
        else if (_choiceNumber == 3)
        {
            Player.Instance._buyBroom = true;
        }
        else if (_choiceNumber == 4)
        {
            Player.Instance._buyClub = true;
        }
        else if (_choiceNumber == 5)
        {
            Player.Instance._buyShortSward = true;
        }
        else if (_choiceNumber == 6)
        {
            Player.Instance._buyHanger = true;
        }
        else if (_choiceNumber == 7)
        {
            Player.Instance._buyMace = true;
        }
        else if (_choiceNumber == 8)
        {
            Player.Instance._buyShield = true;
        }
        else if (_choiceNumber == 9)
        {
            Player.Instance._buySpear = true;
        }
        else if (_choiceNumber == 10)
        {
            Player.Instance._buyUmbrella = true;
        }
        else if (_choiceNumber == 11)
        {
            Player.Instance._buyWaldo = true;
        }
        else if (_choiceNumber == 12)
        {
            Player.Instance._buyKightHelmet = true;
        }
        else if (_choiceNumber == 13)
        {
            Player.Instance._buyMasicianHat = true;
        }
        else if (_choiceNumber == 14)
        {
            Player.Instance._buyGat = true;
        }
        else if (_choiceNumber == 15)
        {
            Player.Instance._buySkinHead = true;
        }
        else if (_choiceNumber == 16)
        {
            Player.Instance._buynormalHair = true;
        }
        else if (_choiceNumber == 17)
        {
            Player.Instance._buyKnightTop = true;
        }
        else if (_choiceNumber == 18)
        {
            Player.Instance._buyMasicianTop = true;
        }
        else if (_choiceNumber == 19)
        {
            Player.Instance._buyDurumagiTop = true;
        }
        else if (_choiceNumber == 20)
        {
            Player.Instance._buyKnightBottom = true;
        }
        else if (_choiceNumber == 21)
        {
            Player.Instance._buyMasicianBottom = true;
        }
        else if (_choiceNumber == 22)
        {
            Player.Instance._buydurumagiBottom = true;
        }
        else if (_choiceNumber == 23)
        {
            Player.Instance._buyKnightShoes = true;
        }
        else if (_choiceNumber == 24)
        {
            Player.Instance._buySandal = true;
        }
        else if (_choiceNumber == 25)
        {
            Player.Instance._buyOldShoes = true;
        }
        else if (_choiceNumber == 26)
        {
            Player.Instance._buyEmptyHelmet = true;
        }
        else if (_choiceNumber == 27)
        {
            Player.Instance._buyNormalTop = true;
        }
        else if (_choiceNumber == 28)
        {
            Player.Instance._buyTrunkBottom = true;
        }
        else if (_choiceNumber == 29)
        {
            Player.Instance._buynormalShoes = true;
        }
        ExitCheckOutPopUp();

    }
    public void CheckOutPopUpNo()
    {
        ExitCheckOutPopUp();
    }
    public void EnterAlarmPopUp()
    {
        _alarmPopUp.SetActive(true);
    }
    public void ExitAlarmPopUp()
    {
        _alarmPopUp.SetActive(false);
    }

    public void achivementCheck(bool check,string str)
    {
        if (check == false)
        {
            check = true;
            AchievementManager.instance.Unlock(str);
        }
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
