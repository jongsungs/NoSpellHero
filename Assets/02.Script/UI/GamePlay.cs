using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using TMPro;

public class GamePlay : MonoBehaviour
{
    public enum GameState : int
    {
        Stage1 = 0,
        Stage2 = 1,
        Stage3 = 2,
        Stage4 = 3,
        Result = 4,
    }


    static public GamePlay Instance { get; private set; }


    
    public GameObject _pausePopUp;
    public GameObject _choicePopUp;
    public GameObject _bossHPBar;
    public GameObject _resultPopUp;
    public Monster _wolf;
    public Monster _slime;
    public Monster _captainSkull;
    public Monster _captainSkullNormal;
    public Monster _wolfKing;
    public Monster _wolfKingNormal;
    public Monster _ork;

    public Monster _demonKing;
    public Monster _skeleton;



    public GameObject _objectPool;
    public GameObject _damageTextPoolParent;
    public RespawnZone _randomSpawn;
    public LightningBoltScript _lightning;
    public GameObject _meteorTarget;
    public SkillBase _meteor;
    public SkillBase _wall;
    public Monster _decoy;
    public SkillBase _blackHole;
    public SkillBase _frozen;
    public SkillBase _roar;
    public SkillBase _heal;
    public SkillBase _meteorEffect;
    public SkillBase _thunder;
    public SkillBase _footStep;

    public Slider _effectSoundSlider;
    public Slider _bgmSouundSlider;

    public Camera _cam;
    public List<GameObject> _listPlayers = new List<GameObject>();
    public List<GameObject> _stageground = new List<GameObject>();


    
    
    public GameObject _blizzard;
    public bool _isBlizzard;
    public SkillBase _iceBall;
    public SkillBase _fireBall;
    public GameObject _ground;
    


    public bool _isBoss;

    public List<GameObject> _listMeteorTarget = new List<GameObject>();
    public List<SkillBase> _listMeteor = new List<SkillBase>();
    public List<GameObject> _listStage = new List<GameObject>();
    public List<Image> _listSkillIcon = new List<Image>();


    public bool _islerp;
    public float _lerp = 0;
    public float _ReverseLerp = 1f;

   

    private IObjectPool<Monster> _wolfpool;
    private IObjectPool<Monster> _slimePool;
    private IObjectPool<Monster> _captainSkullPool;
    private IObjectPool<Monster> _wolfkingPool;
    private IObjectPool<Monster> _captainSkullNormalPool;
    private IObjectPool<Monster> _wolfkingNormalPool;
    public IObjectPool<Monster> _skeletonPool;
    public IObjectPool<Monster> _orkPool;

    private IObjectPool<Monster> _demonkingPool;
    public IObjectPool<LightningBoltScript> _lightningPool;
    public IObjectPool<GameObject> _meteorTargetPool;
    public IObjectPool<SkillBase> _meteorPool;
    public IObjectPool<SkillBase> _wallPool;
    public IObjectPool<Monster> _decoyPool;
    public IObjectPool<SkillBase> _blackHolePool;
    public IObjectPool<SkillBase> _fireBallPool;
    public IObjectPool<SkillBase> _frozenPool;
    public IObjectPool<SkillBase> _roarPool;
    public IObjectPool<SkillBase> _healPool;
    public IObjectPool<SkillBase> _meteorEffectPool;
    public IObjectPool<SkillBase> _thunderPool;
    public IObjectPool<SkillBase> _footStepPool;
    public IObjectPool<SkillBase> _iceballPool;



    public GameState _currentStage;

    public bool _collectionChecks = true;
    public int _maxPoolSize = 5;
    public float[] _percent = {30,50,20};


    public delegate void EventHandler();

    public static event EventHandler _eventHandler;

    public MoreMountains.Tools.MMProgressBar _bossHpbarPlayer;
    public MoreMountains.Tools.MMProgressBar _playerHp;

    public TextMeshProUGUI _timerMin,_timerSec;
    public float _timer;
    public int _min, _sec;

    public Image _skill1Image;
    public Image _skill2Image;
    public Image _skill3Image;

    public TextMeshProUGUI _skill1Text;
    public TextMeshProUGUI _skill2Text;
    public TextMeshProUGUI _skill3Text;

    public Text _result1Text;
    public Text _result2Text;
    public Text _result3Text;
    public Text _result4Text;

    public Text _result1ScoreText;
    public Text _result2ScoreText;
    public Text _result3ScoreText;
    public Text _result4ScoreText;

    public TextMeshProUGUI _bossName;
    



    public int _spawnChannelCount;



