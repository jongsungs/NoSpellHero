using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System;

public enum EquipmentWeapon : int
{
    Stick = 0,
    Sward1,
    Sward2,
    Broom,
    Club,
    ShortSward,
    Hanger,
    Mace,
    Shield,
    Spear,
    Umbrella,
    Waldo,


}
public enum Hair : int
{
    NormalHair = 0,
    SkinHead,
}
public enum Helmet : int
{
    Empty = 0,
    KnightHelmet,
    MasicianHat,
    Gat,
}
public enum Top : int
{
    Normal = 0,
    KnightTop,
    MasicianTop,
    Durumagi,
}
public enum Bottom : int
{
    Trunk = 0,
    KnightBottom,
    MasicianBottom,
    DurumagiBottom,
}
public enum Shoes : int
{
    Normal = 0,
    KnightShoes,
    Sandal,
    OldShoes,
}


#region PlayerData
public class PlayerData
{
    public float m_hp;
    public float m_atk;
    public float m_matk;
    public float m_atkSpeed;
    public float m_def;
    public float m_speed;
    public float m_critical;
    public float m_handicraft;
    public float m_charm;
    public float m_criticalDamage;

    public bool m_isStick;
    public bool m_isSward1;
    public bool m_isSward2;
    public bool m_isBroom;
    public bool m_isClub;
    public bool m_isShortSward;
    public bool m_isHanger;
    public bool m_isMace;
    public bool m_isShield;
    public bool m_isSpear;
    public bool m_isUmbrella;
    public bool m_isWaldo;

    public bool m_isKightHelmet;
    public bool m_isMasicianHat;
    public bool m_isGat;
    public bool m_isSkinHead;
    public bool m_isnormalHair;
    public bool m_isKnightTop;
    public bool m_isMasicianTop;
    public bool m_isDurumagiTop;
    public bool m_isKnightBottom;
    public bool m_isMasicianBottom;
    public bool m_isdurumagiBottom;
    public bool m_isKnightShoes;
    public bool m_isSandal;
    public bool m_isOldShoes;
    

    public bool m_isEmptyHelmet;
    public bool m_isNormalTop;
    public bool m_isTrunkBottom;
    public bool m_isnormalShoes;


    public bool m_buyStick;
    public bool m_buySward1;
    public bool m_buySward2;
    public bool m_buyBroom;
    public bool m_buyClub;
    public bool m_buyShortSward;
    public bool m_buyHanger;
    public bool m_buyMace;
    public bool m_buyShield;
    public bool m_buySpear;
    public bool m_buyUmbrella;
    public bool m_buyWaldo;
                  
    public bool m_buyKightHelmet;
    public bool m_buyMasicianHat;
    public bool m_buyGat;
    public bool m_buySkinHead;
    public bool m_buynormalHair;
    public bool m_buyKnightTop;
    public bool m_buyMasicianTop;
    public bool m_buyDurumagiTop;
    public bool m_buyKnightBottom;
    public bool m_buyMasicianBottom;
    public bool m_buydurumagiBottom;
    public bool m_buyKnightShoes;
    public bool m_buySandal;
    public bool m_buyOldShoes;
                  
                  
    public bool m_buyEmptyHelmet;
    public bool m_buyNormalTop;
    public bool m_buyTrunkBottom;
    public bool m_buynormalShoes;

    //업적
    public bool m_firststat;
    public bool m_firstmaster;
    public bool m_firstjob;
    public bool m_earlydie;
    public bool m_nonviolent;
    public bool m_firstmagic;
    public bool m_firsthunt;
    public bool m_getmagicalblader;
    public bool m_magicalbladerhidden;
    public bool m_getmadman;
    public bool m_madmanmadness;
    public bool m_getstrongman;
    public bool m_strongmanhidden;
    public bool m_strongmanskill1full;
    public bool m_getwarrior;
    public bool m_warriorskill1full;
    public bool m_getdwarf;
    public bool m_dwarfskill1full;
    public bool m_getjackfrost;
    public bool m_jackfrosthidden;
    public bool m_jackfrosttuna;
    public bool m_getassaultcaptain;
    public bool m_assaultcaptainfull;
    public bool m_getzhangfei;
    public bool m_zhangfeiroar;
    public bool m_zhangfeirowhp;
    public bool m_zhangfeihidden;
    public bool m_getberserker;
    public bool m_berserkerskill1full;
    public bool m_berserkerhidden;
    public bool m_berserkerclear;
    public bool m_getcriticaler;
    public bool m_criticalerskill1full;
    public bool m_getdruid;
    public bool m_druidfirstskill;
    public bool m_druidskill100;
    public bool m_getassassin;
    public bool m_assassinskill2full;
    public bool m_getambidextrous;
    public bool m_getlubu;
    public bool m_lubuhidden;
    public bool m_lubuskill1full;
    public bool m_getheavycavalry;
    public bool m_gethealthmagician;
    public bool m_healthmagicianskill2full;
    public bool m_healthmagicianhidden;
    public bool m_getprist;
    public bool m_pristhpfull;
    public bool m_pristjesus;
    public bool m_pristhidden;
    public bool m_getwarlock;
    public bool m_warlockskill1full;
    public bool m_warlockclear;
    public bool m_warlcokhidden;
    public bool m_getsalamander;
    public bool m_salamandermeteor;
    public bool m_salamandermeteor3;
    public bool m_salamanderhidden;
    public bool m_getcook;
    public bool m_cookfullhp;
    public bool m_cookhidden;
    public bool m_getzeus;
    public bool m_zeusskill1first;
    public bool m_zeushidden;
    public bool m_getpracticebug;
    public bool m_practicebugskill1full;
    public bool m_practicebugskill2full;
    public bool m_getstranger;
    public bool m_strangerfirstskill;
    public bool m_stangerskill100;
    public bool m_getqrf;
    public bool m_qrfputhanger;
    public bool m_qrfhidden;
    public bool m_getservant;
    public bool m_servantskill1first;
    public bool m_servanthidden;
    public bool m_getathlete;
    public bool m_ahleteskill2full;
    public bool m_ahleteclear;
    public bool m_getversatile;
    public bool m_versatilehidden;
    public bool m_getacupuncturist;
    public bool m_acupuncturistfirstskill;
    public bool m_acupuncturistcritical;
    public bool m_acupuncturistskill2full;
    public bool m_acupuncturistclear;
    public bool m_getspoonkiller;
    public bool m_spoonkillerskill1full;
    public bool m_spoonkillerskill2full;
    public bool m_spoonkillerclear;
    public bool m_gethelen;
    public bool m_helenskill100;
    public bool m_helenhidden;
    public bool m_helenstage1die;
    public bool m_helenclear;
    public bool m_getrich;
    public bool m_richget1000gold;
    public bool m_getswell;
    public bool m_swellskill1full;
    public bool m_swellclear;
    public bool m_getdelivery;
    public bool m_deliveryskill1full;
    public bool m_deliveryclear;
    public bool m_getrepairman;
    public bool m_repairmanhidden;
    public bool m_repairmanclear;
    public bool m_repairmanfullhp;
    public bool m_getdosa;
    public bool m_dosafirstskill;
    public bool m_dosaskilldie20;
    public bool m_dosahidden;
    public bool m_getgambler;
    public bool m_gamblerlose;
    public bool m_gamblerwin;
    public bool m_gamblerskill2;
    public bool m_getslowstarter;
    public bool m_slowstarterclear;
    public bool m_getorpheus;
    public bool m_orpheusskill1full;
    public bool m_orpheusfirstdie;
    public bool m_getdokev;
    public bool m_dokevfirstskill;
    public bool m_dokevhidden;
    public bool m_dokevhidden50;
    public bool m_statlv5;
    public bool m_stage1clear;
    public bool m_stage2clear;

    public PlayerData(float hp, float atk, float matk, float atkspeed, float def, float speed, float critical, float handicraft, float charm,float criticalDamage,bool kighthelmet,bool masicianhat, bool gat, bool skinhead, bool normalhair,
        bool knighttop,bool masiciantop,bool durumagitop, bool knightbottom,bool masicianbottom,bool durumagibottom,bool knightshoes,bool sandal, bool oldshoes,bool emptyhelmet,bool normaltop,bool trunkbottom,bool normalshoes,
        bool stick,bool sward1,bool sward2,bool broom,bool club, bool shortsward,bool hanger,bool mace,bool shield,bool spear,bool umbrella, bool waldo,
        bool buystick, bool buysward1, bool buysward2, bool buybroom, bool buyclub, bool buyshortsward, bool buyhanger, bool buymace, bool buyshield, bool buyspear, bool buyumbrella, bool buywaldo,
        bool buyknighthelmet, bool buymasicianhat, bool buygat, bool buyskinhead, bool buynormalhair, bool buyknighttop, bool buymasiciantop, bool buydurumagitop, bool buyknightbottom, bool buymasicianbottom, bool buydurumagibottom, bool buyknightshoes, bool buysandal, bool buyoldshoes, bool buyemptyhelmet,bool buynormaltop,bool buytrunkbottom,bool buynormalshoes)
    {
        m_hp = hp;
        m_atk = atk;
        m_matk = matk;
        m_atkSpeed = atkspeed;
        m_def = def;
        m_speed = speed;
        m_critical = critical;
        m_handicraft = handicraft;
        m_charm = charm;
        m_criticalDamage = criticalDamage;

        m_isStick = stick;
        m_isSward1 = sward1;
        m_isSward2 = sward2;
        m_isBroom = broom;
        m_isClub = club;
        m_isShortSward = shortsward;
        m_isHanger = hanger;
        m_isMace = mace;
        m_isShield = shield;
        m_isSpear = spear;
        m_isUmbrella = umbrella;
        m_isWaldo = waldo;

        m_isKightHelmet = kighthelmet;
        m_isMasicianHat = masicianhat;
        m_isGat = gat;
        m_isSkinHead = skinhead;
        m_isnormalHair = normalhair;
        m_isKnightTop = knighttop;
        m_isMasicianTop = masiciantop;
        m_isDurumagiTop = durumagitop;
        m_isKnightBottom = durumagibottom;
        m_isMasicianBottom = masicianbottom;
        m_isdurumagiBottom = durumagibottom;
        m_isKnightShoes = knightshoes;
        m_isSandal = sandal;
        m_isOldShoes = oldshoes;

        m_isEmptyHelmet = emptyhelmet;
        m_isNormalTop = normaltop;
        m_isTrunkBottom = trunkbottom;
        m_isnormalShoes = normalshoes;

        m_buyStick = buystick;
        m_buySward1 = buysward1;
        m_buySward2 = buysward2;
        m_buyBroom = buybroom;
        m_buyClub = buyclub;
        m_buyShortSward = buyshortsward;
        m_buyHanger = buyhanger;
        m_buyMace = buymace;
        m_buyShield = buyshield;
        m_buySpear = buyspear;
        m_buyUmbrella = buyumbrella;
        m_buyWaldo = buywaldo;

        m_buyKightHelmet = buyknighthelmet;
        m_buyMasicianHat = buymasicianhat;
        m_buyGat = buygat;
        m_buySkinHead = buyskinhead;
        m_buynormalHair = buynormalhair;
        m_buyKnightTop = buyknighttop;
        m_buyMasicianTop = buymasiciantop;
        m_buyDurumagiTop = buydurumagitop;
        m_buyKnightBottom = buyknightbottom;
        m_buyMasicianBottom = buymasicianbottom;
        m_buydurumagiBottom = buydurumagibottom;
        m_buyKnightShoes = buyknightshoes;
        m_buySandal = buysandal;
        m_buyOldShoes = buyoldshoes;


        m_buyEmptyHelmet = buyemptyhelmet;
        m_buyNormalTop = buynormaltop;
        m_buyTrunkBottom = buytrunkbottom;
        m_buynormalShoes = buynormalshoes;



    }
}
#endregion
public class Player : BaseObject
{

