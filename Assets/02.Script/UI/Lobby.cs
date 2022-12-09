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
    public AchievenmentListIngame _achivementPopUp;
    public GameObject _playerTitleText;
    public GameObject _statePopUp;
    public GameObject _checkOutPopUp;
    public GameObject _alarmPopUp;
    public GameObject _settingPopUp;
    public GameObject _resetCheckPopUp;
    public TextMeshProUGUI _goldText;
    public TextMeshProUGUI _statText;
    public TextMeshProUGUI _alarmText;
    public TextMeshProUGUI _CheckOutText;
    public TextMeshProUGUI _skillDescription;
    public Text _getExpX2;
    public Slider _effectSoundSlider;
    public Slider _bgmSoundSlider;


    public List<GameObject> _listWeapon = new List<GameObject>();
    public List<GameObject> _listHelmet = new List<GameObject>();
    public List<GameObject> _listHair = new List<GameObject>();
    public List<GameObject> _listTop = new List<GameObject>();
    public List<GameObject> _listBottom = new List<GameObject>();
    public List<GameObject> _listShoes = new List<GameObject>();
    public List<GameObject> _listTopDeco = new List<GameObject>();
    public List<GameObject> _listBottomDeco = new List<GameObject>();
    public List<GameObject> _listShoesDeco = new List<GameObject>();
    public List<GameObject> _listSkin = new List<GameObject>();

    public List<GameObject> _listScreen = new List<GameObject>();

    public bool _OnTitle;
    public bool _isSet;
    public int _3master;

    public int _choiceNumber;

    public int _weaponCost;
    public int _closetCost;

    public List<GameObject> _listStatSpace = new List<GameObject>();
    
    private void Start()
    {
        for (int i = 0; i < _listStatSpace.Count; ++i)
        {
            for (int z = 0; z < _listStatSpace[i].transform.childCount; ++z)
            {
                _listStatSpace[i].transform.GetChild(z).gameObject.SetActive(false);
            }
        }
        _statePopUp.SetActive(false);
        _closetPopUp.SetActive(false);
        _checkOutPopUp.SetActive(false);
        _alarmPopUp.SetActive(false);
        _settingPopUp.SetActive(false);
        _resetCheckPopUp.SetActive(false);
        SoundManager.Instance.BGMPlay(SoundManager.Instance._lobbyBgm);
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

        _player._currentStat = _player._stat - (int)_player._atk - (int)_player._matk - (int)_player._atkSpeed - (int)_player._def - (int)_player._hp - (int)_player._charm - (int)_player._handicraft - (int)_player._critical;

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
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "마검사";
                achivementCheck(_player.getmagicalblader, "getmagicalblader");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격력 혹은 \n마력 2배증가";

            }
            else if (_player._atk == 5 && _player._matk == 5 && _player._critical == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.MadMan;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "광인";
                achivementCheck(_player.getmadman, "getmadman");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격력 마력 25% 감소 \n 치명타 피해율 100% 증가";



            }
            else if (_player._atk == 5 && _player._matk == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.StrongMan;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "괴력몬";
                
                achivementCheck(_player.getstrongman, "getstrongman");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "일정 확률로 공격시 \n추가타 발동";
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Warrior;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "전사";
               
                achivementCheck(_player.getwarrior, "getwarrior");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격력 30% 증가";
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Dwarf;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "난쟁이";
           
                achivementCheck(_player.getdwarf, "getdwarf");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "무기공격력 20% 증가";
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.JackFrost;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "동장군";
                
                achivementCheck(_player.getjackfrost, "getjackfrost");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격시 일정확률로 빙결";
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.AssaultCaptain;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "돌격대장";
               
                achivementCheck(_player.getassaultcaptain, "getassaultcaptain");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "이동속도 30% 증가";
            }
            else if (_player._atk == 5 && _player._hp == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.ZhangFei;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "장비";
               
                achivementCheck(_player.getzhangfei, "getzhangfei");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격시 일정확률로 \n기합스킬 발동";

            }
            else if (_player._atk == 5 && _player._critical == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Berserker;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "광전사";
                
                achivementCheck(_player.getberserker, "getberserker");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "일정체력미만일 때\n 공격력 100% 증가";
            }
            else if (_player._atk == 5 && _player._critical == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Critialer;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "급소킬러";
               
                achivementCheck(_player.getcriticaler, "getcriticaler");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "치명타확률 100% 고정 \n 공격력 30% 감소";
            }
            else if (_player._atk == 5 && _player._critical == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Druid;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "드루이드";
                
                achivementCheck(_player.getdruid, "getdruid");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격시 일정확률로\n 아군으로 만듬";
            }
            else if (_player._atk == 5 && _player._critical == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Assassin;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "암살자";
               
                achivementCheck(_player.getassassin,"getassassin");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "치명타 피해율 20% 증가";
            }
            else if (_player._atk == 5 && _player._atkSpeed == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Ambidextrous;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "양손잡이";
               
                achivementCheck(_player.getambidextrous, "getambidextrous");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격속도 50% 증가";

            }
            else if (_player._atk == 5 && _player._handicraft == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.LuBu;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "여포";
               
                achivementCheck(_player.getlubu, "getlubu");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격력 300%증가\n 이동속도 2단계 고정";

            }
            else if (_player._atk == 5 && _player._speed == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.HeavyCavalry;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "개마무사";
                achivementCheck(_player.getheavycavalry, "getheavycavalry");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격력 및 이동속도 20% 증가";

            }
            else if (_player._matk == 5 && _player._hp == 5 && _player._critical == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.HealthMagician;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "덩치법사";
                achivementCheck(_player.gethealthmagician, "gethealthmagician");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "체력 30%증가 \n 스킬확률 50% 고정";
            }
            else if (_player._matk == 5 && _player._hp == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Priest;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "사제";
                achivementCheck(_player.getprist, "getprist");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "스킬사용시 \n일정확률로 체력 회복";
            }
            else if (_player._matk == 5 && _player._critical == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Warlock;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "흑마법사";
                achivementCheck(_player.getwarlock, "getwarlock");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "일정체력미만일 때 \n마력 100% 증가";
            }
            else if (_player._matk == 5 && _player._critical == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Salamander;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "불도마뱀";
                achivementCheck(_player.getsalamander, "getsalamander");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "스킬사용시 일정확률로 \n운석 소환";
            }
            else if (_player._matk == 5 && _player._critical == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Zeus;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "제우스";
                achivementCheck(_player.getzeus, "getzeus");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "모든 마법을 연쇄번개로 전환 \n 번개 전이횟수 증가";
            }
            else if (_player._matk == 5 && _player._atkSpeed == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.PracticeBug;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "연습벌레";
                achivementCheck(_player.getpracticebug, "getpracticebug");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격시 100%확률로 \n스킬 발동";
            }
            else if (_player._matk == 5 && _player._charm == 5 && _player._handicraft == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Stranger;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "스트레인저";
                achivementCheck(_player.getstranger, "getstranger");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "스킬사용시 일정확률로 \n블랙홀 소환";
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
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "요리사";
                achivementCheck(_player.getcook, "getcook");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "가한피해를 \n체력으로 전환";
            }
            else if (_player._hp == 5 && _player._atkSpeed == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.QRF;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "번개조";
                achivementCheck(_player.getqrf, "getqrf");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격속도 50% \n공격력 10% 증가";
            }
            else if (_player._hp == 5 && _player._handicraft == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Servant;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "돌쇠";
                achivementCheck(_player.getservant, "getservant");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "체력 100% 증가";
            }
            
            else if (_player._hp == 5 && _player._handicraft == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Athlete;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "운동선수";
                achivementCheck(_player.getathlete, "getathlete");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "체력 30% \n이동속도 20% 증가";
            }
            else if (_player._hp == 5 && _player._handicraft == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Versatile;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "다재다능";
                achivementCheck(_player.getversatile, "getversatile");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "무기공격력 100% 증가";
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
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "침술사";
                achivementCheck(_player.getacupuncturist, "getacupuncturist");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격시 일정확률로\n 적 즉사";
            }
            else if (_player._critical == 5 && _player._speed == 5 && _player._atkSpeed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.SpoonKiller;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "숟가락살인마";
                achivementCheck(_player.getspoonkiller, "getspoonkiller");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격력 50% 감소\n 공격속도 200% 증가";
            }
            else if (_player._critical == 5 && _player._handicraft == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Helen;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "절세미인";
                achivementCheck(_player.gethelen, "gethelen");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "주변 적 일정확률로 빙결";
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
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "부자";
                achivementCheck(_player.getrich, "getrich");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "골드 획득 3배";

            }
            else if (_player._atkSpeed == 5 && _player._handicraft == 5 && _player._charm == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Swell;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "달인";
                achivementCheck(_player.getswell, "getswell");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "모든능력치 20% 증가";
            }
            else if (_player._atkSpeed == 5 && _player._handicraft == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Delivery;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "배달부";
                achivementCheck(_player.getdelivery, "getdelivery");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "이동속도 100% 증가";
            }
            else if (_player._atkSpeed == 5 && _player._handicraft == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Repairman;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "수리공";
                achivementCheck(_player.getrepairman, "getrepairman");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "체력재생능력 획득";
            }
            else if (_player._atkSpeed == 5 && _player._charm == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Dosa;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "전우치";
                achivementCheck(_player.getdosa, "getdosa");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격시 일정확률로 \n분신 소환";
            }
            else if (_player._handicraft == 5 && _player._charm == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Gambler;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "도박사";
                achivementCheck(_player.getgambler, "getgambler");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격시 50% 확률로 \n능력치 증가 혹은 감소";
            }
            else if (_player._handicraft == 5 && _player._charm == 5 && _player._def == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.SlowStarter;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "슬로우스타터";
                achivementCheck(_player.getslowstarter, "getslowstarter");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "스테이지 종료시 \n모든능력치 20% 상승";
            }
            else if (_player._handicraft == 5 && _player._def == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.Orpheus;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "오르페우스";
                achivementCheck(_player.getorpheus, "getorpheus");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "주변 적 공격력 감소";
            }
            else if (_player._charm == 5 && _player._def == 5 && _player._speed == 5)
            {
                _OnTitle = true;
                _player._playerTitle = Player.PlayerTitle.DokeV;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "도꺠비";
                achivementCheck(_player.getdokev, "getdokev");
                achivementCheck(_player.firstjob, "firstjob");
                _skillDescription.text = "공격시 일정확률로 \n적의 능력치 착취";
            }
            else
            {
                _player._playerTitle = Player.PlayerTitle.Normal;
                _playerTitleText.GetComponent<TextMeshProUGUI>().text = "백수";
                _skillDescription.text = " ";
            }
        }
        #endregion
        
        if ((_player._hp > 0 || _player._atk > 0 || _player._matk > 0 || _player._atkSpeed > 0 || _player._def > 0 || _player._speed > 0 || _player._critical > 0 || _player._handicraft > 0 || _player._charm > 0) &&
            _player.firststat == false)
        {
            achivementCheck(_player.firststat, "firststat");
            _player.firststat = true;
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
        if (_player._isbasicStick == true)
        {
            _listWeapon[0].SetActive(true);
        }
        else if (_player._isbasicStick == false)
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
        if(_player._isStick == true)
        {
            _listWeapon[12].SetActive(true);
        }
        else if(_player._isStick == false)
        {
            _listWeapon[12].SetActive(false);
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
            _listHair[1].SetActive(false);
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

        if (_player._isMasicianHat == true)
        {
            _listHelmet[2].SetActive(true);
        }
        else if (_player._isMasicianHat == false)
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
            _listTopDeco[0].SetActive(true);
            _listSkin[1].SetActive(true);
        }
        else if (_player._isKnightTop == false)
        {
            _listTop[1].SetActive(false);
            _listTopDeco[0].SetActive(false);
            _listSkin[1].SetActive(false);
        }

        if (_player._isMasicianTop == true)
        {
            _listTop[2].SetActive(true);
            _listTopDeco[1].SetActive(true);
        }
        else if (_player._isMasicianTop == false)
        {
            _listTop[2].SetActive(false);
            _listTopDeco[1].SetActive(false);
        }

        if (_player._isDurumagiTop == true)
        {
            _listTop[3].SetActive(true);
            _listTopDeco[2].SetActive(true);
            _listSkin[2].SetActive(true);
        }
        else if (_player._isDurumagiTop == false)
        {
            _listTop[3].SetActive(false);
            _listTopDeco[2].SetActive(false);
            _listSkin[2].SetActive(false);
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
            _listBottomDeco[0].SetActive(true);
        }
        else if (_player._isKnightBottom == false)
        {
            _listBottom[1].SetActive(false);
            _listBottomDeco[0].SetActive(false);
        }

        if (_player._isMasicianBottom == true)
        {
            _listBottom[2].SetActive(true);
            _listBottomDeco[1].SetActive(true);
        }
        else if (_player._isMasicianBottom == false)
        {
            _listBottom[2].SetActive(false);
            _listBottomDeco[1].SetActive(false);
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
            _listShoes[1].SetActive(true);
        }
        else if (_player._isnormalShoes == false)
        {
            _listShoes[0].SetActive(false);
            _listShoes[1].SetActive(false);
        }

        if (_player._isKnightShoes == true)
        {
            _listShoes[2].SetActive(true);
            _listShoes[3].SetActive(true);
            _listShoesDeco[0].SetActive(true);
            _listShoesDeco[1].SetActive(true);
        }
        else if (_player._isKnightShoes == false)
        {
            _listShoes[2].SetActive(false);
            _listShoes[3].SetActive(false);
            _listShoesDeco[0].SetActive(false);
            _listShoesDeco[1].SetActive(false);
        }

        if (_player._isSandal == true)
        {
            _listShoes[4].SetActive(true);
            _listShoes[5].SetActive(true);
        }
        else if (_player._isSandal == false)
        {
            _listShoes[4].SetActive(false);
            _listShoes[5].SetActive(false);
        }

        if (_player._isOldShoes == true)
        {
            _listShoes[6].SetActive(true);
            _listShoes[7].SetActive(true);
        }
        else if (_player._isOldShoes == false)
        {
            _listShoes[6].SetActive(false);
            _listShoes[7].SetActive(false);
        }
        #endregion
        #region UnpackItem
        if(Player.Instance._buybasicStick == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[0].SetActive(true);
        }
        else if(Player.Instance._buybasicStick == true && _closetPopUp.activeSelf == true)
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

        if (Player.Instance._buyStick == false && _closetPopUp.activeSelf == true)
        {
            _listScreen[30].SetActive(true);
        }
        else if (Player.Instance._buyStick == true && _closetPopUp.activeSelf == true)
        {
            _listScreen[30].SetActive(false);
        }



        #endregion


        _player._currentStat = _player._stat - (int)_player._atk - (int)_player._matk - (int)_player._atkSpeed - (int)_player._def - (int)_player._hp - (int)_player._charm - (int)_player._handicraft - (int)_player._critical;
        _goldText.text = Player.Instance._gold.ToString();
        _statText.text = Player.Instance._currentStat.ToString();

    }

    public void ATKUP()
    {
        
        if(_player._currentStat >0)
        {

            _player._atk += 1;
            if (_player._atk >= 5)
            {
                _player._atk = 5f;
            }
            for (int i = 0; i < _player._atk; ++i)
            {
                _listStatSpace[0].transform.GetChild(i).gameObject.SetActive(true);
            }

            _player._currentStat--;
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
            _player.Save();
        }
        
    }

    public void HPUP()
    {
        if (_player._currentStat > 0)
        {

            _player._hp += 1;
            if (_player._hp >= 5)
            {
                _player._hp = 5f;
            }

            for (int i = 0; i < _player._hp; ++i)
            {
                _listStatSpace[3].transform.GetChild(i).gameObject.SetActive(true);
            }
            _player._currentStat--;
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
            _player.Save();

        }
      
    }
    public void MATKUP()
    {

        if (_player._currentStat > 0)
        {
            _player._matk += 1;
            if (_player._matk >= 5)
            {
                _player._matk = 5f;
            }
            for (int i = 0; i < _player._matk; ++i)
            {
                _listStatSpace[1].transform.GetChild(i).gameObject.SetActive(true);
            }
            _player._currentStat--;
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
            _player.Save();
        }
       
    }
    public void ATKSPEEDUP()
    {
        if (_player._currentStat > 0)
        {
            _player._atkSpeed += 1;
            if (_player._atkSpeed >= 5)
            {
                _player._atkSpeed = 5f;
            }
            for (int i = 0; i < _player._atkSpeed; ++i)
            {
                _listStatSpace[2].transform.GetChild(i).gameObject.SetActive(true);
            }
            _player._currentStat--;
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
            _player.Save();
        }
      
    }
    public void DEFUP()
    {
        if (_player._currentStat > 0)
        {
            _player._def += 1;
            if (_player._def >= 5)
            {
                _player._def = 5f;
            }
            for (int i = 0; i < _player._def; ++i)
            {
                _listStatSpace[4].transform.GetChild(i).gameObject.SetActive(true);
            }
            _player._currentStat--;
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
            _player.Save();
        }
      
    }
    public void SPEEDUP()
    {
        if (_player._currentStat > 0)
        {
            _player._speed += 1;

            if (_player._speed >= 5)
            {
                _player._speed = 5f;
            }
            for (int i = 0; i < _player._speed; ++i)
            {
                _listStatSpace[5].transform.GetChild(i).gameObject.SetActive(true);
            }
            _player._currentStat--;
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
            _player.Save();
        }
    }
    public void CRITICALUP()
    {
        if (_player._currentStat > 0)
        {
            _player._critical += 1;
            if (_player._critical >= 5)
            {
                _player._critical = 5f;
            }
            for (int i = 0; i < _player._critical; ++i)
            {
                _listStatSpace[6].transform.GetChild(i).gameObject.SetActive(true);
            }
            _player._currentStat--;
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
            _player.Save();
        }
    }
    public void HANDICRAFTUP()
    {
        if (_player._currentStat > 0)
        {
            _player._handicraft += 1;
            if (_player._handicraft >= 5)
            {
                _player._handicraft = 5f;
            }
            for (int i = 0; i < _player._handicraft; ++i)
            {
                _listStatSpace[7].transform.GetChild(i).gameObject.SetActive(true);
            }
            _player._currentStat--;
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
            _player.Save();
        }
    }
    public void CHARMUP()
    {
        if (_player._currentStat > 0)
        {
            _player._charm += 1;
            if (_player._charm >= 5)
            {
                _player._charm = 5f;
            }
            for (int i = 0; i < _player._charm; ++i)
            {
                _listStatSpace[8].transform.GetChild(i).gameObject.SetActive(true);
            }
            _player._currentStat--;
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
            _player.Save();
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
        Player.Instance._ingameHp = 50 + (Player.Instance._hp * 10);
        Player.Instance._maxHp = 50 + (Player.Instance._hp * 10);
        for (int i = 0; i <_listStatSpace.Count; ++i)
        {
            for(int j= 0; j < _listStatSpace[i].transform.childCount; ++j)
            {
                _listStatSpace[i].transform.GetChild(j).gameObject.SetActive(false);
            }
        }
        _player._playerTitle = Player.PlayerTitle.Normal;
        _playerTitleText.GetComponent<TextMeshProUGUI>().text = _player._playerTitle.ToString();
        _OnTitle = false;
        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
    }

    public void EnterClosetPopUP()
    {
        _closetPopUp.SetActive(true);
        _statePopUp.SetActive(false);
        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop2);
    }
    public void ExitClosetPopUP()
    {
        _closetPopUp.SetActive(false);
        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
    }
    public void EnterAchivementPopUp()
    {
        AchievenmentListIngame.instance.ToggleWindow();

        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop2);
    }
    public void ExitAchivemntPopUp()
    {
        AchievenmentListIngame.instance.ToggleWindow();
        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
    }
    public void EnterSettingPopUp()
    {
        _settingPopUp.SetActive(true);
        _effectSoundSlider.value = Player.Instance._effectSound;
        _bgmSoundSlider.value = Player.Instance._bgmSound;
        if(Player.Instance._expX2 == false)
        {
            _getExpX2.text = " ₩ 1,000";
        }
        else if(Player.Instance._expX2 == true)
        {
            _getExpX2.text = "활성화";
        }
        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop2);
    }
    public void ExitSettingPopUp()
    {
        _settingPopUp.SetActive(false);
        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
    }

    public void ChoiceWeapon(int cnt)
    {
        _choiceNumber = cnt;
        if (cnt == 0 && _listScreen[0].activeSelf == false)
        {
            _player._isbasicStick = true;
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
            _player._isStick = false;

        }
        else if(cnt == 0 && _listScreen[0].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _weaponCost.ToString() + "\n 구매하시겠습니까?"; 
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        }
        else if (cnt == 1&& _listScreen[1].activeSelf == false)
        {
            _player._isbasicStick = false;
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
            _player._isStick = false;
        }
        else if (cnt == 1 && _listScreen[1].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _weaponCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        }
        else if (cnt == 2 && _listScreen[2].activeSelf == false)
        {
            _player._isbasicStick = false;
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
            _player._isStick = false;
        }
        else if (cnt == 2 && _listScreen[2].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _weaponCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        }
        else if (cnt == 3 && _listScreen[3].activeSelf == false)
        {
            _player._isbasicStick = false;
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
            _player._isStick = false;
        }
        else if (cnt == 3 && _listScreen[3].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _weaponCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        }
        else if (cnt == 4 && _listScreen[4].activeSelf == false)
        {
            _player._isbasicStick = false;
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
            _player._isStick = false;
        }
        else if (cnt == 4 && _listScreen[4].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _weaponCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        }
        else if (cnt == 5 && _listScreen[5].activeSelf == false)
        {
            _player._isbasicStick = false;
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
            _player._isStick = false;
        }
        else if (cnt == 5 && _listScreen[5].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _weaponCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        }
        else if (cnt == 6 && _listScreen[6].activeSelf == false)
        {
            _player._isbasicStick = false;
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
            _player._isStick = false;
        }
        else if (cnt == 6 && _listScreen[6].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _weaponCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        }
        else if (cnt == 7 && _listScreen[7].activeSelf == false)
        {
            _player._isbasicStick = false;
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
            _player._isStick = false;
        }
        else if (cnt == 7 && _listScreen[7].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _weaponCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        }
        else if (cnt == 8 && _listScreen[8].activeSelf == false)
        {
            _player._isbasicStick = false;
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
            _player._isStick = false;
        }
        else if (cnt == 8 && _listScreen[8].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _weaponCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        }
        else if (cnt == 9 && _listScreen[9].activeSelf == false)
        {
            _player._isbasicStick = false;
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
            _player._isStick = false;
        }
        else if (cnt == 9 && _listScreen[9].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _weaponCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        }
        else if (cnt == 10 && _listScreen[10].activeSelf == false)
        {
            _player._isbasicStick = false;
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
            _player._isStick = false;
        }
        else if (cnt == 10 && _listScreen[10].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _weaponCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        }
        else if (cnt == 11 && _listScreen[11].activeSelf == false)
        {
            _player._isbasicStick = false;
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
            _player._isStick = false;
        }
        else if (cnt == 11 && _listScreen[11].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _weaponCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        }
        else if (cnt == 30 && _listScreen[30].activeSelf == false)
        {
            _player._isbasicStick = false;
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
            _player._isStick = true;
        }
        else if (cnt == 30 && _listScreen[30].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _weaponCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        }
        else if (cnt == 15 && _listScreen[17].activeSelf == false)
        {
            _player._isnormalHair = false;
            _player._isSkinHead = true;
        }
        else if(cnt == 15 && _listScreen[17].activeSelf == true)
        {
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();

            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
            _CheckOutText.text = "필요 골드 : " + _closetCost.ToString() + "\n 구매하시겠습니까?";
            EnterCheckOutPopUp();
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
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
        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
    }
    public void ExitCheckOutPopUp()
    {
        _checkOutPopUp.SetActive(false);

        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
    }
    public void CheckOutPopUpYes()
    {
        if(_player._gold >= _weaponCost)
        {

            if (_choiceNumber == 0)
            {
                Player.Instance._buybasicStick = true;
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
            else if (_choiceNumber == 30)
            {
                Player.Instance._buybasicStick = true;
            }

            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
            Player.Instance._gold -= _weaponCost;
        }
        else if(_player._gold <_weaponCost)
        {
            _alarmText.text = "골드가 부족합니다. \n 필요골드 : " + _weaponCost;

            SoundManager.Instance.EffectPlay(SoundManager.Instance._decline);
            EnterAlarmPopUp();
        }

        if(_player._gold >= _closetCost)
        {
            if (_choiceNumber == 12)
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

            Player.Instance._gold -= _closetCost;
            SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);

        }
        else if (_player._gold < _closetCost)
        {
            _alarmText.text = "골드가 부족합니다. \n 필요골드 : " + _closetCost;

            SoundManager.Instance.EffectPlay(SoundManager.Instance._decline);
            EnterAlarmPopUp();
        }
        _player.Save();
        ExitCheckOutPopUp();

    }
    public void CheckOutPopUpNo()
    {
        ExitCheckOutPopUp();

        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
    }
    public void EnterAlarmPopUp()
    {
        _alarmPopUp.SetActive(true);

        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
    }
    public void ExitAlarmPopUp()
    {
        _alarmPopUp.SetActive(false);

        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
    }
    public void EnterStatePopUp()
    {
        _statePopUp.SetActive(true);
        _closetPopUp.SetActive(false);

        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop2);
    }
    public void ExitStatePopUp()
    {
        _statePopUp.SetActive(false);

        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);

    }
    public void EnterResetCheckPopUp()
    {
        _resetCheckPopUp.SetActive(true);

        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
    }
    public void ExitResetCheckPopUp()
    {
        _resetCheckPopUp.SetActive(false);

        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
    }
    public void achivementCheck(bool check,string str)
    {
        if (check == false)
        {
            AchievementManager.instance.Unlock(str);
        }
    }
    public void PlusStat()
    {
        if(_player._gold >= 300 && _player._stat < 37)
        {
            _player._stat++;
            _player._gold -= 300;

        }
        else if (_player._gold <300)
        {
            _alarmText.text = "골드가 부족합니다. \n 필요골드 : " + 300;
            EnterAlarmPopUp();

            SoundManager.Instance.EffectPlay(SoundManager.Instance._decline);
        }
        else if(_player._stat >= 37)
        {
            _alarmText.text = "능력치 보유한도에 도달하였습니다.";
            EnterAlarmPopUp();

            SoundManager.Instance.EffectPlay(SoundManager.Instance._decline);
        }

    }
    public void StartGame()
    {
        LoadSceneManager.LoadScene("GamePlay");

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void AllReSet()
    {
        StatReset();
        AchievementManager.instance.ResetAchievementState();

        Player.Instance.firststat = false;
        Player.Instance.firstmaster = false;
        Player.Instance.firstjob = false;
        Player.Instance.earlydie = false;
        Player.Instance.nonviolent = false;
        Player.Instance.firstmagic = false;
        Player.Instance.firsthunt = false;
        Player.Instance.getmagicalblader = false;
        Player.Instance.magicalbladerhidden = false;
        Player.Instance.getmadman = false;
        Player.Instance.madmanmadness = false;
        Player.Instance.getstrongman = false;
        Player.Instance.strongmanhidden = false;
        Player.Instance.strongmanskill1full = false;
        Player.Instance.getwarrior = false;
        Player.Instance.warriorskill1full = false;
        Player.Instance.getdwarf = false;
        Player.Instance.dwarfskill1full = false;
        Player.Instance.getjackfrost = false;
        Player.Instance.jackfrosthidden = false;
        Player.Instance.jackfrosttuna = false;
        Player.Instance.getassaultcaptain = false;
        Player.Instance.assaultcaptainfull = false;
        Player.Instance.getzhangfei = false;
        Player.Instance.zhangfeiroar = false;
        Player.Instance.zhangfeirowhp = false;
        Player.Instance.zhangfeihidden = false;
        Player.Instance.getberserker = false;
        Player.Instance.berserkerskill1full = false;
        Player.Instance.berserkerhidden = false;
        Player.Instance.berserkerclear = false;
        Player.Instance.getcriticaler = false;
        Player.Instance.criticalerskill1full = false;
        Player.Instance.getdruid = false;
        Player.Instance.druidfirstskill = false;
        Player.Instance.druidskill100 = false;
        Player.Instance.getassassin = false;
        Player.Instance.assassinskill2full = false;
        Player.Instance.getambidextrous = false;
        Player.Instance.getlubu = false;
        Player.Instance.lubuhidden = false;
        Player.Instance.lubuskill1full = false;
        Player.Instance.getheavycavalry = false;
        Player.Instance.gethealthmagician = false;
        Player.Instance.healthmagicianskill2full = false;
        Player.Instance.healthmagicianhidden = false;
        Player.Instance.getprist = false;
        Player.Instance.pristhpfull = false;
        Player.Instance.pristjesus = false;
        Player.Instance.pristhidden = false;
        Player.Instance.getwarlock = false;
        Player.Instance.warlockskill1full = false;
        Player.Instance.warlockclear = false;
        Player.Instance.warlcokhidden = false;
        Player.Instance.getsalamander = false;
        Player.Instance.salamandermeteor = false;
        Player.Instance.salamandermeteor3 = false;
        Player.Instance.salamanderhidden = false;
        Player.Instance.getcook = false;
        Player.Instance.cookfullhp = false;
        Player.Instance.cookhidden = false; 
        Player.Instance.getzeus = false;
        Player.Instance.zeusskill1first = false;
        Player.Instance.zeushidden = false;
        Player.Instance.getpracticebug = false;
        Player.Instance.practicebugskill1full = false;
        Player.Instance.practicebugskill2full = false;
        Player.Instance.getstranger = false;
        Player.Instance.strangerfirstskill = false;
        Player.Instance.stangerskill100 = false;
        Player.Instance.getqrf = false;
        Player.Instance.qrfputhanger = false;
        Player.Instance.qrfhidden = false;
        Player.Instance.getservant = false;
        Player.Instance.servantskill1first = false;
        Player.Instance.servanthidden = false;
        Player.Instance.getathlete = false;
        Player.Instance.ahleteskill2full = false;
        Player.Instance.ahleteclear = false;
        Player.Instance.getversatile = false;
        Player.Instance.versatilehidden = false;
        Player.Instance.getacupuncturist = false;
        Player.Instance.acupuncturistfirstskill = false;
        Player.Instance.acupuncturistcritical = false;
        Player.Instance.acupuncturistskill2full = false;
        Player.Instance.acupuncturistclear = false;
        Player.Instance.getspoonkiller = false;
        Player.Instance.spoonkillerskill1full = false;
        Player.Instance.spoonkillerskill2full = false;
        Player.Instance.spoonkillerclear = false;
        Player.Instance.gethelen = false;
        Player.Instance.helenskill100 = false;
        Player.Instance.helenhidden = false;
        Player.Instance.helenstage1die = false;
        Player.Instance.helenclear = false;
        Player.Instance.getrich = false;
        Player.Instance.richget1000gold = false;
        Player.Instance.getswell = false;
        Player.Instance.swellskill1full = false;
        Player.Instance.swellclear = false;
        Player.Instance.getdelivery = false;
        Player.Instance.deliveryskill1full = false;
        Player.Instance.deliveryclear = false;
        Player.Instance.getrepairman = false;
        Player.Instance.repairmanhidden = false;
        Player.Instance.repairmanclear = false;
        Player.Instance.getdosa = false;
        Player.Instance.dosafirstskill = false;
        Player.Instance.dosaskilldie20 = false;
        Player.Instance.dosahidden  = false;
        Player.Instance.getgambler = false;
        Player.Instance.gamblerlose = false;
        Player.Instance.gamblerwin = false;
        Player.Instance.gamblerskill2 = false;
        Player.Instance.getslowstarter = false;
        Player.Instance.slowstarterclear = false;
        Player.Instance.getorpheus = false;
        Player.Instance.orpheusskill1full = false;
        Player.Instance.orpheusfirstdie = false;
        Player.Instance.getdokev = false;
        Player.Instance.dokevfirstskill = false;
        Player.Instance.dokevhidden = false;
        Player.Instance.dokevhidden50 = false;
        Player.Instance.statlv5 = false;
        Player.Instance.stage1clear = false;
        Player.Instance.stage2clear = false;
        Player.Instance._isbasicStick = true;
        Player.Instance._isStick = false;
        Player.Instance._isSward1 = false;
        Player.Instance._isSward2 = false;
        Player.Instance._isBroom = false;
        Player.Instance._isClub = false;
        Player.Instance._isShortSward = false;
        Player.Instance._isHanger = false;
        Player.Instance._isMace = false;
        Player.Instance._isShield = false;
        Player.Instance._isSpear = false;
        Player.Instance._isUmbrella = false;
        Player.Instance._isWaldo = false;
        Player.Instance._buybasicStick = true;
        Player.Instance._buyStick = false;
        Player.Instance._buySward1 = false;
        Player.Instance._buySward2 = false;
        Player.Instance._buyBroom = false;
        Player.Instance._buyClub = false;
        Player.Instance._buyShortSward = false;
        Player.Instance._buyHanger = false;
        Player.Instance._buyMace = false;
        Player.Instance._buyShield = false;
        Player.Instance._buySpear = false;
        Player.Instance._buyUmbrella = false;
        Player.Instance._buyWaldo = false;
        Player.Instance._isKightHelmet = false;
        Player.Instance._isMasicianHat = false;
        Player.Instance._isGat = false;
        Player.Instance._isEmptyHelmet = true;
        Player.Instance._buyKightHelmet = false;
        Player.Instance._buyMasicianHat = false;
        Player.Instance._buyGat = false;
        Player.Instance._buyEmptyHelmet = true;
        Player.Instance._isSkinHead = false;
        Player.Instance._isnormalHair = true;
        Player.Instance._buySkinHead = false;
        Player.Instance._buynormalHair =  true;
        Player.Instance._isKnightTop = false;
        Player.Instance._isMasicianTop = false;
        Player.Instance._isDurumagiTop = false;
        Player.Instance._isNormalTop = true;
        Player.Instance._buyKnightTop = false;
        Player.Instance._buyMasicianTop = false;
        Player.Instance._buyDurumagiTop = false;
        Player.Instance._buyNormalTop = true;
        Player.Instance._isKnightBottom = false;
        Player.Instance._isMasicianBottom = false;
        Player.Instance._isdurumagiBottom = false;
        Player.Instance._isTrunkBottom = true;
        Player.Instance._buyKnightBottom = false;
        Player.Instance._buyMasicianBottom = false;
        Player.Instance._buydurumagiBottom = false;
        Player.Instance._buyTrunkBottom = true;
        Player.Instance._isKnightShoes = false;
        Player.Instance._isSandal = false;
        Player.Instance._isOldShoes = false;
        Player.Instance._isnormalShoes = true;
        Player.Instance._buyKnightShoes = false;
        Player.Instance._buySandal = false;
        Player.Instance._buyOldShoes = false;
        Player.Instance._buynormalShoes = true;
        Player.Instance._totalCreepScore = 0;
        Player.Instance._jackfrostScore=0;
        Player.Instance._druidScore = 0;
        Player.Instance._strangerblackholeScore = 0;
        Player.Instance._helenScore = 0;
        Player.Instance._dosaDieAvatar = 0;
        Player.Instance._dokevHiddenSkillScore = 0;
        Player.Instance._gold = 0;
        Player.Instance._stat = 0;


        SoundManager.Instance.EffectPlay(SoundManager.Instance._debuff);
        Player.Instance.Save();
    }

   


}