    private void Awake()
    {
        Instance = this;
        _spawnChannelCount = 5;
        _slimePool = new ObjectPool<Monster>(CreatSlime,OngetMonster,OnReleaseMonster,OnDestroyMonster,maxSize : 10);
        _wolfpool = new ObjectPool<Monster>(CreatWolf, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);
        _captainSkullPool = new ObjectPool<Monster>(CreatCaptainSkull, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);
        _captainSkullNormalPool = new ObjectPool<Monster>(CreatCaptainSkullNormal, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);
        _skeletonPool = new ObjectPool<Monster>(CreatSkeleton, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 20);
        _wolfkingPool = new ObjectPool<Monster>(CreateWolfKing, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);
        _wolfkingNormalPool = new ObjectPool<Monster>(CreateWolfKingNormal, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);
        _orkPool = new ObjectPool<Monster>(CreateOrk, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);

        _demonkingPool = new ObjectPool<Monster>(CreatDemonKing, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);
        _lightningPool = new ObjectPool<LightningBoltScript>(CreateLightning, OngetLightningBolt, OnRelaseLightning, OnDestroyLightning, maxSize: 30);
        _meteorPool = new ObjectPool<SkillBase>(CreateMeteor, OngetMeteor, OnReleaseSkill, OnDestroySkill, maxSize: 10);
        _wallPool = new ObjectPool<SkillBase>(CreateWall, OngetSkill, OnReleaseSkill, OnDestroySkill, maxSize: 20);
        _decoyPool = new ObjectPool<Monster>(CreateDecoy, OngetDecoy, OnReleaseDecoy, OnDestroyDecoy, maxSize: 20);
        _blackHolePool = new ObjectPool<SkillBase>(CreateBlackHole, OngetSkill, OnReleaseSkill, OnDestroySkill, maxSize: 10);
        _fireBallPool = new ObjectPool<SkillBase>(CreateFireBall, OngetSkill, OnReleaseSkill, OnDestroySkill, maxSize: 10);
        _frozenPool = new ObjectPool<SkillBase>(CreateFrozen, OngetFrozen, OnReleaseSkill, OnDestroySkill, maxSize: 30);
        _roarPool = new ObjectPool<SkillBase>(CreateRoar, OngetRoar, OnReleaseRoar, OnDestroySkill, maxSize: 10);
        _meteorEffectPool = new ObjectPool<SkillBase>(CreateMeteorEffect, OngetMeteorTarger, OnReleaseSkill, OnDestroySkill, maxSize: 10);
        _thunderPool = new ObjectPool<SkillBase>(CreateThunder, OngetThunder, OnReleaseSkill, OnDestroySkill, maxSize: 10);
        _healPool = new ObjectPool<SkillBase>(CreateHeal, OngetEffectSkill, OnReleaseSkill, OnDestroySkill, maxSize: 20);
        _footStepPool = new ObjectPool<SkillBase>(CreateFootStepEffect, OngetFootStepEffect, OnReleaseSkill, OnDestroySkill, maxSize: 50);
        _iceballPool = new ObjectPool<SkillBase>(CreateIceBall, OngetSkill, OnReleaseSkill, OnDestroySkill, maxSize: 10);
        DisableBossHPBar();

        for (int i = 1; i < _listStage.Count; ++i)
        {
            _listStage[i].SetActive(false);
        }
        // _totalCreepScore = _stage1CreepScore + _stage2CreepScore + _stage3CreepScore + _stage4CreepScore;

        
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _slimePool.Get();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _wolfpool.Get();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _skeletonPool.Get();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _captainSkullNormalPool.Get();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _captainSkullPool.Get();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _wolfkingPool.Get();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            _wolfkingNormalPool.Get();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            _orkPool.Get();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _meteorEffectPool.Get();
        }
    }

    private Monster CreatSlime()
    {
        var monster = Instantiate(_slime, _randomSpawn.Return_RandomPosition(), Quaternion.identity);
        monster.SetPool(_slimePool);
        monster._floatingTextSpawner.Channel = _spawnChannelCount;
        monster._mmfPlayer.FeedbacksList[0].Channel = _spawnChannelCount;
        monster._mmfPlayer.Initialization();
        monster._hp = 20f;

        _spawnChannelCount++;

        return monster;
    }
    private Monster CreatWolf()
    {
        var monster = Instantiate(_wolf, _randomSpawn.Return_RandomPosition() ,Quaternion.identity);
        monster.SetPool(_wolfpool);
        monster._floatingTextSpawner.Channel = _spawnChannelCount;
        monster._mmfPlayer.FeedbacksList[0].Channel = _spawnChannelCount;
        monster._mmfPlayer.Initialization();

        _spawnChannelCount++;
        return monster;
    }
    private Monster CreatCaptainSkull()
    {
        var monster = Instantiate(_captainSkull, _randomSpawn.Return_RandomPosition(), Quaternion.identity);
        monster.SetPool(_captainSkullPool);

        return monster;
    }
    private Monster CreatCaptainSkullNormal()
    {
        var monster = Instantiate(_captainSkullNormal, _randomSpawn.Return_RandomPosition(), Quaternion.identity);
        monster.SetPool(_captainSkullNormalPool);

        return monster;
    }
    private Monster CreatSkeleton()
    {
        var monster = Instantiate(_skeleton, _randomSpawn.Return_RandomPosition(), Quaternion.identity);
        monster.SetPool(_skeletonPool);
        return monster;
    }
    private Monster CreateWolfKing()
    {
        var monster = Instantiate(_wolfKing, _randomSpawn.Return_RandomPosition(), Quaternion.identity);
        monster.SetPool(_wolfkingPool);
        return monster;
    }
    private Monster CreateWolfKingNormal()
    {
        var monster = Instantiate(_wolfKingNormal, _randomSpawn.Return_RandomPosition(), Quaternion.identity);
        monster.SetPool(_wolfkingNormalPool);
        return monster;
    }
    private Monster CreateOrk()
    {
        var monster = Instantiate(_ork, _randomSpawn.Return_RandomPosition(), Quaternion.identity);
        monster.SetPool(_orkPool);
        return monster;
    }
    private Monster CreatDemonKing()
    {
        var monster = Instantiate(_demonKing, _randomSpawn.Return_RandomPosition(), Quaternion.identity, _objectPool.transform);
        monster.SetPool(_demonkingPool);
        return monster;
    }
   
    private LightningBoltScript CreateLightning()
    {
        var lightning = Instantiate(_lightning, _randomSpawn.Return_RandomPosition(), Quaternion.identity, _objectPool.transform);
        lightning.SetPool(_lightningPool);
        return lightning;
    }
    
   
    private SkillBase CreateFrozen()
    {
        var target = Instantiate(_frozen, Player.Instance.m_transform.position, Quaternion.identity, _objectPool.transform);
        target.SetPool(_frozenPool);        
        return target;
    }
    private SkillBase CreateMeteor()
    {
        var meteor = Instantiate(_meteor, Player.Instance.m_transform.position + new Vector3(0,10,0),Quaternion.identity, _objectPool.transform);
        meteor.SetPool(_meteorPool);
        return meteor;
    }
    private SkillBase CreateWall()
    {
        var wall = Instantiate(_wall, Player.Instance.m_transform.position, Quaternion.identity, _objectPool.transform);
        wall.SetPool(_wallPool);
        return wall;

    }
    private Monster CreateDecoy()
    {
        var decoy = Instantiate(_decoy, _randomSpawn.Return_RandomPosition(), Quaternion.identity);
        decoy.SetPool(_decoyPool);
        return decoy;
    }
    private SkillBase CreateBlackHole()
    {
        var blackHole = Instantiate(_blackHole, Player.Instance._meteorPoint.transform.position + new Vector3(0, 0.5f, 0), Player.Instance.m_transform.rotation, _objectPool.transform);
        blackHole.SetPool(_blackHolePool);
        return blackHole;
    }
    private SkillBase CreateFireBall()
    {
        var blackHole = Instantiate(_fireBall, Player.Instance._meteorPoint.transform.position + new Vector3(0, 0.5f, 0), Player.Instance.m_transform.rotation, _objectPool.transform);
        blackHole.SetPool(_fireBallPool);
        return blackHole;
    }
    private SkillBase CreateRoar()
    {
        var roar = Instantiate(_roar, Player.Instance.m_transform.position, Quaternion.identity, Player.Instance.m_transform);

        roar.transform.localScale = new Vector3(0.5f + (float)Player.Instance._skill2, 0.5f + (float)Player.Instance._skill2, 0.5f + (float)Player.Instance._skill2);
        roar.SetPool(_roarPool);
        return roar;
    }
    private SkillBase CreateHeal()
    {
        var heal = Instantiate(_heal, Player.Instance.m_transform.position, Quaternion.identity, Player.Instance.m_transform);
        heal.SetPool(_healPool);
        return heal;
    }
   
    private SkillBase CreateMeteorEffect()
    {
        var meteorEffect = Instantiate(_meteorEffect, Player.Instance.m_transform.position, Quaternion.identity, _objectPool.transform);
        meteorEffect.SetPool(_meteorEffectPool);
        _listMeteorTarget.Add(meteorEffect.gameObject);
       // _meteorPool.Get();
        
        return meteorEffect;
    }
    private SkillBase CreateFootStepEffect()
    {
        var foot = Instantiate(_footStep, Player.Instance.m_transform.position + new Vector3(0f,0.065f,0), Quaternion.identity, _objectPool.transform);
        foot.SetPool(_footStepPool);

        return foot;
    }

    private SkillBase CreateThunder()
    {
        var thunder = Instantiate(_thunder, _randomSpawn.Return_RandomPosition(), Quaternion.identity, _objectPool.transform);
        thunder.SetPool(_thunderPool);
        return thunder;
    }
    private SkillBase CreateIceBall()
    {
        var blackHole = Instantiate(_iceBall, Player.Instance._meteorPoint.transform.position + new Vector3(0, 0.5f, 0), Player.Instance.m_transform.rotation, _objectPool.transform);
        blackHole.SetPool(_iceballPool);
        return blackHole;
    }

    

    // 새로 뽑을 때
    private void OngetMonster(Monster obj)
    {
        if(obj._monster != Monster.MonsterKind.None)
        obj.gameObject.layer = 6;
        obj._floatingTextSpawner.Channel = _spawnChannelCount;
        obj._mmfPlayer.FeedbacksList[0].Channel = _spawnChannelCount;
        obj._mmfPlayer.Initialization();

        _spawnChannelCount++;
        if (obj._monster == Monster.MonsterKind.Slime)
        {

            obj._hp = 0f + (0f * ((float)_currentStage + 1) * 0.2f);
            obj._atk = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            obj._def = 0f + (0f * ((float)_currentStage + 1) * 0.2f);
            obj._speed = 1f + (1 * ((float)_currentStage + 1) * 0.2f);
            obj._critical = 0f + (0f * ((float)_currentStage + 1) * 0.2f);
            obj._matk = 0f + (0f * ((float)_currentStage + 1) * 0.2f);
            obj._atkSpeed = 0f + (0f * ((float)_currentStage + 1) * 0.2f);
            //obj.StartCoroutine(obj.CoFindEnemy());
            obj.FadeIn();
        }
        if (obj._monster == Monster.MonsterKind.Wolf)
        {

            obj._hp = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._atk = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._def = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            obj._speed = 2f + (2 * ((float)_currentStage + 1) * 0.2f);
            obj._critical = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            obj._matk = 0f + (0f * ((float)_currentStage + 1) * 0.2f);
            obj._atkSpeed = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            obj.FadeIn();
        }
        if (obj._monster == Monster.MonsterKind.WolfKing && obj._category == Monster.MonsterCategory.Common)
        {
            obj._hp = 15f + (15f * ((float)_currentStage + 1) * 0.2f);
            obj._atk = 4f + (4f * ((float)_currentStage + 1) * 0.2f);
            obj._def = 3f + (3f * ((float)_currentStage + 1) * 0.2f);
            obj._speed = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._critical = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._matk = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._atkSpeed = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            obj.FadeIn();
        }
        if (obj._monster == Monster.MonsterKind.CaptainSkull && obj._category == Monster.MonsterCategory.Common)
        {

            obj._hp = 10f + (10f * ((float)_currentStage + 1) * 0.2f);
            obj._atk = 3f + (3 * ((float)_currentStage + 1) * 0.2f);
            obj._def = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            obj._speed = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            obj._critical = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._matk = 3f + (3f * ((float)_currentStage + 1) * 0.2f);
            obj._atkSpeed = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            obj.FadeIn();
        }

        if (obj._monster == Monster.MonsterKind.Skull)
        {
            obj._hp = 4f + (4f * ((float)_currentStage + 1) * 0.2f);
            obj._atk = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._def = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._speed = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            obj._critical = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            obj._matk = 0f + (0f * ((float)_currentStage + 1) * 0.2f);
            obj._atkSpeed = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            obj.FadeIn();
        }
        if (obj._monster == Monster.MonsterKind.CaptainSkull && _isBoss == false && _currentStage == GameState.Stage1 && obj._category == Monster.MonsterCategory.Boss)
        {
            obj._hp = 20f + (20f * ((float)_currentStage + 1) * 0.2f);
            obj._atk = 3f + (3f * ((float)_currentStage + 1) * 0.2f);
            obj._def = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._speed = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            obj._critical = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._matk = 3f + (3f * ((float)_currentStage + 1) * 0.2f);
            obj._atkSpeed = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            _isBoss = true;
            obj.FadeIn();

        }
        if (obj._monster == Monster.MonsterKind.WolfKing && _isBoss == false && _currentStage == GameState.Stage2 && obj._category == Monster.MonsterCategory.Boss)
        {
            obj._hp = 20f + (20f * ((float)_currentStage + 1) * 0.2f);
            obj._atk = 4f + (4f * ((float)_currentStage + 1) * 0.2f);
            obj._def = 3f + (3f * ((float)_currentStage + 1) * 0.2f);
            obj._speed = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._critical = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._matk = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._atkSpeed = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            _isBoss = true;
            obj.FadeIn();

        }
        if (obj._monster == Monster.MonsterKind.CaptainSkull && _isBoss == false && _currentStage == GameState.Stage3 && obj._category == Monster.MonsterCategory.Boss)
        {
            obj._hp = 20f + (20f * ((float)_currentStage + 1) * 0.2f);
            obj._atk = 3f + (3f * ((float)_currentStage + 1) * 0.2f);
            obj._def = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._speed = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            obj._critical = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._matk = 3f + (3f * ((float)_currentStage + 1) * 0.2f);
            obj._atkSpeed = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            _isBoss = true;
            obj.FadeIn();

        }
        if (obj._monster == Monster.MonsterKind.WolfKing && _isBoss == false && _currentStage == GameState.Stage4 && obj._category == Monster.MonsterCategory.Boss)
        {
            obj._hp = 20f + (20f * ((float)_currentStage + 1) * 0.2f);
            obj._atk = 4f + (4f * ((float)_currentStage + 1) * 0.2f);
            obj._def = 3f + (3f * ((float)_currentStage + 1) * 0.2f);
            obj._speed = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._critical = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._matk = 2f + (2f * ((float)_currentStage + 1) * 0.2f);
            obj._atkSpeed = 1f + (1f * ((float)_currentStage + 1) * 0.2f);
            _isBoss = true;
            obj.FadeIn();

        }
        obj.transform.position = _randomSpawn.Return_RandomPosition();
        obj.gameObject.SetActive(true);
        

    }

   
    private void OngetLightningBolt(LightningBoltScript lightning)
    {
        lightning.gameObject.SetActive(true);
    }
   
    private void OngetFrozen(SkillBase obj)
    {
        obj.gameObject.SetActive(true);
    }
    private void OngetMeteor(SkillBase meteor)
    {

        meteor.gameObject.SetActive(true);
        meteor.transform.position = Player.Instance.m_transform.position + new Vector3(5, 8, 0);


        if (_listMeteor.Count <= 1)
        {
            _listMeteor.Add(meteor);
        }
        else if(_listMeteor.Count >=2)
        {
            _listMeteor.Add(meteor);
            var temp = _listMeteor[0];
            _listMeteor[0] = _listMeteor[_listMeteor.Count - 1];
            _listMeteor[_listMeteor.Count - 1] = temp;

        }   
    }
    private void OngetRoar(SkillBase skill)
    {
        skill.transform.position = Player.Instance.m_transform.position ;
        skill.transform.localScale = new Vector3(0.5f + (float)Player.Instance._skill2, 0.5f + (float)Player.Instance._skill2, 0.5f + (float)Player.Instance._skill2);
        
        skill.gameObject.SetActive(true);
    }
    private void OngetSkill(SkillBase skill)
    {
        skill.transform.position = Player.Instance._meteorPoint.transform.position + new Vector3(0, 0.5f, 0);
        skill.transform.rotation = Player.Instance.m_transform.rotation;
        skill.gameObject.SetActive(true);
    }
    private void OngetFootStepEffect(SkillBase skill)
    {
        skill.transform.position = Player.Instance.m_transform.position + new Vector3(0, 0.065f, 0);
        skill.transform.rotation = Player.Instance.m_transform.rotation;
        skill.gameObject.SetActive(true);
    }
    private void OngetMeteorTarger(SkillBase skill)
    {
        skill.gameObject.SetActive(true);
        skill.transform.position = Player.Instance._meteorPoint.transform.position;
        _listMeteorTarget.Add(skill.gameObject);

        if (_listMeteorTarget.Count <= 1)
        {
            _listMeteorTarget.Add(skill.gameObject);
        }
        else if (_listMeteorTarget.Count >= 2)
        {
            _listMeteorTarget.Add(skill.gameObject);
            var temp = _listMeteorTarget[0];
            _listMeteorTarget[0] = _listMeteorTarget[_listMeteorTarget.Count - 1];
            _listMeteorTarget[_listMeteorTarget.Count - 1] = temp;

        }


         _meteorPool.Get();


        skill.transform.position = Player.Instance._meteorPoint.transform.position + new Vector3(0, 0.1f, 0);
        skill.gameObject.SetActive(true);
    }
    private void OngetThunder(SkillBase skill)
    {
        skill.transform.position = _randomSpawn.Return_RandomPosition();
        skill.gameObject.SetActive(true);
    }
    private void OngetDecoy(Monster decoy)
    {
        decoy._floatingTextSpawner.Channel = _spawnChannelCount;
        decoy._mmfPlayer.FeedbacksList[0].Channel = _spawnChannelCount;
        decoy._mmfPlayer.Initialization();

        _spawnChannelCount++;
        decoy.gameObject.SetActive(true);
    }
    private void OngetEffectSkill(SkillBase skill)
    {
        skill.transform.position = Player.Instance.m_transform.position + new Vector3(0, 0f, 0);
        skill.transform.rotation = Quaternion.Euler(0, 0, 0);
        skill.gameObject.SetActive(true);
    }
    // 반환할때 사라질때

    private void OnReleaseMonster(Monster obj)
    {
        Player.Instance._totalCreepScore++;
        if(Player.Instance._totalCreepScore >= 1 && Player.Instance.firsthunt == false)
        {
            Player.Instance.firsthunt = true;
            AchievementManager.instance.Unlock("firsthunt");
            Player.Instance.Save();
        }


        obj.gameObject.SetActive(false);
      
    }

   
    private void OnRelaseLightning(LightningBoltScript lightning)
    {
        lightning.gameObject.SetActive(false);
    }
    
    private void OnReleaseSkill(SkillBase skill)
    {
        skill.gameObject.SetActive(false);
    }
    private void OnReleaseDecoy(Monster decoy)
    {
        decoy.gameObject.SetActive(false);
    }
    private void OnReleaseRoar(SkillBase skill)
    {
        skill.gameObject.SetActive(false);
    }

    //풀이 꽉차서 없어질때
    private void OnDestroyMonster(Monster obj)
    {
        Destroy(obj.gameObject);
    }

  
    private void OnDestroyLightning(LightningBoltScript lightning)
    {
        Destroy(lightning.gameObject);
    }
    private void OnDestroySkill(SkillBase skill)
    {
        Destroy(skill.gameObject);
    }
    private void OnDestroyDecoy(Monster decoy)
    {
        Destroy(decoy.gameObject);
    }
    


    public void EnterLobby()
    {
         Player.Instance._atk = Player.Instance._basicAtk;
         Player.Instance._matk = Player.Instance._basicMatk;
         Player.Instance._hp = Player.Instance._basicHp;
         Player.Instance._def = Player.Instance._basicDef;
         Player.Instance._speed = Player.Instance._basicSpeed;
         Player.Instance._atkSpeed = Player.Instance._basicAtkSpeed;
         Player.Instance._critical = Player.Instance._basicCritical;
         Player.Instance._handicraft = Player.Instance._basicHandicraft;
         Player.Instance._charm = Player.Instance._basicCharm;
         Player.Instance.Save();



        Time.timeScale = 1f;
        LoadSceneManager.LoadScene("Lobby");
    }

    public void ActiveResultPopUp()
    {
        SoundManager.Instance.EffectPlay(SoundManager.Instance._result);
        List<int> _list = new List<int>();
        List<string> _stack = new List<string>();
        List<int> _stack2 = new List<int>();
        Time.timeScale = 0f;
        int[] arry = GetRandomInt(3, 0, 6);
        
        for(int i = 0; i < arry.Length; ++i)
        {
            _list.Add(arry[i]);
        }
        
        if(_list.Contains(0) == true)
        {
            string str = "처치한 몬스터 수";
            _stack.Add(str);
            _stack2.Add(Player.Instance._deadCreepScore);
        }
        if (_list.Contains(1) == true)
        {
            string str = "스킬 사용 횟수";
            _stack.Add(str);
            _stack2.Add(Player.Instance._spellScore);
        }
        if (_list.Contains(2) == true)
        {
            string str = "공격 횟수";
            _stack.Add(str);
            _stack2.Add(Player.Instance._attckCount);
        }
        if (_list.Contains(3) == true)
        {
            string str = "공격당한 횟수";
            _stack.Add(str);
            _stack2.Add(Player.Instance._hitCount);
        }
        if (_list.Contains(4) == true)
        {
            string str = "몬스터를 얼린 횟수";
            _stack.Add(str);
            _stack2.Add(Player.Instance._freezingCount);
        }
        if (_list.Contains(5) == true)
        {
            string str = "화상 입힌 횟수";
            _stack.Add(str);
            _stack2.Add(Player.Instance._burnCount);
        }


        _result1Text.text = _stack[0];
        _result1ScoreText.text = _stack2[0].ToString();
        _result2Text.text = _stack[1];
        _result2ScoreText.text = _stack2[1].ToString();
        _result3Text.text = _stack[2];
        _result3ScoreText.text = _stack2[2].ToString();
        if(Player.Instance._playerTitle != Player.PlayerTitle.Rich && Player.Instance._expX2 == false)
        {
             Player.Instance._getGold = (Player.Instance._deadCreepScore * 5) +(((int)_currentStage+1) * 100);
        }
        else if(Player.Instance._playerTitle != Player.PlayerTitle.Rich && Player.Instance._expX2 == true)
        {
            Player.Instance._getGold = ((Player.Instance._deadCreepScore * 5) + (((int)_currentStage + 1) * 100))*2;
        }
        else if(Player.Instance._playerTitle == Player.PlayerTitle.Rich && Player.Instance._expX2 == false)
        {
            Player.Instance._getGold = ((Player.Instance._deadCreepScore * 5) + (((int)_currentStage + 1) * 100)) * 3;
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Rich && Player.Instance._expX2 == true)
        {
            Player.Instance._getGold = ((Player.Instance._deadCreepScore * 5) + (((int)_currentStage + 1) * 100)) * 6;
        }
        _result4Text.text = "획득한 골드";
        _result4ScoreText.text = Player.Instance._getGold.ToString();
        Player.Instance._gold += Player.Instance._getGold;
        if(Player.Instance._getGold >= 4000 && Player.Instance.richget1000gold == false)
        {
            Player.Instance.richget1000gold = true;
            AchievementManager.instance.Unlock("richget1000gold");
        }
        if(Player.Instance._gold >= 999999)
        {
            Player.Instance._gold = 999999;
        }
        Player.Instance._totalCreepScore += Player.Instance._deadCreepScore;
        Player.Instance._getGold = 0;
        Player.Instance.Save();



        _resultPopUp.gameObject.SetActive(true);
    }

    public void EnterPausePopUp()
    {

        SoundManager.Instance.EffectPlay(SoundManager.Instance._gameplaySettingPopUp);
        _pausePopUp.gameObject.SetActive(true);
        _effectSoundSlider.value = Player.Instance._effectSound;
        _bgmSouundSlider.value = Player.Instance._bgmSound;
        Time.timeScale = 0f;
    }
    public void ExitPausePopUp()
    {
        _pausePopUp.gameObject.SetActive(false);

        SoundManager.Instance.EffectPlay(SoundManager.Instance._gameplaySettingPopUpClose);
        Time.timeScale = 1f;
    }
    public void GameOff()
    {
        Application.Quit();
    }

    public void EnterChoicePopUp()
    {
        _choicePopUp.gameObject.SetActive(true);

        SoundManager.Instance.EffectPlay(SoundManager.Instance._gameplaySettingPopUp);
        Time.timeScale = 0f;


        if (Player.Instance._playerTitle == Player.PlayerTitle.Normal)
        {
            _skill1Image.sprite = _listSkillIcon[2].sprite;
            _skill1Text.text = "공격력 증가";
            _skill2Image.sprite = _listSkillIcon[5].sprite;
            _skill2Text.text = "공격속도 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.MagicalBlader)
        {
            _skill1Image.sprite = _listSkillIcon[1].sprite;
            _skill1Text.text = "마력 증가";
            _skill2Image.sprite = _listSkillIcon[2].sprite;
            _skill2Text.text = "공격력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.MadMan)
        {
            _skill1Image.sprite = _listSkillIcon[2].sprite;
            _skill1Text.text = "공격력 증가";
            _skill2Image.sprite = _listSkillIcon[1].sprite;
            _skill2Text.text = "마력 증가";
            _skill3Image.sprite = _listSkillIcon[4].sprite;
            _skill3Text.text = "치명타 피해율 증가";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.StrongMan)
        {
            _skill1Image.sprite = _listSkillIcon[5].sprite;
            _skill1Text.text = "공격속도 증가";
            _skill2Image.sprite = _listSkillIcon[6].sprite;
            _skill2Text.text = "추가 공격 확률 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Warrior)
        {
            _skill1Image.sprite = _listSkillIcon[2].sprite;
            _skill1Text.text = "공격력 증가";
            _skill2Image.sprite = _listSkillIcon[3].sprite;
            _skill2Text.text = "체력 회복";
            _skill3Image.sprite = _listSkillIcon[5].sprite;
            _skill3Text.text = "공격속도 증가";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Dwarf)
        {
            _skill1Image.sprite = _listSkillIcon[7].sprite;
            _skill1Text.text = "무기공격력 증가";
            _skill2Image.sprite = _listSkillIcon[2].sprite;
            _skill2Text.text = "공격력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
        {
            _skill1Image.sprite = _listSkillIcon[8].sprite;
            _skill1Text.text = "빙결확률 증가";
            _skill2Image.sprite = _listSkillIcon[2].sprite;
            _skill2Text.text = "공격력 증가";
            _skill3Image.sprite = _listSkillIcon[5].sprite;
            _skill3Text.text = "공격속도 증가";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.AssaultCaptain)
        {
            _skill1Image.sprite = _listSkillIcon[14].sprite;
            _skill1Text.text = "체력 증가";
            _skill2Image.sprite = _listSkillIcon[2].sprite;
            _skill2Text.text = "공격력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.ZhangFei)
        {
            _skill1Image.sprite = _listSkillIcon[9].sprite;
            _skill1Text.text = "스턴 지속시간 증가";
            _skill2Image.sprite = _listSkillIcon[0].sprite;
            _skill2Text.text = "스턴 범위 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Berserker)
        {
            _skill1Image.sprite = _listSkillIcon[10].sprite;
            _skill1Text.text = "조건부 체력 증가";
            _skill2Image.sprite = _listSkillIcon[2].sprite;
            _skill2Text.text = "공격력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Critialer)
        {
            _skill1Image.sprite = _listSkillIcon[4].sprite;
            _skill1Text.text = "치명타 피해율 증가";
            _skill2Image.sprite = _listSkillIcon[2].sprite;
            _skill2Text.text = "공격력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Druid)
        {
            _skill1Image.sprite = _listSkillIcon[11].sprite;
            _skill1Text.text = "교화 확률 증가";
            _skill2Image.sprite = _listSkillIcon[5].sprite;
            _skill2Text.text = "공격속도 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Assassin)
        {
            _skill1Image.sprite = _listSkillIcon[12].sprite;
            _skill1Text.text = "치명타확률 증가";
            _skill2Image.sprite = _listSkillIcon[4].sprite;
            _skill2Text.text = "치명타 피해율 증가";
            _skill3Image.sprite = _listSkillIcon[5].sprite;
            _skill3Text.text = "공격속도 증가";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Ambidextrous)
        {
            _skill1Image.sprite = _listSkillIcon[5].sprite;
            _skill1Text.text = "공격속도 증가";
            _skill2Image.sprite = _listSkillIcon[2].sprite;
            _skill2Text.text = "공격력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.LuBu)
        {
            _skill1Image.sprite = _listSkillIcon[2].sprite;
            _skill1Text.text = "공격력 증가";
            _skill2Image.sprite = _listSkillIcon[5].sprite;
            _skill2Text.text = "공격속도 증가";
            _skill3Image.sprite = _listSkillIcon[13].sprite;
            _skill3Text.text = "심신단련";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.HeavyCavalry)
        {
            _skill1Image.sprite = _listSkillIcon[2].sprite;
            _skill1Text.text = "공격력 증가";
            _skill2Image.sprite = _listSkillIcon[5].sprite;
            _skill2Text.text = "공격속도 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.HealthMagician)
        {
            _skill1Image.sprite = _listSkillIcon[14].sprite;
            _skill1Text.text = "체력 증가";
            _skill2Image.sprite = _listSkillIcon[15].sprite;
            _skill2Text.text = "주문확률 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Priest)
        {
            _skill1Image.sprite = _listSkillIcon[17].sprite;
            _skill1Text.text = "체력회복량 증가";
            _skill2Image.sprite = _listSkillIcon[16].sprite;
            _skill2Text.text = "체력회복 확률 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Warlock)
        {
            _skill1Image.sprite = _listSkillIcon[10].sprite;
            _skill1Text.text = "조건부 체력 증가";
            _skill2Image.sprite = _listSkillIcon[1].sprite;
            _skill2Text.text = "마력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Salamander)
        {
            _skill1Image.sprite = _listSkillIcon[15].sprite;
            _skill1Text.text = "마법확률 증가";
            _skill2Image.sprite = _listSkillIcon[18].sprite;
            _skill2Text.text = "메테오 확률 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Zeus)
        {
            _skill1Image.sprite = _listSkillIcon[19].sprite;
            _skill1Text.text = "번개 전이횟수 증가";
            _skill2Image.sprite = _listSkillIcon[1].sprite;
            _skill2Text.text = "마력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.PracticeBug)
        {
            _skill1Image.sprite = _listSkillIcon[1].sprite;
            _skill1Text.text = "마력 증가";
            _skill2Image.sprite = _listSkillIcon[5].sprite;
            _skill2Text.text = "공격속도 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Stranger)
        {
            _skill1Image.sprite = _listSkillIcon[20].sprite;
            _skill1Text.text = "블랙홀마법 확률 증가";
            _skill2Image.sprite = _listSkillIcon[1].sprite;
            _skill2Text.text = "마력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Cook)
        {
            _skill1Image.sprite = _listSkillIcon[2].sprite;
            _skill1Text.text = "공격력 증가";
            _skill2Image.sprite = _listSkillIcon[17].sprite;
            _skill2Text.text = "피해흡혈량 증가";
            _skill3Image.sprite = _listSkillIcon[5].sprite;
            _skill3Text.text = "공격속도 증가";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.QRF)
        {
            _skill1Image.sprite = _listSkillIcon[5].sprite;
            _skill1Text.text = "공격속도 증가";
            _skill2Image.sprite = _listSkillIcon[2].sprite;
            _skill2Text.text = "공격력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Servant)
        {
            _skill1Image.sprite = _listSkillIcon[14].sprite;
            _skill1Text.text = "체력 증가";
            _skill2Image.sprite = _listSkillIcon[5].sprite;
            _skill2Text.text = "공격속도 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Athlete)
        {
            _skill1Image.sprite = _listSkillIcon[2].sprite;
            _skill1Text.text = "공격력 증가";
            _skill2Image.sprite = _listSkillIcon[14].sprite;
            _skill2Text.text = "체력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Versatile)
        {
            _skill1Image.sprite = _listSkillIcon[7].sprite;
            _skill1Text.text = "무기공격력 증가";
            _skill2Image.sprite = _listSkillIcon[5].sprite;
            _skill2Text.text = "공격속도 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Acupuncturist)
        {
            _skill1Image.sprite = _listSkillIcon[23].sprite;
            _skill1Text.text = "즉사 확률 증가";
            _skill2Image.sprite = _listSkillIcon[5].sprite;
            _skill2Text.text = "공격속도 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.SpoonKiller)
        {
            _skill1Image.sprite = _listSkillIcon[5].sprite;
            _skill1Text.text = "공격속도 증가";
            _skill2Image.sprite = _listSkillIcon[2].sprite;
            _skill2Text.text = "공격력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Helen)
        {
            _skill1Image.sprite = _listSkillIcon[8].sprite;
            _skill1Text.text = "빙결 확률 증가";
            _skill2Image.sprite = _listSkillIcon[0].sprite;
            _skill2Text.text = "고유스킬 범위 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Rich)
        {
            _skill1Image.sprite = _listSkillIcon[12].sprite;
            _skill1Text.text = "치명타확률 증가";
            _skill2Image.sprite = _listSkillIcon[2].sprite;
            _skill2Text.text = "공격력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Swell)
        {
            _skill1Image.sprite = _listSkillIcon[17].sprite;
            _skill1Text.text = "능력치 증가";
            _skill2Image.sprite = _listSkillIcon[3].sprite;
            _skill2Text.text = "체력 회복";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Delivery)
        {
            _skill1Image.sprite = _listSkillIcon[12].sprite;
            _skill1Text.text = "치명타확률 증가";
            _skill2Image.sprite = _listSkillIcon[5].sprite;
            _skill2Text.text = "공격속도 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Repairman)
        {
            _skill1Image.sprite = _listSkillIcon[17].sprite;
            _skill1Text.text = "체력 재생력 증가";
            _skill2Image.sprite = _listSkillIcon[5].sprite;
            _skill2Text.text = "공격속도 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Dosa)
        {
            _skill1Image.sprite = _listSkillIcon[27].sprite;
            _skill1Text.text = "분신 등장 확률 증가";
            _skill2Image.sprite = _listSkillIcon[26].sprite;
            _skill2Text.text = "분신 지능 상승";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Gambler)
        {
            _skill1Image.sprite = _listSkillIcon[17].sprite;
            _skill1Text.text = "능력치 증가";
            _skill2Image.sprite = _listSkillIcon[24].sprite;
            _skill2Text.text = "좋은 능력치 가져올 확률 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.SlowStarter)
        {
            _skill1Image.sprite = _listSkillIcon[17].sprite;
            _skill1Text.text = "능력치 증가";
            _skill2Image.sprite = _listSkillIcon[3].sprite;
            _skill2Text.text = "체력 회복";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Orpheus)
        {
            _skill1Image.sprite = _listSkillIcon[25].sprite;
            _skill1Text.text = "공격력감소버프 강화";
            _skill2Image.sprite = _listSkillIcon[2].sprite;
            _skill2Text.text = "공격력 증가";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.DokeV)
        {
            _skill1Image.sprite = _listSkillIcon[24].sprite;
            _skill1Text.text = "고유스킬 확률 증가";
            _skill2Image.sprite = _listSkillIcon[24].sprite;
            _skill2Text.text = "훔쳐오는 능력치 추가 획득";
            _skill3Image.sprite = _listSkillIcon[3].sprite;
            _skill3Text.text = "체력 회복";
        }





    }

    public void ExitChoicePopUp()
    {
        _choicePopUp.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ActiveBossHPBar()
    {
        _bossHPBar.gameObject.SetActive(true);
    }
    public void DisableBossHPBar()
    {
        _bossHPBar.gameObject.SetActive(false);
        _bossName.gameObject.SetActive(false);
    }
    

    public void ChangeStage(GameState stage)
    {
        _currentStage = stage;

        switch(stage)
        {
           
            case GameState.Stage1:
                
                

                break;
            case GameState.Stage2:
                
                break;
            case GameState.Stage3:
             
               
                break;
            case GameState.Stage4:
                
                break;
            case GameState.Result:
                break;
        }    

    }
    
   

    

    public void BossSpawn(IObjectPool<Monster> boss)
    {
        _eventHandler();
        boss.Get();
        ActiveBossHPBar();
        _bossName.gameObject.SetActive(true);

    }
    public void BossDie()
    {
        _currentStage = _currentStage + 1;
        _isBoss = false;
        _eventHandler();
        DisableBossHPBar();
        if(_currentStage != GameState.Result)
        {
             EnterChoicePopUp();
            ChangeStage();

        }
        else if(_currentStage == GameState.Result)
        {
            ActiveResultPopUp();
            if(Player.Instance._playerTitle == Player.PlayerTitle.Berserker && Player.Instance.berserkerclear == false)
            {
                Player.Instance.berserkerclear = true;
                AchievementManager.instance.Unlock("berserkerclear");
            }
            else if(Player.Instance._playerTitle == Player.PlayerTitle.Warlock && Player.Instance.warlockclear == false)
            {
                Player.Instance.warlockclear = true;
                AchievementManager.instance.Unlock("warlockclear");
            }
            else if(Player.Instance._playerTitle == Player.PlayerTitle.Athlete && Player.Instance.ahleteclear)
            {
                Player.Instance.ahleteclear = true;
                AchievementManager.instance.Unlock("ahleteclear");
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Acupuncturist && Player.Instance.acupuncturistclear)
            {
                Player.Instance.acupuncturistclear = true;
                AchievementManager.instance.Unlock("acupuncturistclear");
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SpoonKiller && Player.Instance.spoonkillerclear)
            {
                Player.Instance.spoonkillerclear = true;
                AchievementManager.instance.Unlock("spoonkillerclear");
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Helen && Player.Instance.helenclear)
            {
                Player.Instance.helenclear = true;
                AchievementManager.instance.Unlock("helenclear");
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Swell && Player.Instance.swellclear)
            {
                Player.Instance.swellclear = true;
                AchievementManager.instance.Unlock("swellclear");
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Delivery && Player.Instance.deliveryclear)
            {
                Player.Instance.deliveryclear = true;
                AchievementManager.instance.Unlock("deliveryclear");
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Repairman && Player.Instance.repairmanclear)
            {
                Player.Instance.repairmanclear = true;
                AchievementManager.instance.Unlock("repairmanclear");
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SlowStarter && Player.Instance.slowstarterclear)
            {
                Player.Instance.slowstarterclear = true;
                AchievementManager.instance.Unlock("slowstarterclear");
            }
        }
        



    }

    public IEnumerator ReverseGround()
    {
        if ((int)_currentStage >= 2)
            _listStage[(int)_currentStage - 2].SetActive(false);
        if ((int)_currentStage < 4)
            _listStage[(int)_currentStage].SetActive(true);
        _listPlayers[(int)_currentStage].gameObject.SetActive(true);
        Player.Instance._rigidbody = _listPlayers[(int)_currentStage].GetComponent<Rigidbody>();
        Player.Instance._rigidbody.isKinematic = true;
        Player.Instance._meteorPoint = Player.Instance._listMeteorPoint[(int)_currentStage];
        _listPlayers[(int)_currentStage].transform.position = new Vector3(0, 0, 0);
        _listPlayers[(int)_currentStage].transform.rotation = Quaternion.Euler(0, -180, 180);
        Player.Instance._animator = _listPlayers[(int)_currentStage].GetComponent<Animator>();
        Player.Instance.m_transform = _listPlayers[(int)_currentStage].GetComponent<Transform>();
        Player.Instance.ChangeState(BaseObject.State.None);
        Player.Instance._followCamera._target = _listPlayers[(int)_currentStage].gameObject;

        _listPlayers[(int)_currentStage].GetComponent<Rigidbody>().isKinematic = true;
        while(_ground.transform.rotation.z < 1f)
        {
            yield return new WaitForSeconds(0.05f);
            _ground.transform.Rotate(Vector3.forward * 5f);
            if(_currentStage == GameState.Stage2)
            {
                _stageground[1].transform.position = new Vector3(0, 0, 0);
            }
        }
       
        Player.Instance._rigidbody.isKinematic = false;
        _listPlayers[(int)_currentStage - 1].gameObject.SetActive(false);
        if(_currentStage == GameState.Stage2)
        {
            _stageground[0].SetActive(false);
            Camera.main.backgroundColor = new Color32(1, 34, 156, 255);
        }
        else if (_currentStage == GameState.Stage4)
        {
            _stageground[2].SetActive(false);
        }
       

        

    }
    public IEnumerator GetBackGround()
    {
        _listStage[(int)_currentStage].SetActive(true);
        _listPlayers[(int)_currentStage].gameObject.SetActive(true);
        Player.Instance._rigidbody = _listPlayers[(int)_currentStage].GetComponent<Rigidbody>();
        Player.Instance._rigidbody.isKinematic = true;
        Player.Instance._meteorPoint = Player.Instance._listMeteorPoint[(int)_currentStage];
        _listPlayers[(int)_currentStage].transform.position = new Vector3(0, 0, 0);
        _listPlayers[(int)_currentStage].transform.rotation = Quaternion.Euler(0, -180, 180);
        Player.Instance._animator = _listPlayers[(int)_currentStage].GetComponent<Animator>();
        Player.Instance.m_transform = _listPlayers[(int)_currentStage].GetComponent<Transform>();
        Player.Instance.ChangeState(BaseObject.State.None);
        Player.Instance._followCamera._target = _listPlayers[(int)_currentStage].gameObject;
        _listStage[(int)_currentStage - 2].SetActive(false);
        _listStage[(int)_currentStage].SetActive(true);
        _listPlayers[(int)_currentStage].GetComponent<Rigidbody>().isKinematic = true;
        while (_ground.transform.rotation.z > 0f)
        {
            yield return new WaitForSeconds(0.05f);
            _ground.transform.Rotate(Vector3.forward * -5f);
            _stageground[1].transform.position = new Vector3(0, -0.4f, 0);
        }
        Player.Instance._rigidbody.isKinematic = false;
     
        _listPlayers[(int)_currentStage -1].gameObject.SetActive(false);

        Camera.main.backgroundColor = new Color32(40, 40, 41, 255);
        _stageground[1].SetActive(false);
  

        
        

    }
    public void ActiveBlizzard()
    {
        _blizzard.SetActive(true);
        _blizzard.GetComponent<ParticleSystem>().Play();
        _isBlizzard = true;
    }
    public void DisableBlizzard()
    {
        _blizzard.SetActive(false);
        _isBlizzard = false;
        
    }

    public void ChangeStage()
    {
        if((int)_currentStage % 2 == 0 && (int)_currentStage != 0) //3라운드
        {
            _listStage[(int)_currentStage].SetActive(true);
            _listPlayers[(int)_currentStage].gameObject.SetActive(true);
            Player.Instance._rigidbody = _listPlayers[(int)_currentStage].GetComponent<Rigidbody>();
            Player.Instance._rigidbody.isKinematic = true;
            Player.Instance._meteorPoint = Player.Instance._listMeteorPoint[(int)_currentStage];
            StartCoroutine(GetBackGround());
            _listPlayers[(int)_currentStage].transform.position = new Vector3(0, 0, 0);
            _listPlayers[(int)_currentStage].transform.rotation = Quaternion.Euler(0, -180, 180);
            Player.Instance._animator = _listPlayers[(int)_currentStage].GetComponent<Animator>();
            Player.Instance.m_transform = _listPlayers[(int)_currentStage].GetComponent<Transform>();
            Player.Instance.ChangeState(BaseObject.State.None);
            Player.Instance._followCamera._target = _listPlayers[(int)_currentStage].gameObject;

           // StartCoroutine(CoTimer());



        }
        else if((int)_currentStage %2 == 1) // 홀수 2라운드 4라운드
        {
            
            

            StartCoroutine(ReverseGround());

          //  StartCoroutine(CoTimer());

        }
        else // 시작 1라운드
        {
           
            _listPlayers[(int)_currentStage].transform.position = new Vector3(0, 0, 0);
            _listPlayers[(int)_currentStage].transform.rotation = Quaternion.Euler(0, -180, 0);
            _listPlayers[(int)_currentStage].gameObject.SetActive(true);
            _listPlayers[(int)_currentStage + 1].gameObject.SetActive(false);
            Player.Instance._meteorPoint = Player.Instance._listMeteorPoint[0];
            Player.Instance.ChangeComponent(_listPlayers[(int)_currentStage].gameObject);
            Player.Instance.ChangeState(BaseObject.State.None);
           // Player.Instance._followCamera._target = _listPlayers[0].gameObject;
            _listStage[(int)_currentStage].SetActive(true);
            Camera.main.backgroundColor = new Color32(255, 133, 71,255);


         //   StartCoroutine(CoTimer());
        }

    }


    public void ChoiceAbility(int cnt)
    {
        if(cnt == 1)
        {
            if (Player.Instance._playerTitle == Player.PlayerTitle.Normal)
            {
               // _skill1Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.MagicalBlader)
            {
                //_skill1Text.text = "마력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.MadMan)
            {
               // _skill1Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.StrongMan)
            {
                //_skill1Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Warrior)
            {
               // _skill1Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Dwarf)
            {
                //_skill1Text.text = "무기공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
            {
                //_skill1Text.text = "빙결확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.AssaultCaptain)
            {
                //_skill1Text.text = "이동속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.ZhangFei)
            {
                //_skill1Text.text = "스턴 지속시간 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Berserker)
            {
                //_skill1Text.text = "조건부 체력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Critialer)
            {
               // _skill1Text.text = "치명타 피해율 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Druid)
            {
              //  _skill1Text.text = "교화 확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Assassin)
            {
               // _skill1Text.text = "치명타확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Ambidextrous)
            {
              //  _skill1Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.LuBu)
            {
               // _skill1Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.HeavyCavalry)
            {
               // _skill1Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.HealthMagician)
            {
               // _skill1Text.text = "체력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Priest)
            {
                //_skill1Text.text = "체력회복량 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Warlock)
            {
                //_skill1Text.text = "조건부 체력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Salamander)
            {
                //_skill1Text.text = "마법확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Zeus)
            {
               // _skill1Text.text = "번개 전이횟수 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.PracticeBug)
            {
                //_skill1Text.text = "마력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Stranger)
            {
               // _skill1Text.text = "블랙홀마법 확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Cook)
            {
               // _skill1Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.QRF)
            {
               // _skill1Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Servant)
            {
               // _skill1Text.text = "체력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Athlete)
            {
                //_skill1Text.text = "이동속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Versatile)
            {
               // _skill1Text.text = "무기공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Acupuncturist)
            {
                //_skill1Text.text = "즉사 확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SpoonKiller)
            {
               // _skill1Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Helen)
            {
               // _skill1Text.text = "빙결 확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Rich)
            {
                //_skill1Text.text = "치명타확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Swell)
            {
               // _skill1Text.text = "능력치 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Delivery)
            {
                //_skill1Text.text = "이동속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Repairman)
            {
                //_skill1Text.text = "체력 재생력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Dosa)
            {
                //_skill1Text.text = "분신 등장 확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Gambler)
            {
               // _skill1Text.text = "능력치 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SlowStarter)
            {
                //_skill1Text.text = "능력치 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Orpheus)
            {
          //      _skill1Text.text = "공격력감소버프 강화";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.DokeV)
            {
            //    _skill1Text.text = "고유스킬 확률 증가";
            }
            




            Player.Instance._skill1++;


        }
        else if (cnt == 2)
        {
            if (Player.Instance._playerTitle == Player.PlayerTitle.Normal)
            {
             //   _skill2Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.MagicalBlader)
            {
             //   _skill2Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.MadMan)
            {
             //   _skill2Text.text = "마력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.StrongMan)
            {
             //   _skill2Text.text = "추가 공격 확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Warrior)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
              //  _skill2Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Dwarf)
            {
             //   _skill2Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
            {
              //  _skill2Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.AssaultCaptain)
            {
              //  _skill2Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.ZhangFei)
            {
             //  _skill2Text.text = "스턴 범위 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Berserker)
            {
               // _skill2Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Critialer)
            {
               // _skill2Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Druid)
            {
               // _skill2Text.text = "이동속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Assassin)
            {
              //  _skill2Text.text = "치명타 피해율 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Ambidextrous)
            {
              //  _skill2Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.LuBu)
            {
               // _skill2Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.HeavyCavalry)
            {
              //  _skill2Text.text = "이동속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.HealthMagician)
            {
              //  _skill2Text.text = "주문확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Priest)
            {
               // _skill2Text.text = "체력회복 확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Warlock)
            {
              //  _skill2Text.text = "마력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Salamander)
            {
               // _skill2Text.text = "메테오 확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Zeus)
            {
              //  _skill2Text.text = "마력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.PracticeBug)
            {
              //  _skill2Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Stranger)
            {
              //  _skill2Text.text = "마력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Cook)
            {
              //  _skill2Text.text = "피해흡혈량 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.QRF)
            {
              //  _skill2Text.text = "이동속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Servant)
            {
               // _skill2Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Athlete)
            {
              //  _skill2Text.text = "체력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Versatile)
            {
               // _skill2Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Acupuncturist)
            {
                //_skill2Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SpoonKiller)
            {
               // _skill2Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Helen)
            {
               // _skill2Text.text = "고유스킬 범위 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Rich)
            {
              //  _skill2Text.text = "이동속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Swell)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Delivery)
            {
               // _skill2Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Repairman)
            {
               // _skill2Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Dosa)
            {
              //  _skill2Text.text = "분신 지능 상승";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Gambler)
            {
              //  _skill2Text.text = "좋은 능력치 가져올 확률 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SlowStarter)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Orpheus)
            {
               // _skill2Text.text = "공격력 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.DokeV)
            {
               // _skill2Text.text = "훔쳐오는 능력치 추가 획득";
            }











            Player.Instance._skill2++;

        }
        else if(cnt ==3)
        {

            if (Player.Instance._playerTitle == Player.PlayerTitle.Normal)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //_skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.MagicalBlader)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                // _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.MadMan)
            {
               
             //   _skill3Text.text = "치명타 피해율 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.StrongMan)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //_skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Warrior)
            {
                
                //공격속도증가
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Dwarf)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                // _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
            {
               
                //_skill3Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.AssaultCaptain)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //_skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.ZhangFei)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //_skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Berserker)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //_skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Critialer)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Druid)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                // _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Assassin)
            {
               
              //  _skill3Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Ambidextrous)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                // _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.LuBu)
            {
                
               // _skill3Text.text = "심신단련";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.HeavyCavalry)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.HealthMagician)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //   _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Priest)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                // _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Warlock)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                // _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Salamander)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                // _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Zeus)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //   _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.PracticeBug)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                // _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Stranger)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Cook)
            {
               
               // _skill3Text.text = "공격속도 증가";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.QRF)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Servant)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                // _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Athlete)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Versatile)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Acupuncturist)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                // _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SpoonKiller)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Helen)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Rich)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Swell)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                // _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Delivery)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Repairman)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Dosa)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                // _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Gambler)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                // _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SlowStarter)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Orpheus)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.DokeV)
            {
                Player.Instance._ingameHp = Player.Instance._maxHp;
                //  _skill3Text.text = "체력 회복";
            }




            Player.Instance._skill3++;

        }

        SoundManager.Instance.EffectPlay(SoundManager.Instance._pop);
        _choicePopUp.SetActive(false);
        ChangeStage(_currentStage);
        Time.timeScale = 1f;
        if(Player.Instance._playerTitle != Player.PlayerTitle.Priest)
        {
            Player.Instance.HiddenSkill(Player.Instance._playerTitle);

        }
    }



    public IEnumerator CoTimer()
    {
        StartCoroutine(CoReSpawn());
        if(_currentStage == GameState.Stage1 && _isBoss == false)
        {
            _timer = 90f;
        }
        else if(_currentStage == GameState.Stage2 && _isBoss == false)
        {
            _timer = 90f;
        }
        else if(_currentStage == GameState.Stage3 && _isBoss == false)
        {
            _timer = 90f;
        }
        else if (_currentStage == GameState.Stage4 && _isBoss == false)
        {
            _timer = 90f;
        }

        while (_timer >= 0)
        {
            _timer -= Time.deltaTime;

            yield return null;
            _min = (int)_timer / 60;
            _sec = ((int)_timer - _min * 60) % 60;

            if (_timer <= 0)
            {
                _timer = 0;
                _timerMin.text = 0.ToString();
                _timerSec.text = 0.ToString();
               
                break;
                
            }
            else
            {
                if(_sec > 60)
                {
                    _min += 1;
                    _sec -= 60;
                }
                else
                {
                    _timerMin.text = _min.ToString();
                    _timerSec.text = _sec.ToString();
                    
                }
            }

        }

        yield return new WaitForSeconds(1f);

        if (_currentStage == GameState.Stage1)
        {
            BossSpawn(_captainSkullPool);
            _bossName.text = "대장 해골";
        }
        else if (_currentStage == GameState.Stage2)
        {
            BossSpawn(_wolfkingPool);
            _bossName.text = "왕건이 늑대";
        }
        else if (_currentStage == GameState.Stage3)
        {
            BossSpawn(_captainSkullPool);
            _bossName.text = "대장 해골";
        }
        else if (_currentStage == GameState.Stage4)
        {
            BossSpawn(_wolfkingPool);
            _bossName.text = "왕건이 늑대";
        }
    }



    public int[] GetRandomInt(int length, int min, int max)
    {
        int[] randarray = new int[length];
        bool isSame;

        for(int i = 0; i < length; ++i)
        {
            while(true)
            {
                randarray[i] = Random.Range(min, max);
                isSame = false;
                for(int j = 0; j <i; ++j)
                {
                    if(randarray[j] == randarray[i])
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame) break;
            }
        }
        return randarray;
    }
    public IEnumerator CoReSpawn()
    {


        yield return new WaitForSeconds(3f);
        if (_currentStage == GameState.Stage1)
        {
            int rand = Random.Range(0, 3);
            if (rand == 0)
            {
                _slimePool.Get();

            }
            else if (rand == 1)
            {
                _wolfpool.Get();
            }
            else if (rand == 2)
            {
                _skeletonPool.Get();
            }

            SoundManager.Instance.EffectPlay(SoundManager.Instance._spawn);
        }
        else if (_currentStage == GameState.Stage2)
        {
            int rand = Random.Range(0, 4);
            if (rand == 0)
            {
                _slimePool.Get();

            }
            else if (rand == 1)
            {
                _wolfpool.Get();
            }
            else if (rand == 2)
            {
                _skeletonPool.Get();
            }
            else if (rand == 3)
            {
                _captainSkullNormalPool.Get();
            }
            SoundManager.Instance.EffectPlay(SoundManager.Instance._spawn);
        }
        else if (_currentStage == GameState.Stage3)
        {
            int rand = Random.Range(0, 5);
            if (rand == 0)
            {
                _slimePool.Get();

            }
            else if (rand == 1)
            {
                _wolfpool.Get();
            }
            else if (rand == 2)
            {
                _skeletonPool.Get();
            }
            else if (rand == 3)
            {
                _captainSkullNormalPool.Get();
            }
            else if (rand == 4)
            {
                _wolfkingNormalPool.Get();
            }
            SoundManager.Instance.EffectPlay(SoundManager.Instance._spawn);
        }
        else if (_currentStage == GameState.Stage4)
        {
            int rand = Random.Range(0, 5);
            if (rand == 0)
            {
                _slimePool.Get();

            }
            else if (rand == 1)
            {
                _wolfpool.Get();
            }
            else if (rand == 2)
            {
                _skeletonPool.Get();
            }
            else if (rand == 3)
            {
                _captainSkullNormalPool.Get();
            }
            else if (rand == 4)
            {
                _wolfkingNormalPool.Get();
            }
            SoundManager.Instance.EffectPlay(SoundManager.Instance._spawn);
        }
        yield return new WaitForSeconds(8 - (int)_currentStage);

        while (_isBoss == false)
        {
            yield return new WaitForSeconds(8 - (int)_currentStage);
            if (_currentStage == GameState.Stage1)
            {
                int rand = Random.Range(0, 3);
                if (rand == 0)
                {
                    _slimePool.Get();

                }
                else if (rand == 1)
                {
                    _wolfpool.Get();
                }
                else if (rand == 2)
                {
                    _skeletonPool.Get();
                }

                SoundManager.Instance.EffectPlay(SoundManager.Instance._spawn);
            }
            else if (_currentStage == GameState.Stage2)
            {
                int rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    _slimePool.Get();

                }
                else if (rand == 1)
                {
                    _wolfpool.Get();
                }
                else if (rand == 2)
                {
                    _skeletonPool.Get();
                }
                else if (rand == 3)
                {
                    _captainSkullNormalPool.Get();
                }
                SoundManager.Instance.EffectPlay(SoundManager.Instance._spawn);
            }
            else if (_currentStage == GameState.Stage3)
            {
                int rand = Random.Range(0, 5);
                if (rand == 0)
                {
                    _slimePool.Get();

                }
                else if (rand == 1)
                {
                    _wolfpool.Get();
                }
                else if (rand == 2)
                {
                    _skeletonPool.Get();
                }
                else if (rand == 3)
                {
                    _captainSkullNormalPool.Get();
                }
                else if (rand == 4)
                {
                    _wolfkingNormalPool.Get();
                }
                SoundManager.Instance.EffectPlay(SoundManager.Instance._spawn);
            }
            else if (_currentStage == GameState.Stage4)
            {
                int rand = Random.Range(0, 5);
                if (rand == 0)
                {
                    _slimePool.Get();

                }
                else if (rand == 1)
                {
                    _wolfpool.Get();
                }
                else if (rand == 2)
                {
                    _skeletonPool.Get();
                }
                else if (rand == 3)
                {
                    _captainSkullNormalPool.Get();
                }
                else if (rand == 4)
                {
                    _wolfkingNormalPool.Get();
                }
                SoundManager.Instance.EffectPlay(SoundManager.Instance._spawn);
            }
        }
    }


    public IEnumerator coStart()
    {
        yield return new WaitForSeconds(2f);
        ChangeStage();

    }

}