    static public Player Instance { get; private set; }

    public enum PlayerTitle : int
    {
        Normal = 0,
        MagicalBlader, // 마검사
        MadMan, //광인
        StrongMan, //괴력몬 
        Warrior, //전사
        Dwarf, //난쟁이
        JackFrost, // 동장군
        AssaultCaptain,//돌격대장
        ZhangFei,//삼국지 장비
        Berserker, // 광전사
        Critialer,//급소킬러
        Druid, //드루이드
        Assassin,//암살자
        Ambidextrous,//양손잡이
        LuBu,//여포
        HeavyCavalry, //개마무사
        HealthMagician,//덩치법사
        Priest, // 사제
        Warlock, // 흑마법사
        Salamander, // 불도마뱀
        Zeus,//제우스
        PracticeBug,//연습벌레
        Stranger,//스트레인저
        GateKeeper,//문지기
        Cook,//요리사
        QRF,//번개조
        Servant, //돌쇠
        Athlete, //운동선수
        Versatile,//다재다능
        Shieldbearer,//방패병
        Acupuncturist,//침술사
        SpoonKiller,//숟가락 살인마
        Helen,//절세미인
        Slicker,//야바위꾼
        Rich,//부자
        Swell, //달인
        Delivery,//배달부
        Repairman,//수리공
        Dosa,//전우치
        Gambler,//도박사
        SlowStarter,//슬로우스타터
        Orpheus,//오르페우스
        DokeV,//도깨비



    }

    [SerializeField] float _preSpeed;
    [SerializeField] float _rotateSpeed;
    //---------------------------------
    //체인라이트닝을 위한 곳
    [SerializeField] float m_viewDistance; //시야거리
    [SerializeField] LayerMask m_targetMask;  //Enemy 레이어마스크 지정을 위한 변수

    public List<Monster> _listMonster = new List<Monster>();
    public List<Monster> _listMonster2 = new List<Monster>();
    public List<Monster> _listBlizzardMonster = new List<Monster>();
    public List<GameObject> _listLightning = new List<GameObject>();

    public GameObject _lightning;
    public GameObject _meteorPoint;
    public int _jumpStack;
    public int _basicJumpStack;

    public Transform m_transform;
    public int _count;

    public GameObject _roar;

    //-----------------------------
    public VariableJoystick variableJoystick;
    public FollowCamera2 _followCamera;
    
    PlayerData _data;
    public List<Weapon> _listWeapon = new List<Weapon>();
    public Weapon _weapon;

    
    public bool _isIdle = true;
    public PlayerTitle _playerTitle = PlayerTitle.StrongMan;
    public List<float> _listState = new List<float>();
  
    public bool _isWalk;


    public int _skill1;
    public int _skill2;
    public int _skill3;

    public int _totalCreepScore;
    public int _jackfrostScore;
    public int _druidScore;
    public int _strangerblackholeScore;
    public int _helenScore;
    public int _getGold;
    public int _dosaDieAvatar;
    public int _dokevHiddenSkillScore;
    public int _spellScore;

    public List<GameObject> _listMeteorPoint = new List<GameObject>();
    public List<Animator> _listAnimator = new List<Animator>();
    public List<Rigidbody> _listRigidBody = new List<Rigidbody>();

    
    #region Cloth
    //////옷----------------------------------------

    //무기
    public GameObject _stick;   //막대기
    public GameObject _sward1;   //한손검
    public GameObject _sward2;  //한손검2
    public GameObject _broom;   //빗자루
    public GameObject _club;    //나무몽둥이
    public GameObject _shortSward;  //단도
    public GameObject _hanger;  //옷걸이
    public GameObject _mace;    //메이스
    public GameObject _shield;  //방패
    public GameObject _spear;   //창
    public GameObject _umbrella;    //우산
    public GameObject _waldo;   //월도

    public bool _isStick;
    public bool _isSward1;
    public bool _isSward2;
    public bool _isBroom;
    public bool _isClub;
    public bool _isShortSward;
    public bool _isHanger;
    public bool _isMace;
    public bool _isShield;
    public bool _isSpear;
    public bool _isUmbrella;
    public bool _isWaldo;

    public bool _buyStick;
    public bool _buySward1;
    public bool _buySward2;
    public bool _buyBroom;
    public bool _buyClub;
    public bool _buyShortSward;
    public bool _buyHanger;
    public bool _buyMace;
    public bool _buyShield;
    public bool _buySpear;
    public bool _buyUmbrella;
    public bool _buyWaldo;

    
    //투구
    public GameObject _knightHelmet;    //기사 투구
    public GameObject _masicianHat;     //마법사모자
    public GameObject _gat; //갓
    public GameObject _emptyHelmet;

    public bool _isKightHelmet;
    public bool _isMasicianHat;
    public bool _isGat;
    public bool _isEmptyHelmet;

    public bool _buyKightHelmet;
    public bool _buyMasicianHat;
    public bool _buyGat;
    public bool _buyEmptyHelmet;

    //머리
    public GameObject _skinHead;//민머리
    public GameObject _normalHair;

    public bool _isSkinHead;
    public bool _isnormalHair;

    public bool _buySkinHead;
    public bool _buynormalHair;

    //상의
    public GameObject _knightTop;   //기사 상의
    public GameObject _masicianTop; //마법사 상의
    public GameObject _durumagiTop; //두루마기
    public GameObject _normalTop; // 나시티

    public bool _isKnightTop;
    public bool _isMasicianTop;
    public bool _isDurumagiTop;
    public bool _isNormalTop;

    public bool _buyKnightTop;
    public bool _buyMasicianTop;
    public bool _buyDurumagiTop;
    public bool _buyNormalTop;

    //하의
    public GameObject _knightBottom;    //기사 하의
    public GameObject _masicianBottom;  //마법사 하의
    public GameObject _durumagiBottom;  //두루마기 하의
    public GameObject _trunkBottom; // 반바지

    public bool _isKnightBottom;
    public bool _isMasicianBottom;
    public bool _isdurumagiBottom;
    public bool _isTrunkBottom;

    public bool _buyKnightBottom;
    public bool _buyMasicianBottom;
    public bool _buydurumagiBottom;
    public bool _buyTrunkBottom;

    //신발
    public GameObject _knightShoes; //기사 신발
    public GameObject _sandal;  //샌달
    public GameObject _oldShoes;    //옛날 신발
    public GameObject _normalShoes;// 맨발

    public bool _isKnightShoes;
    public bool _isSandal;
    public bool _isOldShoes;
    public bool _isnormalShoes;

    public bool _buyKnightShoes;
    public bool _buySandal;
    public bool _buyOldShoes;
    public bool _buynormalShoes;

    #endregion

    #region achivement
    /////
    ////----------업적-------------------
    public bool firststat;
    public bool firstmaster;
    public bool firstjob;
    public bool earlydie;
    public bool nonviolent;
    public bool firstmagic;
    public bool firsthunt;
    public bool getmagicalblader;
    public bool magicalbladerhidden;
    public bool getmadman;
    public bool madmanmadness;
    public bool getstrongman;
    public bool strongmanhidden;
    public bool strongmanskill1full;
    public bool getwarrior;
    public bool warriorskill1full;
    public bool getdwarf;
    public bool dwarfskill1full;
    public bool getjackfrost;
    public bool jackfrosthidden;
    public bool jackfrosttuna;
    public bool getassaultcaptain;
    public bool assaultcaptainfull;
    public bool getzhangfei;
    public bool zhangfeiroar;
    public bool zhangfeirowhp;
    public bool zhangfeihidden;
    public bool getberserker;
    public bool berserkerskill1full;
    public bool berserkerhidden;
    public bool berserkerclear;
    public bool getcriticaler;
    public bool criticalerskill1full;
    public bool getdruid;
    public bool druidfirstskill;
    public bool druidskill100;
    public bool getassassin;
    public bool assassinskill2full;
    public bool getambidextrous;
    public bool getlubu;
    public bool lubuhidden;
    public bool lubuskill1full;
    public bool getheavycavalry;
    public bool gethealthmagician;
    public bool healthmagicianskill2full;
    public bool healthmagicianhidden;
    public bool getprist;
    public bool pristhpfull;
    public bool pristjesus;
    public bool pristhidden;
    public bool getwarlock;
    public bool warlockskill1full;
    public bool warlockclear;
    public bool warlcokhidden;
    public bool getsalamander;
    public bool salamandermeteor;
    public bool salamandermeteor3;
    public bool salamanderhidden;
    public bool getcook;
    public bool cookfullhp;
    public bool cookhidden;
    public bool getzeus;
    public bool zeusskill1first;
    public bool zeushidden;
    public bool getpracticebug;
    public bool practicebugskill1full;
    public bool practicebugskill2full;
    public bool getstranger;
    public bool strangerfirstskill;
    public bool stangerskill100;
    public bool getqrf;
    public bool qrfputhanger;
    public bool qrfhidden;
    public bool getservant;
    public bool servantskill1first;
    public bool servanthidden;
    public bool getathlete;
    public bool ahleteskill2full;
    public bool ahleteclear;
    public bool getversatile;
    public bool versatilehidden;
    public bool getacupuncturist;
    public bool acupuncturistfirstskill;
    public bool acupuncturistcritical;
    public bool acupuncturistskill2full;
    public bool acupuncturistclear;
    public bool getspoonkiller;
    public bool spoonkillerskill1full;
    public bool spoonkillerskill2full;
    public bool spoonkillerclear;
    public bool gethelen;
    public bool helenskill100;
    public bool helenhidden;
    public bool helenstage1die;
    public bool helenclear;
    public bool getrich;
    public bool richget1000gold;
    public bool getswell;
    public bool swellskill1full;
    public bool swellclear;
    public bool getdelivery;
    public bool deliveryskill1full;
    public bool deliveryclear;
    public bool getrepairman;
    public bool repairmanhidden;
    public bool repairmanclear;
    public bool repairmanfullhp;
    public bool getdosa;
    public bool dosafirstskill;
    public bool dosaskilldie20;
    public bool dosahidden;
    public bool getgambler;
    public bool gamblerlose;
    public bool gamblerwin;
    public bool gamblerskill2;
    public bool getslowstarter;
    public bool slowstarterclear;
    public bool getorpheus;
    public bool orpheusskill1full;
    public bool orpheusfirstdie;
    public bool getdokev;
    public bool dokevfirstskill;
    public bool dokevhidden;
    public bool dokevhidden50;
    public bool statlv5;
    public bool stage1clear;
    public bool stage2clear;

