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

    public List<GameObject> _listWeapon = new List<GameObject>();
    public List<GameObject> _listHelmet = new List<GameObject>();
    public List<GameObject> _listHair = new List<GameObject>();
    public List<GameObject> _listTop = new List<GameObject>();
    public List<GameObject> _listBottom = new List<GameObject>();
    public List<GameObject> _listShoes = new List<GameObject>();

    public bool _OnTitle;
    public bool _isSet;
    public int _3master;

    public List<GameObject> _listStatSpace = new List<GameObject>();
    
    private void OnEnable()
    {

        _statePopUp.SetActive(true);
        _achivementPopUp.SetActive(false);
        _closetPopUp.SetActive(false);

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
                _player._playerTitle = Player.PlayerTitle.Dosa;
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
                else if (_player._atk >= 3 && _player._atk != 5)
                {
                    _player._atk = 3;
                    _listStatSpace[0].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[0].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._matk >= 5)
                {
                    _player._matk = 5;
                }
                else if (_player._matk >= 3 && _player._matk != 5)
                {
                    _player._matk = 3;
                    _listStatSpace[1].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[1].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._atkSpeed >= 5)
                {
                    _player._atkSpeed = 5;
                }
                else if (_player._atkSpeed >= 3 && _player._atkSpeed != 5)
                {
                    _player._atkSpeed = 3;
                    _listStatSpace[2].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[2].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._hp >= 5)
                {
                    _player._hp = 5;
                }
                else if (_player._hp >= 3 && _player._hp != 5)
                {
                    _player._hp = 3;
                    _listStatSpace[3].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[3].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._def >= 5)
                {
                    _player._def = 5;
                }
                else if (_player._def >= 3 && _player._def != 5)
                {
                    _player._def = 3;
                    _listStatSpace[4].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[4].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._speed >= 5)
                {
                    _player._speed = 5;
                }
                else if (_player._speed >= 3 && _player._speed != 5)
                {
                    _player._speed = 3;
                    _listStatSpace[5].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[5].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._critical >= 5)
                {
                    _player._critical = 5;
                }
                else if (_player._critical >= 3 && _player._critical != 5)
                {
                    _player._critical = 3;
                    _listStatSpace[6].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[6].transform.GetChild(3).gameObject.SetActive(false);
                }

                if (_player._handicraft >= 5)
                {
                    _player._handicraft = 5;
                }
                else if (_player._handicraft >= 3 && _player._handicraft != 5)
                {
                    _player._handicraft = 3;
                    _listStatSpace[7].transform.GetChild(4).gameObject.SetActive(false);
                    _listStatSpace[7].transform.GetChild(3).gameObject.SetActive(false);
                }
                if (_player._charm >= 5)
                {
                    _player._charm = 5;
                }
                else if (_player._charm >= 3 && _player._charm != 5)
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
        if (cnt == 0)
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
        else if (cnt == 1)
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
        else if (cnt == 2)
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
        else if (cnt == 3)
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
        else if (cnt == 4)
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
        else if (cnt == 5)
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
        else if (cnt == 6)
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
        else if (cnt == 7)
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
        else if (cnt == 8)
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
        else if (cnt == 9)
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
        else if (cnt == 10)
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
        else if (cnt == 11)
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
        _player.Save();
    }
    public void ChoiceHelmet(int cnt)
    {
        if (cnt == 0)
        {
            _player._isEmptyHelmet = true;
            _player._isKightHelmet = false;
            _player._isMasicianHat = false;
            _player._isGat = false;

        }
        else if (cnt == 1)
        {
            _player._isEmptyHelmet = false;
            _player._isKightHelmet = true;
            _player._isMasicianHat = false;
            _player._isGat = false;
        }
        else if (cnt == 2)
        {
            _player._isEmptyHelmet = false;
            _player._isKightHelmet = false;
            _player._isMasicianHat = true;
            _player._isGat = false;
        }
        else if (cnt == 3)
        {
            _player._isEmptyHelmet = false;
            _player._isKightHelmet = false;
            _player._isMasicianHat = false;
            _player._isGat = true;
        }
        _player.Save();
    }
    public void ChoiceHair(int cnt)
    {
        if (cnt == 0)
        {
            _player._isnormalHair = true;
            _player._isSkinHead = false;


        }
        else if (cnt == 1)
        {
            _player._isnormalHair = false;
            _player._isSkinHead = true;
        }
        _player.Save();

    }

    public void ChoiceTop(int cnt)
    {
        if(cnt == 0)
        {
            _player._isNormalTop = true;
            _player._isKnightTop = false;
            _player._isMasicianTop = false;
            _player._isDurumagiTop = false;

        }
        else if(cnt == 1)
        {
            _player._isNormalTop = false;
            _player._isKnightTop = true;
            _player._isMasicianTop = false;
            _player._isDurumagiTop = false;
        }
        else if(cnt == 2)
        {
            _player._isNormalTop = false;
            _player._isKnightTop = false;
            _player._isMasicianTop = true;
            _player._isDurumagiTop = false;
        }
        else if (cnt == 3)
        {
            _player._isNormalTop = false;
            _player._isKnightTop = false;
            _player._isMasicianTop = false;
            _player._isDurumagiTop = true;
        }
        _player.Save();
    }
    public void ChoiceBottom(int cnt)
    {
        if (cnt == 0)
        {
            _player._isTrunkBottom = true;
            _player._isKnightBottom = false;
            _player._isMasicianBottom = false;
            _player._isdurumagiBottom = false;

        }
        else if (cnt == 1)
        {
            _player._isTrunkBottom = false;
            _player._isKnightBottom = true;
            _player._isMasicianBottom = false;
            _player._isdurumagiBottom = false;
        }
        else if (cnt == 2)
        {
            _player._isTrunkBottom = false;
            _player._isKnightBottom = false;
            _player._isMasicianBottom = true;
            _player._isdurumagiBottom = false;
        }
        else if (cnt == 3)
        {
            _player._isTrunkBottom = false;
            _player._isKnightBottom = false;
            _player._isMasicianBottom = false;
            _player._isdurumagiBottom = true;
        }
        _player.Save();
    }
    public void ChoiceShoes(int cnt)
    {
        if (cnt == 0)
        {
            _player._isnormalShoes = true;
            _player._isKnightShoes = false;
            _player._isSandal = false;
            _player._isOldShoes = false;

        }
        else if (cnt == 1)
        {
            _player._isnormalShoes = false;
            _player._isKnightShoes = true;
            _player._isSandal = false;
            _player._isOldShoes = false;
        }
        else if (cnt == 2)
        {
            _player._isnormalShoes = false;
            _player._isKnightShoes = false;
            _player._isSandal = true;
            _player._isOldShoes = false;
        }
        else if (cnt == 3)
        {
            _player._isnormalShoes = false;
            _player._isKnightShoes = false;
            _player._isSandal = false;
            _player._isOldShoes = true;
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