    #endregion
    /// --------------
    /// 확률
    public int _half;
    public int _1_3;
    public int _quater;
    public int _1_5;
    public int _strongManProbability;
    public int _spellCastProbability;
    public float _fireBallProbability;
    public float _iceBallProbability;
    public float _chainLightProbability;
    public int _meteorProbablility;
    [SerializeField] float m_viewAngle;    //시야각





    private void Awake()
    {
        Instance = this;
        Load();
        _data = new PlayerData(_hp, _atk, _matk, _atkSpeed, _def, _speed, _critical, _handicraft, _charm, _criticalDamage,
            _isKightHelmet, _isMasicianHat, _isGat, _isSkinHead, _isnormalHair, _isKnightTop, _isMasicianTop, _isDurumagiTop, _isKnightBottom, _isMasicianBottom, _isdurumagiBottom, _isKnightShoes, _isSandal, _isOldShoes, _isEmptyHelmet, _isNormalTop, _isTrunkBottom, _isnormalShoes, _isStick, _isSward1, _isSward2, _isBroom, _isClub, _isShortSward, _isHanger, _isMace, _isShield, _isSpear, _isUmbrella, _isWaldo, _buyStick, _buySward1, _buySward2, _buyBroom, _buyClub, _buyShortSward, _buyHanger, _buyMace, _buyShield, _buySpear, _buyUmbrella, _buyWaldo, _buyKightHelmet, _buyMasicianHat, _buyGat,
            _buySkinHead, _buynormalHair, _buyKnightTop, _buyMasicianTop, _buyDurumagiTop, _buyKnightBottom, _buyMasicianBottom, _buydurumagiBottom, _buyKnightShoes, _buySandal, _buyOldShoes, _buyEmptyHelmet, _buyNormalTop, _buyTrunkBottom, _buynormalShoes
            );
        
        _preSpeed = _speed;
        _maxHp = 50 + (_hp * 10);
        _basicAtk = _atk;
        _basicMatk = _matk;
        _basicAtkSpeed = _atkSpeed;
        _basicDef = _def;
        _basicSpeed = _speed;
        _basicCritical = _critical;
        _basicHandicraft = _handicraft;
        _basicCharm = _charm;
        _basicCriticalDamage = _criticalDamage;
        _criticalProbability = 3f;

        







        

        _listState.Add(_atk);
        _listState.Add(_matk);
        _listState.Add(_atkSpeed);
        _listState.Add(_hp);
        _listState.Add(_def);
        _listState.Add(_speed);
        _listState.Add(_critical);
        _listState.Add(_handicraft);
        _listState.Add(_charm);
        

        
     

    }

    private void Start()
    {
        
        _fireBallProbability = 30f;
        _iceBallProbability = 30f;
        _chainLightProbability = 30f;
        _jumpStack = 3;
        _basicJumpStack = _jumpStack;
        if(GamePlay.Instance != null)
        GamePlay.Instance.ChangeStage();
        
        

    }

    private void Update()
    {
       // _half = UnityEngine.Random.Range(0, 2);
        _1_3 = UnityEngine.Random.Range(0, 3);
        _quater = UnityEngine.Random.Range(0, 4);

        
        //사제 히든
        if(_playerTitle == PlayerTitle.Priest)
        {
            HiddenSkill(_playerTitle);
        }

        if(_animator != null)
        {
            _animator.speed = 0.5f + (_atkSpeed / 10f);
            _animator.SetFloat("AtkSpeed", _animator.speed);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _hp += 1;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Die();
            GamePlay.Instance.ActiveResultPopUp();
        }
       
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            Play(25);

        }
        //DrawView();

       

    }
    public Vector3 DirFromAngle(float angleInDegrees)
    {
        // 좌우 회전값 갱신
        angleInDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    public void DrawView()
    {
        Vector3 leftBoundary = DirFromAngle(-m_viewAngle / 2);
        Vector3 rightBoundary = DirFromAngle(m_viewAngle / 2);
        Debug.DrawLine(transform.position, transform.position + leftBoundary * m_viewDistance, Color.blue);
        Debug.DrawLine(transform.position, m_transform.position + rightBoundary * m_viewDistance, Color.blue);
    }

    public void FixedUpdate()
    {
        if (variableJoystick != null)
        {

            if (variableJoystick._isStop && _isIdle == true)
            {
                _basicSpeed = 0f;
               ChangeState(State.Idle);
            }
            else if (variableJoystick._isStop == false)
            {
                _basicSpeed = _preSpeed;
               ChangeState(State.Walk);
            }
           
        }
    }
    public override void Idle()
    {
        _isIdle = true;
        ChangeState(State.Idle);
    }
    public override void Attack()
    {
        //_isIdle = false;
        ChangeState(State.Attack);
    }
    public override void Walk()
    {
        ChangeState(State.Walk);
    }
    public override void Hit()
    {
        ChangeState(State.Hit);
    }
    public override void Die()
    {
        ChangeState(State.Die);
    }
    public override void Attack2()
    {

        if (_playerTitle == PlayerTitle.StrongMan)
        {

            _half = UnityEngine.Random.Range(0, 2);

            if (_half == 0)
            {
                Debug.Log("터졌다");
                ChangeState(State.Attack2);
            }
            else if (_half == 1)
            {
                _isIdle = true;
                ChangeState(State.Idle);
            }
        }
    }

    public void AttackOn()
    {
        int rand;
        _isAttack = true;
        int spell;
        spell = UnityEngine.Random.Range(0, 100);


        if(spell <_spellCastProbability + _weapon._spellProbability )
        {
            Spell(_iceBallProbability,_fireBallProbability,_chainLightProbability);

        }



        if (_playerTitle == PlayerTitle.StrongMan)
        {
            int max = 3 - _skill2;

            rand = UnityEngine.Random.Range(0, 4);

            if (rand >max)
            {
                Debug.Log("터졌다");
                ChangeState(State.Attack2);
            }
            else if (rand < max)
            {
                _isIdle = true;
                ChangeState(State.Idle);
            }
        }
        else if (_playerTitle == PlayerTitle.JackFrost)
        {
            //동장군 히든
            if(_skill1 >= 3)
            {
                achivementCheck(jackfrosthidden, "jackfrosthidden");
                rand = UnityEngine.Random.Range(0, 10);
                Debug.Log(rand);
                if (rand == 0 && GamePlay.Instance._isBlizzard == false)
                {
                    StartCoroutine(Blizzard());
                }
            }
        }
        else if(_playerTitle == PlayerTitle.ZhangFei)
        {
            
            rand = UnityEngine.Random.Range(0, 5);
            if(rand == 0 && _hp <= (_maxHp * 0.2f))
            {
                Roar();
                achivementCheck(zhangfeirowhp, "zhangfeirowhp");
            }
            else if(rand ==0)
            {
                Roar();
            }
        }
        else if(_playerTitle == PlayerTitle.Dosa)
        {
            rand = UnityEngine.Random.Range(0, 10);
            if(rand >= 0 + _skill1)
            {
                GamePlay.Instance._decoyPool.Get();
            }
        }
        else if (_playerTitle == PlayerTitle.Gambler)
        {
            rand = UnityEngine.Random.Range(1, 101);
            if(rand <= 50 + _skill2) 
            {
                int rand2 = UnityEngine.Random.Range(0, 9);

                if(rand2 == 0)
                {
                    _hp = _basicHp + (_basicHp * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 1)
                {
                    _atk = _basicAtk + (_basicAtk * (0.1f + _skill1/10f));
                }
                if (rand2 == 2)
                {
                    _matk = _basicMatk + (_basicMatk * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 3)
                {
                    _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 4)
                {
                    _def = _basicDef + (_basicDef * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 5)
                {
                    _speed = _basicSpeed + (_basicSpeed * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 6)
                {
                    _critical = _basicCritical + (_basicCritical * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 7)
                {
                    _handicraft = _basicHandicraft + (_basicHandicraft * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 8)
                {
                    _charm = _basicCharm + (_basicCharm * (0.1f + _skill1 / 10f));
                }
        
            }
            else if (rand > 50 + _skill2)
            {
                int rand2 = UnityEngine.Random.Range(0, 9);

                if (rand2 == 0)
                {
                    _hp = _basicHp - (_basicHp * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 1)
                {
                    _atk = _basicAtk - (_basicAtk * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 2)
                {
                    _matk = _basicMatk - (_basicMatk * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 3)
                {
                    _atkSpeed = _basicAtkSpeed - (_basicAtkSpeed * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 4)
                {
                    _def = _basicDef - (_basicDef * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 5)
                {
                    _speed = _basicSpeed - (_basicSpeed * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 6)
                {
                    _critical = _basicCritical - (_basicCritical * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 7)
                {
                    _handicraft = _basicHandicraft - (_basicHandicraft * (0.1f + _skill1 / 10f));
                }
                if (rand2 == 8)
                {
                    _charm = _basicCharm - (_basicCharm * (0.1f + _skill1 / 10f));
                }
            }
        }
        else if (_playerTitle == PlayerTitle.Priest)
        {
            rand = UnityEngine.Random.Range(0, 5 - _skill2);
            if (rand == 0)
            {
                _hp += _maxHp / 10f + (_maxHp / (10 - (_skill1 * 2)));
            }
        }
        

    }
    public void AttackOff()
    {
        _isAttack = false;
    }


    public override void ChangeState(State state)
    {
        base.ChangeState(state);
        _animator.SetInteger(_aniHashKeyState, (int)_state);
        
        switch(_state)
        {
            case State.Idle:
                Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
                _rigidbody.velocity = (direction * (_basicSpeed * 50f) * Time.fixedDeltaTime);
                m_transform.transform.rotation = Quaternion.LookRotation(direction);
                m_transform.transform.Translate(Vector3.forward * _rotateSpeed * Time.deltaTime);
               
                break;
            case State.Walk:
              
                    Vector3 direction2 = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
                    _rigidbody.velocity = (direction2 * (_basicSpeed * 50f) * Time.fixedDeltaTime);
                    m_transform.transform.rotation = Quaternion.LookRotation(direction2);
                    m_transform.transform.Translate(Vector3.forward * _rotateSpeed * Time.deltaTime);
               

                _isIdle = true;

                break;
            case State.Attack:
               
                _isIdle = true;

                break;
            case State.Hit:
                _isIdle = true;
                break;
            case State.Die:
                if(GamePlay.Instance._currentStage == GamePlay.GameState.Stage1 && earlydie == false)
                {
                    earlydie = true;
                    AchievementManager.instance.Unlock("earlydie");
                }
                if(GamePlay.Instance._currentStage == GamePlay.GameState.Stage1 && _totalCreepScore == 0 && nonviolent == false)
                {
                    nonviolent = true;
                    AchievementManager.instance.Unlock("nonviolent");
                }
                if(GamePlay.Instance._currentStage == GamePlay.GameState.Stage1 && _playerTitle == PlayerTitle.Helen && helenstage1die == false)
                {
                    helenstage1die = true;
                    AchievementManager.instance.Unlock("helenstage1die");
                }
                if(_playerTitle == PlayerTitle.Orpheus && orpheusfirstdie == false)
                {
                    orpheusfirstdie = true;
                    AchievementManager.instance.Unlock("orpheusfirstdie");
                }
                break;
            case State.Attack2:
              
                _isIdle = true;
                break;
            case State.None:
                _isIdle = false;
                break;
        }
    }
    bool IsTitle(PlayerTitle title)
    {
        return _playerTitle == title;
    }
    public void ChangeTitle(PlayerTitle title)
    {
        if (IsTitle(title))
            return;
        _playerTitle = title;
        int rand;
        switch(_playerTitle)
        {
            case PlayerTitle.Normal:
                _atk = _basicAtk + (_basicAtk * _skill1 / 10f);
                _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill2 / 10f);
                break;

            case PlayerTitle.MagicalBlader:
                rand = UnityEngine.Random.Range(0, 2);

                if (rand == 0)
                {

                    _atk = _basicAtk + _basicAtk + (_basicAtk * _skill2 / 10f);
                    _matk = 0 + (_basicMatk * _skill1 / 10f);
                    
                }
                else if (rand == 1)
                {
                    _atk = 0 + (_basicAtk * _skill2 / 10f);
                    _matk = _basicMatk + _basicMatk + (_basicMatk * _skill1 / 10f);
                    
                }

                break;

            case PlayerTitle.MadMan:
                _atk = (_basicAtk * 0.75f) + (_basicAtk * _skill1 / 10f);
                _matk = (_basicMatk * 0.75f) + (_basicMatk * _skill2 / 10f);
                _criticalDamage = (_basicCriticalDamage * 2f) + (_basicCriticalDamage * _skill3 / 10f);

                break;
            case PlayerTitle.StrongMan:

                _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill1 / 10f);
                if(_skill1 >= 3)
                {
                    achivementCheck(strongmanskill1full, "strongmanskill1full");
                }

                break;
            case PlayerTitle.Warrior:
                _atk = _basicAtk + (_basicAtk * 0.3f) + (_basicAtk * _skill1 / 10f);
                if(_skill1 >=3 )
                {
                    achivementCheck(warriorskill1full, "warriorskill1full");
                }

                break;
            case PlayerTitle.Dwarf:
                _atk = _basicAtk + _skill2 / 10f;
                _weapon._damage = _weapon._basicDamage + (_weapon._basicDamage * 0.3f) + (_weapon._basicDamage * _skill1 / 10f);
                if(_skill1 >= 3)
                {
                    achivementCheck(dwarfskill1full, "dwarfskill1full");
                }
                break;
            case PlayerTitle.JackFrost:
                _iceBallProbability = 100f;
                _chainLightProbability = 0f;
                _fireBallProbability = 0f;

                _atk = _basicAtk + (_basicAtk * _skill2 / 10f);
                _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill3 / 10f);

                break;
            case PlayerTitle.AssaultCaptain:
                _speed = _basicSpeed + (_basicSpeed * 0.3f) + (_basicSpeed * _skill1 / 10f);
                _atk = _basicAtk + (_basicAtk * _skill2 / 10f);
                if(_skill1 >= 3 || _skill2 >= 3)
                {
                    achivementCheck(assaultcaptainfull, "assaultcaptainfull");
                }


                break;
            case PlayerTitle.ZhangFei:
                break;
            case PlayerTitle.Berserker:
                //업데이트


                _atk = _basicAtk + (_basicAtk * _skill2 / 10f);
                if(_skill1 >= 3)
                {
                    achivementCheck(berserkerskill1full, "berserkerskill1full");
                }

                if (_skill2 >= 3)
                {
                    achivementCheck(berserkerhidden, "berserkerhidden");
                    _maxHp = _basicHp * 0.2f;
                    _atk = (_basicAtk * 2f) + (_basicAtk * 2f);
                }
                else if (_hp <= (_maxHp * (0.25f + _skill1 / 20f)))
                {

                    _atk = (_basicAtk * 2f) + (_basicAtk * _skill2 / 10f);
                }


                break;
            case PlayerTitle.Critialer:
                if(_skill1 >= 3)
                {
                    achivementCheck(criticalerskill1full, "criticalerskill1full");
                }
                
                
                _criticalProbability = 1f;
                _criticalDamage = _basicCriticalDamage + (_basicCriticalDamage * _skill1 / 10f);
                _atk = (_basicAtk * 0.3f) + (_basicAtk * _skill2 / 10f);


                break;
            case PlayerTitle.Druid:
                _speed = _basicSpeed + (_basicSpeed * _skill2 / 10f);
                break;
            case PlayerTitle.Assassin:
                if (_skill2 >= 3)
                {
                    achivementCheck(assassinskill2full, "assassinskill2full");
                }

                _criticalDamage = _basicCriticalDamage + (_basicCriticalDamage * 0.2f) + (_basicCriticalDamage * _skill1 / 10f);
                _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill3 / 10f);
                
                
                break;

            case PlayerTitle.Ambidextrous:
                _atkSpeed += _basicAtkSpeed + (_basicAtkSpeed * 0.5f) + (_basicAtkSpeed * _skill1 / 10f);
                _atk = _basicAtk + (_basicAtk * _skill2 / 10f);
                break;
            case PlayerTitle.LuBu:

                if(_skill1 >= 3)
                {
                    achivementCheck(lubuskill1full, "lubuskill1full");
                }
                _atk = (_basicAtk * 3f) + (_basicAtk * _skill1 / 10f);
                _atkSpeed = 2f + (_skill2 / 10f);
                _speed = 2f;
            
                break;

            case PlayerTitle.HeavyCavalry:

                
                _atk = _basicAtk + (_basicAtk * 0.2f) + (_basicAtk * _skill1 / 10f);
                _speed = _basicSpeed + (_basicSpeed * 0.2f) + (_basicSpeed * _skill2 / 10f);
                break;
            case PlayerTitle.HealthMagician:
                _maxHp = _basicHp + (_basicHp * 0.3f) + (_basicHp * _skill1 / 5f);

                if (_skill2 >= 3)
                {
                    achivementCheck(healthmagicianskill2full, "healthmagicianskill2full");
                }

                //체력 풀스택시 체력비례 대미지 가격 및 주문확률증가 구현해야함
                _spellCastProbability = 50;
       
                break;
            case PlayerTitle.Priest:
        
                break;
            case PlayerTitle.Warlock:

                if(_skill1>= 3)
                {
                    achivementCheck(warlockskill1full, "warlockskill1full");
                }

                _matk = _basicMatk + (_basicMatk * _skill2 / 10f);
          
                if (_hp <= _maxHp * (0.20f + _skill1 / 20f))
                {
                    _matk = (_basicMatk * 2f) + (_basicMatk * _skill2 / 10f);
                }


                break;
            case PlayerTitle.Salamander:


                _iceBallProbability = 0f;
                _chainLightProbability = 0f;
                _fireBallProbability = 100f;
                _spellCastProbability += _skill1 * 10;
                _meteorProbablility = 10 + _skill2 * 5;
                break;
            case PlayerTitle.Zeus:
                if(_skill1>= 1)
                {
                    achivementCheck(zeusskill1first, "zeusskill1first");
                }


                _jumpStack = 5 + _skill1;
                _matk = _basicMatk + (_basicMatk * _skill2 / 10f);

                break;
            case PlayerTitle.PracticeBug:

                if(_skill1 >= 3)
                {
                    achivementCheck(practicebugskill1full, "practicebugskill1full");
                }
                if(_skill2 >= 3)
                {
                    achivementCheck(practicebugskill2full, "practicebugskill2full");
                }

                _spellCastProbability = 100;

                _matk = _basicMatk + (_basicMatk * _skill1 / 10f);
                _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill2);
                break;
            case PlayerTitle.Stranger:

                _matk = _basicMatk + (_basicMatk * _skill2 / 10f);

                //확률에 따른 블랙홀 추가

                break;
            case PlayerTitle.GateKeeper:
                break;
            case PlayerTitle.Cook:
                _atk = _basicAtk + (_basicAtk * _skill1 / 10f);

               
                break;
            case PlayerTitle.QRF:
                _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * 0.5f) + (_basicAtkSpeed * _skill1 / 10f);
                _atk = _basicAtk + (_basicAtk * 0.1f);
                _speed = _basicSpeed + (_basicSpeed * _skill2);


                //히든
                if (_skill2 >= 3)
                {
                    //공격시 스턴 구현 완료
                }
                break;
            case PlayerTitle.Servant:

                if(_skill1 >=1)
                {
                    achivementCheck(servantskill1first, "sercantskill1first");
                }

                _hp = _basicHp * 2f + (_basicHp * _skill1 / 5f);
                _atkSpeed = _basicAtkSpeed * (_basicAtkSpeed * _skill2 / 10f);

               
                break;
            case PlayerTitle.Athlete:

                if(_skill2 >= 3)
                {
                    achivementCheck(ahleteskill2full, "ahleteskill2full");
                }

                _hp = _basicHp + (_basicHp * 0.3f) + (_basicHp * _skill2 / 10f);
                _speed = _basicSpeed + (_basicSpeed * 0.2f) + (_basicSpeed * _skill1 / 10f);
                break;
            case PlayerTitle.Versatile:


                _weapon._damage = _weapon._basicDamage * 2f + (_weapon._basicDamage + _skill1 / 10f);


                _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill2 / 10f);
                

                break;
            case PlayerTitle.Shieldbearer:
                break;
            case PlayerTitle.Acupuncturist:
                if(_skill2 >= 3)
                {
                    achivementCheck(acupuncturistskill2full, "acupuncturistskill2full");
                }


                _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill2 / 10f);

                //즉사 구현해라
                break;
            case PlayerTitle.SpoonKiller:

                if(_skill1 >= 3)
                {
                    achivementCheck(spoonkillerskill1full, "spoonkillerskill1full");
                }
                if(_skill2 >= 3)
                {
                    achivementCheck(spoonkillerskill2full, "spoonkillerskill2full");
                }

                _atk = (_basicAtk * 0.5f) + (_basicAtk * _skill2 / 10f);
                _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill1 / 10f);

                break;
            case PlayerTitle.Helen:
                StopCoroutine(IceAge());


                StartCoroutine(IceAge());

                break;
            case PlayerTitle.Slicker:
                break;
            case PlayerTitle.Rich:
                _critical = _basicCritical + (_basicCritical * _skill1 / 10f);
                _speed = _basicSpeed + (_basicSpeed * _skill2 / 10f);

                //죽인 몬스터 수 *  골드 획득 나중에 만들 것
                break;
            case PlayerTitle.Swell:

                if(_skill1 >= 3)
                {
                    achivementCheck(swellskill1full, "swellskill1full");
                }


                _hp = _basicHp + (_basicHp * 0.2f) + (_basicHp * _skill1 / 10f);
                _atk = _basicAtk + (_basicAtk * 0.2f) + (_basicAtk * _skill1 / 10f);
                _matk = _basicMatk + (_basicMatk * 0.2f) + (_basicMatk * _skill1 / 10f);
                _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * 0.2f) + (_basicAtkSpeed * _skill1 / 10f); ;
                _def = _basicDef + (_basicDef * 0.2f) + (_basicDef * _skill1 / 10f);
                _speed = _basicSpeed + (_basicSpeed * 0.2f) + (_basicSpeed * _skill1 / 10f);
                _critical = _basicCritical + (_basicCritical * 0.2f) + (_basicCritical * _skill1 / 10f);
                _handicraft = _basicHandicraft + (_basicHandicraft * 0.2f) + (_basicHandicraft * _skill1 / 10f);
                _charm = _basicCharm + (_basicCharm * 0.2f) + (_basicCharm * _skill1 / 10f);
                break;
            case PlayerTitle.Delivery:
                
                if(_skill1 >= 3)
                {
                    achivementCheck(deliveryskill1full, "deliverryskill1full");
                }
                
                
                
                _speed = _basicSpeed + _basicSpeed + (_basicSpeed * _skill1 / 10f);
                _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * _skill2 / 10f);

                //여유 생기면 만들기
                if (_skill1 >= 3)
                {
                    //충돌데미지 추가
                }
                break;
            case PlayerTitle.Repairman:
                StopCoroutine(HealingFactor());
                

                _atk = _basicAtk + (_basicAtk * _skill2 / 10f);
                //체력에대한 공식 성립되면 추가
               
                    StartCoroutine(HealingFactor());

                break;
            case PlayerTitle.Dosa:

                //공격시 10% 확률로 분신 소환 분신은 스테이지가 종료되면 사라짐
                //지능 추가할것 스테이지 종료시 없어지는거 추가 할 것
                break;
            case PlayerTitle.Gambler:
                if(_skill2 >= 3)
                {
                    achivementCheck(gamblerskill2, "gamblerskill2");
                }
                //완료
                break;
            case PlayerTitle.SlowStarter:
                _hp = _basicHp + (_basicHp * 0.2f) + (_basicHp * _skill1 / 10f);
                _atk = _basicAtk + (_basicAtk * 0.2f) + (_basicAtk * _skill1 / 10f);
                _matk = _basicMatk + (_basicMatk * 0.2f) + (_basicMatk * _skill1 / 10f);
                _atkSpeed = _basicAtkSpeed + (_basicAtkSpeed * 0.2f) + (_basicAtkSpeed * _skill1 / 10f); ;
                _def = _basicDef + (_basicDef * 0.2f) + (_basicDef * _skill1 / 10f);
                _speed = _basicSpeed + (_basicSpeed * 0.2f) + (_basicSpeed * _skill1 / 10f);
                _critical = _basicCritical + (_basicCritical * 0.2f) + (_basicCritical * _skill1 / 10f);
                _handicraft = _basicHandicraft + (_basicHandicraft * 0.2f) + (_basicHandicraft * _skill1 / 10f);
                _charm = _basicCharm + (_basicCharm * 0.2f) + (_basicCharm * _skill1 / 10f);
                break;
            case PlayerTitle.Orpheus:
                StopCoroutine(MonsterAtkDown());

                _atk = _basicAtk + (_basicAtk + _skill2 / 10f);
                StartCoroutine(MonsterAtkDown());
                break;
            case PlayerTitle.DokeV:
                //공격시 10% 확률로 몬스터의 능력치를 랜덤으로 가져온다.
                break;


        }

    }
    public void HiddenSkill(PlayerTitle title)
    {
        switch (title)
        {
            case PlayerTitle.Normal:
                break;
            case PlayerTitle.MagicalBlader:
                
                //한번
                if (_skill1 == 3)
                {
                    achivementCheck(magicalbladerhidden,"magicalbladerhidden");
                    _atk = _basicAtk + _basicAtk + (_basicAtk * 0.5f);
                }
                else if (_skill2 >= 3)
                {
                    achivementCheck(magicalbladerhidden, "magicalbladerhidden");
                    _matk = _basicMatk + _basicMatk + (_basicMatk * 0.5f);
                }
                break;
            case PlayerTitle.MadMan:
                break;
            case PlayerTitle.StrongMan:
                if(_skill2 >= 3)
                {
                    achivementCheck(strongmanhidden, "strongmanhidden");
                }
                break;
            case PlayerTitle.Warrior:
                break;
            case PlayerTitle.Dwarf:
                break;
            case PlayerTitle.JackFrost:
                //완료
                break;
            case PlayerTitle.AssaultCaptain:
                break;
            case PlayerTitle.ZhangFei:
                //한번
                if (_skill2 >= 3)
                {
                    achivementCheck(zhangfeihidden, "zhangfeihidden");
                    m_viewDistance = 60f;
                }
                break;
            case PlayerTitle.Berserker:
                //한번
                if(_skill2 >= 3)
                {
                    _maxHp = _basicHp * 0.2f;
                    _atk = (_basicAtk * 2f) + (_basicAtk * 2f);
                }
                break;
            case PlayerTitle.Critialer:
                break;
            case PlayerTitle.Druid:
                break;
            case PlayerTitle.Assassin:
                break;
            case PlayerTitle.Ambidextrous:
                break;
            case PlayerTitle.LuBu:
                //한번
                if (_skill3 >= 3)
                {
                    achivementCheck(lubuhidden, "lubuhidden");
                    _atk = (_basicAtk * 5f);
                }
                break;
            case PlayerTitle.HeavyCavalry:
                break;
            case PlayerTitle.HealthMagician:
                //한번
                if (_skill1 >= 3)
                {
                    achivementCheck(healthmagicianhidden, "healthmagicianhidden");
                    _matk = (_maxHp / 10f) + _basicMatk;
                    _atk = (_maxHp / 10f) + _basicAtk;
                   
                }
                break;
            case PlayerTitle.Priest:
                //업데이트
                if (_skill1 >= 3 && _hp >= _maxHp)
                {
                    achivementCheck(pristhidden, "pristhidden");
                    _matk = _basicMatk * 3f;
                }
                else if(_skill1 >= 3 && _hp < _maxHp)
                {
                    _matk = _basicMatk;
                }
                break;
            case PlayerTitle.Warlock:
                //한번
                if (_skill2 >= 3)
                {
                    achivementCheck(warlcokhidden, "warlcokhidden");
                    _spellCastProbability = 70;
                }
                break;
            case PlayerTitle.Salamander:
                //한번
                if (_skill2 >= 3)
                {
                    achivementCheck(salamanderhidden, "salamanderhidden");
                    StartCoroutine(Immolation());
                }
                break;
            case PlayerTitle.Zeus:
                //한번
                if (_skill1 >= 3)
                {
                    achivementCheck(zeushidden, "zeushidden");
                    Thunder();
                }
                break;
            case PlayerTitle.PracticeBug:
                break;
            case PlayerTitle.Stranger:
                break;
            case PlayerTitle.GateKeeper:
                break;
            case PlayerTitle.Cook:
                //한번
                if (_skill2 >= 3)
                {
                    achivementCheck(cookhidden, "cookhidden");
                    _atk = _basicAtk * 2f;
                }
                break;
            case PlayerTitle.QRF:
                if (_skill2 >= 3)
                {
                    //공격시 스턴 구현 완료
                }

                break;
            case PlayerTitle.Servant:
                //한번
                if (_skill1 >= 3)
                {
                    achivementCheck(servanthidden, "servanthidden");
                    _matk = (_maxHp / 10f) + _basicMatk;
                    _atk = (_maxHp / 10f) + _basicAtk;
                }
                break;
            case PlayerTitle.Athlete:
                break;
            case PlayerTitle.Versatile:
                //한번
                if (_skill2 >= 3)
                {
                    achivementCheck(versatilehidden, "versatilehidden");
                    _spellCastProbability = 70;
                }
                break;
            case PlayerTitle.Shieldbearer:
                break;
            case PlayerTitle.Acupuncturist:
                break;
            case PlayerTitle.SpoonKiller:
                break;
            case PlayerTitle.Helen:
                if(_skill2 >= 3)
                {
                    achivementCheck(helenhidden, "helenhidden");
                }
                break;
            case PlayerTitle.Slicker:
                break;
            case PlayerTitle.Rich:
                break;
            case PlayerTitle.Swell:
                break;
            case PlayerTitle.Delivery:
                break;
            case PlayerTitle.Repairman:
                
                if (_skill1 >= 3)
                {
                    achivementCheck(repairmanhidden, "repairmanhidden");
                }
                break;
            case PlayerTitle.Dosa:
                //분신 스크립트에서 만질예정
                break;
            case PlayerTitle.Gambler:
                break;
            case PlayerTitle.SlowStarter:
                break;
            case PlayerTitle.Orpheus:
                break;
            case PlayerTitle.DokeV:
                break;
        }
    }
    public void ChangeComponent(GameObject obj)
    {
        _animator = obj.GetComponent<Animator>();
        _rigidbody = obj.GetComponent<Rigidbody>();
        m_transform = obj.GetComponent<Transform>();
    }
    public void achivementCheck(bool check, string str)
    {
        if (check == false)
        {
            check = true;
            AchievementManager.instance.Unlock(str);
        }
    }


    #region SKill




    public void Spell(float ice,float fire,float light)
    {
        float rand = UnityEngine.Random.Range(0, (ice + fire + light));
     
        
        if(rand <=_iceBallProbability)
        {
            //아이스볼
            Debug.Log("아이스볼");
        }
        else if(rand <=_iceBallProbability + _fireBallProbability && rand > _iceBallProbability)
        {
            //파이어볼
            Debug.Log("불공");
        }
        else if (rand >= _iceBallProbability + _fireBallProbability && rand <= _iceBallProbability + _fireBallProbability + _chainLightProbability)
        {
            Debug.Log("체라");

        }

        if(firstmagic == false)
        {
            firstmagic = true;
            AchievementManager.instance.Unlock("firstmagic");
        }

    }
    


    public IEnumerator CoLightning()
    {
        _count++;

        Collider[] targets = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);

        

        if (_count % 2 == 0 && _count != 0)//짝수
        {
            _listMonster.Clear();


            if (targets.Length != 0 && targets != null)
            {
                if (targets.Length > _jumpStack)
                {


                    for (int i = 0; i < _jumpStack; ++i)
                    {
                        if (targets[i] != null && targets.Length >= _jumpStack)
                        {
                            _listMonster.Add(targets[i].GetComponent<Monster>());


                        }
                        else if (targets[i] != null && targets.Length < _jumpStack)
                        {
                            _jumpStack = targets.Length;
                            _listMonster.Add(targets[i].GetComponent<Monster>());


                        }

                        if (i == 0 && _listLightning.Count < targets.Length)
                        {
                            var obj = Instantiate(_lightning);
                            var light = obj.GetComponent<LightningBoltScript>();
                            _listLightning.Add(obj);
                            light.StartObject = this.gameObject;
                            light.EndObject = _listMonster[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;

                        }
                        else if (i != 0 && i <= _jumpStack && _listLightning.Count < targets.Length)
                        {

                            yield return new WaitForSeconds(0.05f);
                            var obj = Instantiate(_lightning);
                            _listLightning.Add(obj);
                            var light = obj.GetComponent<LightningBoltScript>();
                            light.StartObject = _listMonster[i - 1].gameObject;
                            light.EndObject = _listMonster[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i == 0 && _listLightning.Count >= targets.Length)
                        {
                            _listLightning[i].SetActive(true);
                            _listLightning[i].GetComponent<LightningBoltScript>().StartObject = this.gameObject;
                            if (_listMonster[i] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i != 0 && i <= _jumpStack && _listLightning.Count >= targets.Length && _listMonster.Count != 0)
                        {
                            yield return new WaitForSeconds(0.05f);
                            _listLightning[i].SetActive(true);
                            if (_listMonster[i - 1] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().StartObject = _listMonster[i - 1].gameObject;
                            if (_listMonster[i] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;


                        }




                    }
                }
                else if(targets.Length <= _jumpStack)
                {
                    for (int i = 0; i < targets.Length; ++i)
                    {
                        if (targets[i] != null && targets.Length >= _jumpStack)
                        {
                            _listMonster.Add(targets[i].GetComponent<Monster>());


                        }
                        else if (targets[i] != null && targets.Length < _jumpStack)
                        {
                            _jumpStack = targets.Length;
                            _listMonster.Add(targets[i].GetComponent<Monster>());


                        }

                        if (i == 0 && _listLightning.Count < targets.Length)
                        {
                            var obj = Instantiate(_lightning);
                            var light = obj.GetComponent<LightningBoltScript>();
                            _listLightning.Add(obj);
                            light.StartObject = this.gameObject;
                            light.EndObject = _listMonster[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;

                        }
                        else if (i != 0  && _listLightning.Count < targets.Length)
                        {

                            yield return new WaitForSeconds(0.05f);
                            var obj = Instantiate(_lightning);
                            _listLightning.Add(obj);
                            var light = obj.GetComponent<LightningBoltScript>();
                            light.StartObject = _listMonster[i - 1].gameObject;
                            light.EndObject = _listMonster[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i == 0 && _listLightning.Count >= targets.Length)
                        {
                            _listLightning[i].SetActive(true);
                            _listLightning[i].GetComponent<LightningBoltScript>().StartObject = this.gameObject;
                            if (_listMonster[i] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i != 0 && _listLightning.Count >= targets.Length && _listMonster.Count != 0)
                        {
                            yield return new WaitForSeconds(0.05f);
                            _listLightning[i].SetActive(true);
                            if (_listMonster[i - 1] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().StartObject = _listMonster[i - 1].gameObject;
                            if (_listMonster[i] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;


                        }




                    }
                }
                for (int i = 0; i < _listLightning.Count; ++i)
                {
                    yield return new WaitForSeconds(0.05f);
                    _listLightning[i].SetActive(false);


                }



                _jumpStack = _basicJumpStack;
            }
        }
        else if (_count %2 == 1) // 홀수
        {
            _listMonster2.Clear();
            if (targets.Length != 0 && targets != null)
            {

                if (targets.Length > _jumpStack)
                {


                    for (int i = 0; i < _jumpStack; ++i)
                    {
                        if (targets[i] != null )
                        {
                            _listMonster2.Add(targets[i].GetComponent<Monster>());


                        }
                      

                        if (i == 0 && _listLightning.Count < targets.Length)
                        {
                            var obj = Instantiate(_lightning);
                            var light = obj.GetComponent<LightningBoltScript>();
                            _listLightning.Add(obj);
                            light.StartObject = this.gameObject;
                            light.EndObject = _listMonster2[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;

                        }
                        else if (i != 0 && i <= _jumpStack && _listLightning.Count < targets.Length)
                        {

                            yield return new WaitForSeconds(0.05f);
                            var obj = Instantiate(_lightning);
                            _listLightning.Add(obj);
                            var light = obj.GetComponent<LightningBoltScript>();
                            light.StartObject = _listMonster2[i - 1].gameObject;
                            light.EndObject = _listMonster2[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i == 0 && _listLightning.Count >= targets.Length)
                        {
                            _listLightning[i].SetActive(true);
                            _listLightning[i].GetComponent<LightningBoltScript>().StartObject = this.gameObject;
                            if (_listMonster2[i] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster2[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i != 0 && i <= _jumpStack && _listLightning.Count >= targets.Length && _listMonster2.Count != 0)
                        {
                            yield return new WaitForSeconds(0.05f);
                            _listLightning[i].SetActive(true);
                            if (_listMonster2[i - 1] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().StartObject = _listMonster2[i - 1].gameObject;
                            if (_listMonster2[i]  != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster2[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;


                        }




                    }
                }
                else if (targets.Length <= _jumpStack)
                {
                    for (int i = 0; i < targets.Length; ++i)
                    {
                        if (targets[i] != null )
                        {
                            _listMonster2.Add(targets[i].GetComponent<Monster>());


                        }


                        if (i == 0 && _listLightning.Count < targets.Length)
                        {
                            var obj = Instantiate(_lightning);
                            var light = obj.GetComponent<LightningBoltScript>();
                            _listLightning.Add(obj);
                            light.StartObject = this.gameObject;
                            light.EndObject = _listMonster2[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;

                        }
                        else if (i != 0  && _listLightning.Count < targets.Length)
                        {

                            yield return new WaitForSeconds(0.05f);
                            var obj = Instantiate(_lightning);
                            _listLightning.Add(obj);
                            var light = obj.GetComponent<LightningBoltScript>();
                            light.StartObject = _listMonster2[i - 1].gameObject;
                            light.EndObject = _listMonster2[i].gameObject;
                            light.EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i == 0 && _listLightning.Count >= targets.Length)
                        {
                            _listLightning[i].SetActive(true);
                            _listLightning[i].GetComponent<LightningBoltScript>().StartObject = this.gameObject;
                            if (_listMonster2[i].gameObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster2[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;
                        }
                        else if (i != 0  && _listLightning.Count >= targets.Length && _listMonster2.Count != 0)
                        {
                            yield return new WaitForSeconds(0.05f);
                            _listLightning[i].SetActive(true);
                            if (_listMonster2[i - 1] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().StartObject = _listMonster2[i - 1].gameObject;
                            if (_listMonster2[i] != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject = _listMonster2[i].gameObject;
                            if (_listLightning[i].GetComponent<LightningBoltScript>().EndObject != null)
                                _listLightning[i].GetComponent<LightningBoltScript>().EndObject.GetComponent<Monster>()._hp -= 1f;


                        }




                    }
                }



                for (int i = 0; i < _listLightning.Count; ++i)
                {
                    yield return new WaitForSeconds(0.05f);
                    _listLightning[i].SetActive(false);


                }



                _jumpStack = _basicJumpStack;
            }
        }
        
    }
    public IEnumerator Blizzard()
    {
        GamePlay.Instance.ActiveBlizzard();
        Collider[] targets = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);


        for(int i = 0; i < targets.Length; ++i)
        {
            _listBlizzardMonster.Add(targets[i].GetComponent<Monster>());
        }

        for(int i = 0; i < _listBlizzardMonster.Count; ++i)
        {
            _listBlizzardMonster[i].Freezing();
            _listBlizzardMonster[i]._hp -= 5;
        }

        yield return new WaitForSeconds(4f);

        GamePlay.Instance.DisableBlizzard();
        _listBlizzardMonster.Clear();

    }
    public void Roar()
    {

        achivementCheck(zhangfeiroar, "zhangfeiroar");


        m_viewDistance = 2 + _skill2;

      
        


        Collider[] targets = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);

        for(int i = 0; i < targets.Length; ++i)
        {
            _listBlizzardMonster.Add(targets[i].GetComponent<Monster>());
        }

        for(int i = 0; i < _listBlizzardMonster.Count; ++i)
        {
            _listBlizzardMonster[i]._ccDurationTime = 1 + _skill1;
            _listBlizzardMonster[i].Stun();

        }


        _listBlizzardMonster.Clear();

    }

    public void Meteor()
    {
        achivementCheck(salamandermeteor, "salamandermeteor");
        GamePlay.Instance._meteorTargetPool.Get();
    }
    public IEnumerator Immolation()
    {
        while(true)
        {
            var obj = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);
            for(int i = 0; i < obj.Length; ++i)
            {
                obj[i].GetComponent<Monster>()._hp -= 1f;
            }

            yield return new WaitForSeconds(1f);
            

        }
    }
    public void Thunder()
    {
        var obj = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);

        obj[0].GetComponent<Monster>()._hp -= 1f;
        

    }
    public void Wall()
    {
        GamePlay.Instance._wallPool.Get();
    }

    public IEnumerator IceAge()
    {
        while (true)
        {

            var obj = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);
            for (int i = 0; i < obj.Length; ++i)
            {
                int rand = UnityEngine.Random.Range(0, 10);
                if (rand >= 2 - _skill1)
                {
                    obj[i].GetComponent<Monster>().Freezing();
                }
                if(_skill2 >= 3)
                {

                    obj[i].GetComponent<Monster>()._hp -= _atk/3;
                }

            }

            yield return new WaitForSeconds(1f);


        }
    }

    public IEnumerator MonsterAtkDown()
    {
        while (true)
        {

            var obj = Physics.OverlapSphere(m_transform.position, m_viewDistance, m_targetMask);
            for (int i = 0; i < obj.Length; ++i)
            {


                obj[i].GetComponent<Monster>()._atk = obj[i].GetComponent<Monster>()._basicAtk * (0.7f + _skill2 / 10f);



            }

            yield return new WaitForSeconds(1f);


        }
    }

    public IEnumerator HealingFactor()
    {
        int time = 5;
        while (true)
        {

            if(_skill1 <3)
            {
                _hp += 10f + _skill1 * 10f;

            }
            else if (_skill1 >= 3)
            {
                _hp += _maxHp * 0.1f;
                time = 1;
            }
            
            if(_hp >= _maxHp)
            {
                _hp = _maxHp;
            }
            yield return new WaitForSeconds(time);


        }
    }








    #endregion


    #region File IO
    public void Save()
    {
        DataSave();
        string data = ObjectToJason(_data);
        string path = Path.Combine(Application.dataPath + "/04.Json/PlayerData.json");
        File.WriteAllText(path, data);

    }

    public void Load()
    {
        string path = Path.Combine(Application.dataPath + "/04.Json/PlayerData.json");
        string getJson = File.ReadAllText(path);

        PlayerData json = JsonToObject<PlayerData>(getJson);
        InsertData(json);
    }
    public void InsertData(PlayerData data)
    {
        _hp = data.m_hp;
        _atk = data.m_atk;
        _matk = data.m_matk;
        _atkSpeed = data.m_atkSpeed;
        _def = data.m_def;
        _speed = data.m_speed;
        _critical = data.m_critical;
        _handicraft = data.m_handicraft;
        _charm = data.m_charm;
        _criticalDamage = data.m_criticalDamage;




        _isStick = data.m_isStick;
        _isSward1 = data.m_isSward1;
        _isSward2 = data.m_isSward2;
        _isBroom = data.m_isBroom;
        _isClub = data.m_isClub;
        _isShortSward = data.m_isShortSward;
        _isHanger = data.m_isHanger;
        _isMace = data.m_isMace;
        _isShield = data.m_isShield;
        _isSpear = data.m_isSpear;
        _isUmbrella = data.m_isUmbrella;
        _isWaldo = data.m_isWaldo;

        _isKightHelmet = data.m_isKightHelmet;
        _isMasicianHat = data.m_isMasicianHat;
        _isGat = data.m_isGat;
        _isSkinHead = data.m_isSkinHead;
        _isnormalHair = data.m_isnormalHair;
        _isKnightTop = data.m_isKnightTop;
        _isMasicianTop = data.m_isMasicianTop;
        _isDurumagiTop = data.m_isDurumagiTop;
        _isKnightBottom = data.m_isKnightBottom;
        _isMasicianBottom = data.m_isMasicianBottom;
        _isdurumagiBottom = data.m_isdurumagiBottom;
        _isKnightShoes = data.m_isKnightShoes;
        _isSandal = data.m_isSandal;
        _isOldShoes = data.m_isOldShoes;
        _isEmptyHelmet = data.m_isEmptyHelmet;
        _isNormalTop = data.m_isNormalTop;
        _isTrunkBottom = data.m_isTrunkBottom;
        _isnormalShoes = data.m_isnormalShoes;


        _buyStick = data.m_buyStick;
        _buySward1 = data.m_buySward1;
        _buySward2 = data.m_buySward2;
        _buyBroom = data.m_buyBroom;
        _buyClub = data.m_buyClub;
        _buyShortSward = data.m_buyShortSward;
        _buyHanger = data.m_buyHanger;
        _buyMace = data.m_buyMace;
        _buyShield = data.m_buyShield;
        _buySpear = data.m_buySpear;
        _buyUmbrella = data.m_buyUmbrella;
        _buyWaldo = data.m_buyWaldo;

        _buyKightHelmet = data.m_buyKightHelmet;
        _buyMasicianHat = data.m_buyMasicianHat;
        _buyGat = data.m_buyGat;
        _buySkinHead = data.m_buySkinHead;
        _buynormalHair = data.m_buynormalHair;
        _buyKnightTop = data.m_buyKnightTop;
        _buyMasicianTop = data.m_buyMasicianTop;
        _buyDurumagiTop = data.m_buyDurumagiTop;
        _buyKnightBottom = data.m_buyKnightBottom;
        _buyMasicianBottom = data.m_buyMasicianBottom;
        _buydurumagiBottom = data.m_buydurumagiBottom;
        _buyKnightShoes = data.m_buyKnightShoes;
        _buySandal = data.m_buySandal;
        _buyOldShoes = data.m_buyOldShoes;


        _buyEmptyHelmet = data.m_buyEmptyHelmet;
        _buyNormalTop = data.m_buyNormalTop;
        _buyTrunkBottom = data.m_buyTrunkBottom;
        _buynormalShoes = data.m_buynormalShoes;

        firststat = data.m_firststat;
        firstmaster = data.m_firstmaster;
        firstjob = data.m_firstjob;
        earlydie = data.m_earlydie;
        nonviolent = data.m_nonviolent;
        firstmagic = data.m_firstmagic;
        firsthunt = data.m_firsthunt;
        getmagicalblader = data.m_getmagicalblader;
        magicalbladerhidden = data.m_magicalbladerhidden;
        getmadman = data.m_getmadman;
        madmanmadness = data.m_madmanmadness;
        getstrongman = data.m_getstrongman;
        strongmanhidden = data.m_strongmanhidden;
        strongmanskill1full = data.m_strongmanskill1full;
        getwarrior = data.m_getwarrior;
        warriorskill1full = data.m_warriorskill1full;
        getdwarf = data.m_getdwarf;
        dwarfskill1full = data.m_dwarfskill1full;
        getjackfrost = data.m_getjackfrost;
        jackfrosthidden = data.m_jackfrosthidden;
        jackfrosttuna = data.m_jackfrosttuna;
        getassaultcaptain = data.m_getassaultcaptain;
        assaultcaptainfull = data.m_assaultcaptainfull;
        getzhangfei = data.m_getzhangfei;
        zhangfeiroar = data.m_zhangfeiroar;
        zhangfeirowhp = data.m_zhangfeirowhp;
        zhangfeihidden = data.m_zhangfeihidden;
        getberserker = data.m_getberserker;
        berserkerskill1full = data.m_berserkerskill1full;
        berserkerhidden = data.m_berserkerhidden;
        berserkerclear = data.m_berserkerclear;
        getcriticaler = data.m_getcriticaler;
        criticalerskill1full = data.m_criticalerskill1full;
        getdruid = data.m_getdruid;
        druidfirstskill = data.m_druidfirstskill;
        druidskill100 = data.m_druidskill100;
        getassassin = data.m_getassassin;
        assassinskill2full = data.m_assassinskill2full;
        getambidextrous = data.m_getambidextrous;
        getlubu = data.m_getlubu;
        lubuhidden = data.m_lubuhidden;
        lubuskill1full = data.m_lubuskill1full;
        getheavycavalry = data.m_getheavycavalry;
        gethealthmagician = data.m_gethealthmagician;
        healthmagicianskill2full = data.m_healthmagicianskill2full;
        healthmagicianhidden = data.m_healthmagicianhidden;
        getprist = data.m_getprist;
        pristhpfull = data.m_pristhpfull;
        pristjesus = data.m_pristjesus;
        pristhidden = data.m_pristhidden;
        getwarlock = data.m_getwarlock;
        warlockskill1full = data.m_warlockskill1full;
        warlockclear = data.m_warlockclear;
        warlcokhidden = data.m_warlcokhidden;
        getsalamander = data.m_getsalamander;
        salamandermeteor = data.m_salamandermeteor;
        salamandermeteor3 = data.m_salamandermeteor3;
        salamanderhidden = data.m_salamanderhidden;
        getcook = data.m_getcook;
        cookfullhp = data.m_cookfullhp;
        cookhidden = data.m_cookhidden;
        getzeus = data.m_getzeus;
        zeusskill1first = data.m_zeusskill1first;
        zeushidden = data.m_zeushidden;
        getpracticebug = data.m_getpracticebug;
        practicebugskill1full = data.m_practicebugskill1full;
        practicebugskill2full = data.m_practicebugskill2full;
        getstranger = data.m_getstranger;
        strangerfirstskill = data.m_strangerfirstskill;
        stangerskill100 = data.m_stangerskill100;
        getqrf = data.m_getqrf;
        qrfputhanger = data.m_qrfputhanger;
        qrfhidden = data.m_qrfhidden;
        getservant = data.m_getservant;
        servantskill1first = data.m_servantskill1first;
        servanthidden = data.m_servanthidden;
        getathlete = data.m_getathlete;
        ahleteskill2full = data.m_ahleteskill2full;
        ahleteclear = data.m_ahleteclear;
        getversatile = data.m_getversatile;
        versatilehidden = data.m_versatilehidden;
        getacupuncturist = data.m_getacupuncturist;
        acupuncturistfirstskill = data.m_acupuncturistfirstskill;
        acupuncturistcritical = data.m_acupuncturistcritical;
        acupuncturistskill2full = data.m_acupuncturistskill2full;
        acupuncturistclear = data.m_acupuncturistclear;
        getspoonkiller = data.m_getspoonkiller;
        spoonkillerskill1full = data.m_spoonkillerskill1full;
        spoonkillerskill2full = data.m_spoonkillerskill2full;
        spoonkillerclear = data.m_spoonkillerclear;
        gethelen = data.m_gethelen;
        helenskill100 = data.m_helenskill100;
        helenhidden = data.m_helenhidden;
        helenstage1die = data.m_helenstage1die;
        helenclear = data.m_helenclear;
        getrich = data.m_getrich;
        richget1000gold = data.m_richget1000gold;
        getswell = data.m_getswell;
        swellskill1full = data.m_swellskill1full;
        swellclear = data.m_swellclear;
        getdelivery = data.m_getdelivery;
        deliveryskill1full = data.m_deliveryskill1full;
        deliveryclear = data.m_deliveryclear;
        getrepairman = data.m_getrepairman;
        repairmanhidden = data.m_repairmanhidden;
        repairmanclear = data.m_repairmanclear;
        repairmanfullhp = data.m_repairmanfullhp;
        getdosa = data.m_getdosa;
        dosafirstskill = data.m_dosafirstskill;
        dosaskilldie20 = data.m_dosaskilldie20;
        dosahidden = data.m_dosahidden;
        getgambler = data.m_getgambler;
        gamblerlose = data.m_gamblerlose;
        gamblerwin = data.m_gamblerwin;
        gamblerskill2 = data.m_gamblerskill2;
        getslowstarter = data.m_getslowstarter;
        slowstarterclear = data.m_slowstarterclear;
        getorpheus = data.m_getorpheus;
        orpheusskill1full = data.m_orpheusskill1full;
        orpheusfirstdie = data.m_orpheusfirstdie;
        getdokev = data.m_getdokev;
        dokevfirstskill = data.m_dokevfirstskill;
        dokevhidden = data.m_dokevhidden;
        dokevhidden50 = data.m_dokevhidden50;
        statlv5 = data.m_statlv5;
        stage1clear = data.m_stage1clear;
        stage2clear = data.m_stage2clear;



    }
    public void DataSave()
    {
        _data.m_hp = _hp;
        _data.m_atk = _atk;
        _data.m_matk = _matk;
        _data.m_atkSpeed = _atkSpeed;
        _data.m_def = _def;
        _data.m_speed = _speed;
        _data.m_critical = _critical;
        _data.m_handicraft = _handicraft;
        _data.m_charm = _charm;
        _data.m_criticalDamage = _criticalDamage;

        _data.m_isStick = _isStick;
        _data.m_isSward1 = _isSward1;
        _data.m_isSward2 = _isSward2;
        _data.m_isBroom = _isBroom;
        _data.m_isClub = _isClub;
        _data.m_isShortSward = _isShortSward;
        _data.m_isHanger = _isHanger;
        _data.m_isMace = _isMace;
        _data.m_isShield = _isShield;
        _data.m_isSpear = _isSpear;
        _data.m_isUmbrella = _isUmbrella;
        _data.m_isWaldo = _isWaldo;


        _data.m_isKightHelmet = _isKightHelmet;
        _data.m_isMasicianHat = _isMasicianHat;
        _data.m_isGat = _isGat;
        _data.m_isSkinHead = _isSkinHead;
        _data.m_isnormalHair = _isnormalHair;
        _data.m_isKnightTop = _isKnightTop;
        _data.m_isMasicianTop = _isMasicianTop;
        _data.m_isDurumagiTop = _isDurumagiTop;
        _data.m_isKnightBottom = _isKnightBottom;
        _data.m_isMasicianBottom = _isMasicianBottom;
        _data.m_isdurumagiBottom = _isdurumagiBottom;
        _data.m_isKnightShoes = _isKnightShoes;
        _data.m_isSandal = _isSandal;
        _data.m_isOldShoes = _isOldShoes;
        _data.m_isEmptyHelmet = _isEmptyHelmet;
        _data.m_isNormalTop = _isNormalTop;
        _data.m_isTrunkBottom = _isTrunkBottom;
        _data.m_isnormalShoes = _isnormalShoes;

        _data.m_buyStick = _buyStick;
        _data.m_buySward1 = _buySward1;
        _data.m_buySward2 = _buySward2;
        _data.m_buyBroom = _buyBroom;
        _data.m_buyClub = _buyClub;
        _data.m_buyShortSward = _buyShortSward;
        _data.m_buyHanger = _buyHanger;
        _data.m_buyMace = _buyMace;
        _data.m_buyShield = _buyShield;
        _data.m_buySpear = _buySpear;
        _data.m_buyUmbrella = _buyUmbrella;
        _data.m_buyWaldo = _buyWaldo;

        _data.m_buyKightHelmet = _buyKightHelmet;
        _data.m_buyMasicianHat = _buyMasicianHat;
        _data.m_buyGat = _buyGat;
        _data.m_buySkinHead = _buySkinHead;
        _data.m_buynormalHair = _buynormalHair;
        _data.m_buyKnightTop = _buyKnightTop;
        _data.m_buyMasicianTop = _buyMasicianTop;
        _data.m_buyDurumagiTop = _buyDurumagiTop;
        _data.m_buyKnightBottom = _buyKnightBottom;
        _data.m_buyMasicianBottom = _buyMasicianBottom;
        _data.m_buydurumagiBottom = _buydurumagiBottom;
        _data.m_buyKnightShoes = _buyKnightShoes;
        _data.m_buySandal = _buySandal;
        _data.m_buyOldShoes = _buyOldShoes;


        _data.m_buyEmptyHelmet = _buyEmptyHelmet;
        _data.m_buyNormalTop = _buyNormalTop;
        _data.m_buyTrunkBottom = _buyTrunkBottom;
        _data.m_buynormalShoes = _buynormalShoes;




        _data.m_firststat = firststat;
        _data.m_firstmaster = firstmaster;
        _data.m_firstjob = firstjob;
        _data.m_earlydie = earlydie;
        _data.m_nonviolent = nonviolent;
        _data.m_firstmagic = firstmagic;
        _data.m_firsthunt = firsthunt;
        _data.m_getmagicalblader = getmagicalblader;
        _data.m_magicalbladerhidden = magicalbladerhidden;
        _data.m_getmadman = getmadman;
        _data.m_madmanmadness = madmanmadness;
        _data.m_getstrongman = getstrongman;
        _data.m_strongmanhidden = strongmanhidden;
        _data.m_strongmanskill1full = strongmanskill1full;
        _data.m_getwarrior = getwarrior;
        _data.m_warriorskill1full = warriorskill1full;
        _data.m_getdwarf = getdwarf;
        _data.m_dwarfskill1full = dwarfskill1full;
        _data.m_getjackfrost = getjackfrost;
        _data.m_jackfrosthidden = jackfrosthidden;
        _data.m_jackfrosttuna = jackfrosttuna;
        _data.m_getassaultcaptain = getassaultcaptain;
        _data.m_assaultcaptainfull = assaultcaptainfull;
        _data.m_getzhangfei = getzhangfei;
        _data.m_zhangfeiroar = zhangfeiroar;
        _data.m_zhangfeirowhp = zhangfeirowhp;
        _data.m_zhangfeihidden = zhangfeihidden;
        _data.m_getberserker = getberserker;
        _data.m_berserkerskill1full = berserkerskill1full;
        _data.m_berserkerhidden = berserkerhidden;
        _data.m_berserkerclear = berserkerclear;
        _data.m_getcriticaler = getcriticaler;
        _data.m_criticalerskill1full = criticalerskill1full;
        _data.m_getdruid = getdruid;
        _data.m_druidfirstskill = druidfirstskill;
        _data.m_druidskill100 = druidskill100;
        _data.m_getassassin = getassassin;
        _data.m_assassinskill2full = assassinskill2full;
        _data.m_getambidextrous = getambidextrous;
        _data.m_getlubu = getlubu;
        _data.m_lubuhidden = lubuhidden;
        _data.m_lubuskill1full = lubuskill1full;
        _data.m_getheavycavalry = getheavycavalry;
        _data.m_gethealthmagician = gethealthmagician;
        _data.m_healthmagicianskill2full = healthmagicianskill2full;
        _data.m_healthmagicianhidden = healthmagicianhidden;
        _data.m_getprist = getprist;
        _data.m_pristhpfull = pristhpfull;
        _data.m_pristjesus = pristjesus;
        _data.m_pristhidden = pristhidden;
        _data.m_getwarlock = getwarlock;
        _data.m_warlockskill1full = warlockskill1full;
        _data.m_warlockclear = warlockclear;
        _data.m_warlcokhidden = warlcokhidden;
        _data.m_getsalamander = getsalamander;
        _data.m_salamandermeteor = salamandermeteor;
        _data.m_salamandermeteor3 = salamandermeteor3;
        _data.m_salamanderhidden = salamanderhidden;
        _data.m_getcook = getcook;
        _data.m_cookfullhp = cookfullhp;
        _data.m_cookhidden = cookhidden;
        _data.m_getzeus = getzeus;
        _data.m_zeusskill1first = zeusskill1first;
        _data.m_zeushidden = zeushidden;
        _data.m_getpracticebug = getpracticebug;
        _data.m_practicebugskill1full = practicebugskill1full;
        _data.m_practicebugskill2full = practicebugskill2full;
        _data.m_getstranger = getstranger;
        _data.m_strangerfirstskill = strangerfirstskill;
        _data.m_stangerskill100 = stangerskill100;
        _data.m_getqrf = getqrf;
        _data.m_qrfputhanger = qrfputhanger;
        _data.m_qrfhidden = qrfhidden;
        _data.m_getservant = getservant;
        _data.m_servantskill1first = servantskill1first;
        _data.m_servanthidden = servanthidden;
        _data.m_getathlete = getathlete;
        _data.m_ahleteskill2full = ahleteskill2full;
        _data.m_ahleteclear = ahleteclear;
        _data.m_getversatile = getversatile;
        _data.m_versatilehidden = versatilehidden;
        _data.m_getacupuncturist = getacupuncturist;
        _data.m_acupuncturistfirstskill = acupuncturistfirstskill;
        _data.m_acupuncturistcritical = acupuncturistcritical;
        _data.m_acupuncturistskill2full = acupuncturistskill2full;
        _data.m_acupuncturistclear = acupuncturistclear;
        _data.m_getspoonkiller = getspoonkiller;
        _data.m_spoonkillerskill1full = spoonkillerskill1full;
        _data.m_spoonkillerskill2full = spoonkillerskill2full;
        _data.m_spoonkillerclear = spoonkillerclear;
        _data.m_gethelen = gethelen;
        _data.m_helenskill100 = helenskill100;
        _data.m_helenhidden = helenhidden;
        _data.m_helenstage1die = helenstage1die;
        _data.m_helenclear = helenclear;
        _data.m_getrich = getrich;
        _data.m_richget1000gold = richget1000gold;
        _data.m_getswell = getswell;
        _data.m_swellskill1full = swellskill1full;
        _data.m_swellclear = swellclear;
        _data.m_getdelivery = getdelivery;
        _data.m_deliveryskill1full = deliveryskill1full;
        _data.m_deliveryclear = deliveryclear;
        _data.m_getrepairman = getrepairman;
        _data.m_repairmanhidden = repairmanhidden;
        _data.m_repairmanclear = repairmanclear;
        _data.m_repairmanfullhp = repairmanfullhp;
        _data.m_getdosa = getdosa;
        _data.m_dosafirstskill = dosafirstskill;
        _data.m_dosaskilldie20 = dosaskilldie20;
        _data.m_dosahidden = dosahidden;
        _data.m_getgambler = getgambler;
        _data.m_gamblerlose = gamblerlose;
        _data.m_gamblerwin = gamblerwin;
        _data.m_gamblerskill2 = gamblerskill2;
        _data.m_getslowstarter = getslowstarter;
        _data.m_slowstarterclear = slowstarterclear;
        _data.m_getorpheus = getorpheus;
        _data.m_orpheusskill1full = orpheusskill1full;
        _data.m_orpheusfirstdie = orpheusfirstdie;
        _data.m_getdokev = getdokev;
        _data.m_dokevfirstskill = dokevfirstskill;
        _data.m_dokevhidden = dokevhidden;
        _data.m_dokevhidden50 = dokevhidden50;
        _data.m_statlv5 = statlv5;
        _data.m_stage1clear = stage1clear;
        _data.m_stage2clear = stage2clear;


    }
    string ObjectToJason(object data)
    {
        return JsonConvert.SerializeObject(data);
    }
    T JsonToObject<T>(string JsonData)
    {
        return JsonConvert.DeserializeObject<T>(JsonData);
    }
    #endregion


   


}
