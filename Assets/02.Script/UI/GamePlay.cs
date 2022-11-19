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
    public GameObject _creepScoreText;
    public Monster _wolf;
    public Monster _slime;
    public Monster _captainSkull;
    public Monster _golem;
    public Monster _dragon;
    public Monster _demonKing;
    public GameObject _objectPool;
    public GameObject _damageTextPoolParent;
    public GameObject _spawnZone;
    public RespawnZone _randomSpawn;
    public LightningBoltScript _lightning;
    public GameObject _meteorTarget;
    public SkillBase _meteor;
    public SkillBase _wall;
    public Decoy _decoy;
    public SkillBase _blackHole;
    public SkillBase _frozen;
    public SkillBase _roar;
    public SkillBase _heal;
    public SkillBase _meteorEffect;

    public List<GameObject> _listPlayers = new List<GameObject>();


    
    
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

   


    public DamageText _damageText;

    private IObjectPool<Monster> _wolfpool;
    private IObjectPool<Monster> _slimePool;
    private IObjectPool<Monster> _captainSkullPool;
    private IObjectPool<Monster> _golemPool;
    private IObjectPool<Monster> _dragonPool;
    private IObjectPool<Monster> _demonkingPool;
    public IObjectPool<DamageText> _damageTextPool;
    public IObjectPool<LightningBoltScript> _lightningPool;
    public IObjectPool<GameObject> _meteorTargetPool;
    public IObjectPool<SkillBase> _meteorPool;
    public IObjectPool<SkillBase> _wallPool;
    public IObjectPool<Decoy> _decoyPool;
    public IObjectPool<SkillBase> _blackHolePool;
    public IObjectPool<SkillBase> _fireBallPool;
    public IObjectPool<SkillBase> _frozenPool;
    public IObjectPool<SkillBase> _roarPool;
    public IObjectPool<SkillBase> _healPool;
    public IObjectPool<SkillBase> _meteorEffectPool;



    public GameState _currentStage;

    public bool _collectionChecks = true;
    public int _maxPoolSize = 5;
    public float[] _percent = {30,50,20};


    public delegate void EventHandler();

    public static event EventHandler _eventHandler;

    public MoreMountains.Tools.MMProgressBar _test;

    public TextMeshProUGUI _timerMin,_timerSec;
    public float _timer;
    public int _min, _sec;

    public Image _skill1Image;
    public Image _skill2Image;
    public Image _skill3Image;

    public TextMeshProUGUI _skill1Text;
    public TextMeshProUGUI _skill2Text;
    public TextMeshProUGUI _skill3Text;




    private void Awake()
    {
        Instance = this;

        _slimePool = new ObjectPool<Monster>(CreatSlime,OngetMonster,OnReleaseMonster,OnDestroyMonster,maxSize : 10);
        _wolfpool = new ObjectPool<Monster>(CreatWolf, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);
        _captainSkullPool = new ObjectPool<Monster>(CreatCaptainSkull, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);
        _golemPool = new ObjectPool<Monster>(CreatGolem, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);
        _dragonPool = new ObjectPool<Monster>(CreatDragon, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);
        _demonkingPool = new ObjectPool<Monster>(CreatDemonKing, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);
        _damageTextPool = new ObjectPool<DamageText>(CreatDamageText, OngetDamageText, OnRelaseText, OnDestroyText, maxSize: 10);
        _lightningPool = new ObjectPool<LightningBoltScript>(CreateLightning, OngetLightningBolt, OnRelaseLightning, OnDestroyLightning, maxSize: 30);
        _meteorTargetPool = new ObjectPool<GameObject>(CreatMeteorTarget, OngetMeteorTarget, OnReleaseMeteorTarget, OnDestroyMeteorTarget, maxSize: 10);
        _meteorPool = new ObjectPool<SkillBase>(CreateMeteor, OngetMeteor, OnReleaseSkill, OnDestroySkill, maxSize: 10);
        _wallPool = new ObjectPool<SkillBase>(CreateWall, OngetSkill, OnReleaseSkill, OnDestroySkill, maxSize: 20);
        _decoyPool = new ObjectPool<Decoy>(CreateDecoy, OngetDecoy, OnReleaseDecoy, OnDestroyDecoy, maxSize: 20);
        _blackHolePool = new ObjectPool<SkillBase>(CreateBlackHole, OngetSkill, OnReleaseSkill, OnDestroySkill, maxSize: 10);
        _fireBallPool = new ObjectPool<SkillBase>(CreateFireBall, OngetSkill, OnReleaseSkill, OnDestroySkill, maxSize: 10);
        _frozenPool = new ObjectPool<SkillBase>(CreateFrozen, OngetFrozen, OnReleaseSkill, OnDestroySkill, maxSize: 30);
        _roarPool = new ObjectPool<SkillBase>(CreateRoar, OngetRoar, OnReleaseRoar, OnDestroySkill, maxSize: 10);
        _healPool = new ObjectPool<SkillBase>(CreateHeal, OngetEffectSkill, OnReleaseSkill, OnDestroySkill, maxSize: 20);
        _meteorEffectPool = new ObjectPool<SkillBase>(CreateMeteorEffect, OngetSkill, OnReleaseSkill, OnDestroySkill, maxSize: 20);

        _bossHPBar.SetActive(false);

        for (int i = 1; i < _listStage.Count; ++i)
        {
            _listStage[i].SetActive(false);
        }
       // _totalCreepScore = _stage1CreepScore + _stage2CreepScore + _stage3CreepScore + _stage4CreepScore;

    }

    private void Start()
    {
        StartCoroutine(CoTimer());
    }

    private void Update()
    {
        
        _creepScoreText.GetComponent<TextMeshProUGUI>().text = Player.Instance._totalCreepScore.ToString();
      
       

        



        if (Input.GetKeyDown(KeyCode.R))
        {
            _eventHandler();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _test.Minus10Percent(200f,5f);
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _stage1CreepScore += 1;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    _stage2CreepScore += 1;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    _stage3CreepScore += 1;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    _stage4CreepScore += 1;
        //}
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeStage();
        }
       







        if (Input.GetKeyDown(KeyCode.G))
        {
            EnterChoicePopUp();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeStage(GameState.Stage2);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            ChangeStage(GameState.Stage3);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ChangeStage(GameState.Stage4);
        }







    }

    private Monster CreatSlime()
    {
        var monster = Instantiate(_slime, _randomSpawn.Return_RandomPosition(), Quaternion.identity,_objectPool.transform);
        monster.SetPool(_slimePool);
        return monster;
    }
    private Monster CreatWolf()
    {
        var monster = Instantiate(_wolf, _randomSpawn.Return_RandomPosition() ,Quaternion.identity, _objectPool.transform);
        monster.SetPool(_wolfpool);
        return monster;
    }
    private Monster CreatCaptainSkull()
    {
        var monster = Instantiate(_captainSkull, _randomSpawn.Return_RandomPosition(), Quaternion.identity, _objectPool.transform);
        monster.SetPool(_captainSkullPool);
        return monster;
    }
    private Monster CreatGolem()
    {
        var monster = Instantiate(_golem, _randomSpawn.Return_RandomPosition(), Quaternion.identity, _objectPool.transform);
        monster.SetPool(_golemPool);
        return monster;
    }
    private Monster CreatDragon()
    {
        var monster = Instantiate(_dragon, _randomSpawn.Return_RandomPosition(), Quaternion.identity, _objectPool.transform);
        monster.SetPool(_dragonPool);
        return monster;
    }
    private Monster CreatDemonKing()
    {
        var monster = Instantiate(_demonKing, _randomSpawn.Return_RandomPosition(), Quaternion.identity, _objectPool.transform);
        monster.SetPool(_demonkingPool);
        return monster;
    }
    private DamageText CreatDamageText()
    {
        var damagetext = Instantiate(_damageText, _damageTextPoolParent.transform);
        damagetext.SetPool(_damageTextPool);
        return damagetext;
    }
    private LightningBoltScript CreateLightning()
    {
        var lightning = Instantiate(_lightning, _randomSpawn.Return_RandomPosition(), Quaternion.identity, _objectPool.transform);
        lightning.SetPool(_lightningPool);
        return lightning;
    }
    private GameObject CreatMeteorTarget()
    {
        var target = Instantiate(_meteorTarget, Player.Instance._meteorPoint.transform.position, Quaternion.identity, _objectPool.transform);
        _listMeteorTarget.Add(target);
        _meteorPool.Get();
        StartCoroutine(_listMeteor[0].GetComponent<Meteor>().Target(target));
        
        
        return target;
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
    private Decoy CreateDecoy()
    {
        var decoy = Instantiate(_decoy, _randomSpawn.Return_RandomPosition(), Quaternion.identity, _objectPool.transform);
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
        return meteorEffect;
    }



    // ���� ���� ��
    private void OngetMonster(Monster obj)
    {
        obj.gameObject.SetActive(true);
        obj._layerMask = 6;
        if(obj._monster == Monster.MonsterKind.Slime)
        {
            obj._hp = 10f;
            obj._speed = 1f;
            obj.StartCoroutine(obj.CoFindEnemy());
            obj.FadeIn();
        }
        if(obj._monster == Monster.MonsterKind.CaptainSkull && _isBoss == false && _currentStage == GameState.Stage1 && obj._category == Monster.MonsterCategory.Boss)
        {
            obj._hp = 2f;
            _isBoss = true;
            
        }
        if (obj._monster == Monster.MonsterKind.Golem && _isBoss == false && _currentStage == GameState.Stage2 && obj._category == Monster.MonsterCategory.Boss)
        {
            obj._hp = 2f;
            _isBoss = true;

        }
        if (obj._monster == Monster.MonsterKind.Dragon && _isBoss == false && _currentStage == GameState.Stage3 && obj._category == Monster.MonsterCategory.Boss)
        {
            obj._hp = 2f;
            _isBoss = true;

        }
        if (obj._monster == Monster.MonsterKind.DemonKing && _isBoss == false && _currentStage == GameState.Stage4 && obj._category == Monster.MonsterCategory.Boss)
        {
            obj._hp = 2f;
            _isBoss = true;

        }
        obj.transform.position = _randomSpawn.Return_RandomPosition();
    }

    private void OngetDamageText(DamageText text)
    {
        text.gameObject.SetActive(true);
    }
    private void OngetLightningBolt(LightningBoltScript lightning)
    {
        lightning.gameObject.SetActive(true);
    }
    private void OngetMeteorTarget(GameObject obj)
    {
        obj.gameObject.SetActive(true);
        
    }
    private void OngetFrozen(SkillBase obj)
    {
        obj.gameObject.SetActive(true);
    }
    private void OngetMeteor(SkillBase meteor)
    {

        meteor.gameObject.SetActive(true);
        meteor.transform.position = Player.Instance.m_transform.position + new Vector3(0, 10, 0);


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
        skill.transform.position = Player.Instance._meteorPoint.transform.position ;
        
        skill.gameObject.SetActive(true);
    }
    private void OngetSkill(SkillBase skill)
    {
        skill.transform.position = Player.Instance._meteorPoint.transform.position + new Vector3(0, 0.5f, 0);
        skill.transform.rotation = Player.Instance.m_transform.rotation;
        skill.gameObject.SetActive(true);
    }
    private void OngetDecoy(Decoy decoy)
    {
        decoy.gameObject.SetActive(true);
    }
    private void OngetEffectSkill(SkillBase skill)
    {
        skill.transform.position = Player.Instance.m_transform.position + new Vector3(0, 0.5f, 0);
        skill.transform.rotation = Quaternion.Euler(30, 0, 0);
        skill.gameObject.SetActive(true);
    }
    // ��ȯ�Ҷ� �������

    private void OnReleaseMonster(Monster obj)
    {
        Player.Instance._totalCreepScore++;
        if(Player.Instance._totalCreepScore >= 1 && Player.Instance.firsthunt == false)
        {
            Player.Instance.firsthunt = true;
            AchievementManager.instance.Unlock("firsthunt");
        }


        obj.gameObject.SetActive(false);
      
    }

    private void OnRelaseText(DamageText text)
    {
        text.gameObject.SetActive(false);
    }
    private void OnRelaseLightning(LightningBoltScript lightning)
    {
        lightning.gameObject.SetActive(false);
    }
    private void OnReleaseMeteorTarget(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnReleaseSkill(SkillBase skill)
    {
        skill.gameObject.SetActive(false);
    }
    private void OnReleaseDecoy(Decoy decoy)
    {
        decoy.gameObject.SetActive(false);
    }
    private void OnReleaseRoar(SkillBase skill)
    {
        skill.gameObject.SetActive(false);
    }

    //Ǯ�� ������ ��������
    private void OnDestroyMonster(Monster obj)
    {
        Destroy(obj.gameObject);
    }

    private void OnDestroyText(DamageText text)
    {
        Destroy(text.gameObject);
    }
    private void OnDestroyLightning(LightningBoltScript lightning)
    {
        Destroy(lightning.gameObject);
    }
    private void OnDestroyMeteorTarget(GameObject obj)
    {
        Destroy(obj.gameObject);
    }
    private void OnDestroySkill(SkillBase skill)
    {
        Destroy(skill.gameObject);
    }
    private void OnDestroyDecoy(Decoy decoy)
    {
        Destroy(decoy.gameObject);
    }
    


    public void EnterLobby()
    {
        Time.timeScale = 1f;
        LoadSceneManager.LoadScene("Lobby");
    }

    public void ActiveResultPopUp()
    {
        Time.timeScale = 0f;
        _resultPopUp.gameObject.SetActive(true);
    }

    public void EnterPausePopUp()
    {
        _pausePopUp.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ExitPausePopUp()
    {
        _pausePopUp.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void EnterChoicePopUp()
    {
        _choicePopUp.gameObject.SetActive(true);
        Time.timeScale = 0f;


        if (Player.Instance._playerTitle == Player.PlayerTitle.Normal)
        {
            _skill1Image = _listSkillIcon[0];
            _skill1Text.text = "���ݷ� ����";
            _skill2Image = _listSkillIcon[0];
            _skill2Text.text = "���ݼӵ� ����";
            _skill3Image = _listSkillIcon[0];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.MagicalBlader)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݷ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.MadMan)
        {
            _skill1Image = _listSkillIcon[0];
            _skill1Text.text = "���ݷ� ����";
            _skill2Image = _listSkillIcon[0];
            _skill2Text.text = "���� ����";
            _skill3Image = _listSkillIcon[0];
            _skill3Text.text = "ġ��Ÿ ������ ����";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.StrongMan)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���ݼӵ� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "�߰� ���� Ȯ�� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Warrior)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���ݷ� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "ü�� ȸ��";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "��� ȹ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Dwarf)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "������ݷ� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݷ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "����Ȯ�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݷ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "���ݼӵ� ����";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.AssaultCaptain)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "�̵��ӵ� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݷ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.ZhangFei)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���� ���ӽð� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���� ���� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Berserker)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���Ǻ� ü�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݷ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Critialer)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "ġ��Ÿ ������ ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݷ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Druid)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "��ȭ Ȯ�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "�̵��ӵ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Assassin)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "ġ��ŸȮ�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "ġ��Ÿ ������ ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "���ݼӵ� ����";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Ambidextrous)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���ݼӵ� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݷ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.LuBu)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���ݷ� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݼӵ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "�ɽŴܷ�";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.HeavyCavalry)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���ݷ� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "�̵��ӵ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.HealthMagician)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "ü�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "�ֹ�Ȯ�� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Priest)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "ü��ȸ���� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "ü��ȸ�� Ȯ�� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Warlock)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���Ǻ� ü�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Salamander)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "����Ȯ�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���׿� Ȯ�� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Zeus)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���� ����Ƚ�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.PracticeBug)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݼӵ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Stranger)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "��Ȧ���� Ȯ�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Cook)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���ݷ� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���������� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "���ݼӵ� ����";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.QRF)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���ݼӵ� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "�̵��ӵ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Servant)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "ü�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݼӵ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Athlete)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "�̵��ӵ� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "ü�� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Versatile)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "������ݷ� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݼӵ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Acupuncturist)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "��� Ȯ�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݼӵ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.SpoonKiller)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���ݼӵ� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݷ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Helen)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���� Ȯ�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "������ų ���� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Rich)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "ġ��ŸȮ�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "�̵��ӵ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Swell)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "�ɷ�ġ ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "��� ȹ��";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Delivery)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "�̵��ӵ� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݼӵ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Repairman)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "ü�� ����� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݼӵ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Dosa)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "�н� ���� Ȯ�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "�н� ���� ���";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Gambler)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "�ɷ�ġ ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���� �ɷ�ġ ������ Ȯ�� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.SlowStarter)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "�ɷ�ġ ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "��� ȹ��";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Orpheus)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "���ݷ°��ҹ��� ��ȭ";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���ݷ� ����";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.DokeV)
        {
            _skill1Image = _listSkillIcon[1];
            _skill1Text.text = "������ų Ȯ�� ����";
            _skill2Image = _listSkillIcon[1];
            _skill2Text.text = "���Ŀ��� �ɷ�ġ �߰� ȹ��";
            _skill3Image = _listSkillIcon[1];
            _skill3Text.text = "ü�� ȸ��";
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
    }

    public void DamageTextOn(DamageText damagetext,string str, Vector3 worldPosition)
    {
        damagetext.RequestDamageText(str,worldPosition);
    }

    public void SetValue(float value, Material materials)
    {
        materials.SetFloat("_Dissolve", value);
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
                ActiveResultPopUp();
                break;
        }    

    }
    
   

    

    public void BossSpawn(IObjectPool<Monster> boss)
    {
        boss.Get();
        ActiveBossHPBar();

    }
    public void BossDie(GameState state)
    {
        _isBoss = false;
        _eventHandler();
        DisableBossHPBar();
        if(state != GameState.Result)
        {
             EnterChoicePopUp();

        }
        
        ChangeStage(state);
        
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
        Debug.Log("�������׶���");
        while(_ground.transform.rotation.z < 1f)
        {
            yield return new WaitForSeconds(0.05f);
            _ground.transform.Rotate(Vector3.forward * 5f);
        }

        Player.Instance._rigidbody.isKinematic = false;
        _listPlayers[(int)_currentStage - 1].gameObject.SetActive(false);
       

        

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
        Debug.Log("�ٹ�");
        while (_ground.transform.rotation.z > 0f)
        {
            yield return new WaitForSeconds(0.05f);
            _ground.transform.Rotate(Vector3.forward * -5f);
        }
        Player.Instance._rigidbody.isKinematic = false;
        _listPlayers[(int)_currentStage -1].gameObject.SetActive(false);
  

        
        

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
        if((int)_currentStage % 2 == 0 && (int)_currentStage != 0) //3����
        {
            Debug.Log("3��");
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
            
            

        }
        else if((int)_currentStage %2 == 1) // Ȧ�� 2���� 4����
        {
            
            StartCoroutine(ReverseGround());
            
            Debug.Log("24��");

        }
        else // ���� 1����
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
           
            Debug.Log("1��");
        }
        

    }


    public void ChoiceAbility(int cnt)
    {
        if(cnt == 1)
        {
            if (Player.Instance._playerTitle == Player.PlayerTitle.Normal)
            {
               // _skill1Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.MagicalBlader)
            {
                //_skill1Text.text = "���� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.MadMan)
            {
               // _skill1Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.StrongMan)
            {
                //_skill1Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Warrior)
            {
               // _skill1Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Dwarf)
            {
                //_skill1Text.text = "������ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
            {
                //_skill1Text.text = "����Ȯ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.AssaultCaptain)
            {
                //_skill1Text.text = "�̵��ӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.ZhangFei)
            {
                //_skill1Text.text = "���� ���ӽð� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Berserker)
            {
                //_skill1Text.text = "���Ǻ� ü�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Critialer)
            {
               // _skill1Text.text = "ġ��Ÿ ������ ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Druid)
            {
              //  _skill1Text.text = "��ȭ Ȯ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Assassin)
            {
               // _skill1Text.text = "ġ��ŸȮ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Ambidextrous)
            {
              //  _skill1Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.LuBu)
            {
               // _skill1Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.HeavyCavalry)
            {
               // _skill1Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.HealthMagician)
            {
               // _skill1Text.text = "ü�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Priest)
            {
                //_skill1Text.text = "ü��ȸ���� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Warlock)
            {
                //_skill1Text.text = "���Ǻ� ü�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Salamander)
            {
                //_skill1Text.text = "����Ȯ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Zeus)
            {
               // _skill1Text.text = "���� ����Ƚ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.PracticeBug)
            {
                //_skill1Text.text = "���� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Stranger)
            {
               // _skill1Text.text = "��Ȧ���� Ȯ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Cook)
            {
               // _skill1Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.QRF)
            {
               // _skill1Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Servant)
            {
               // _skill1Text.text = "ü�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Athlete)
            {
                //_skill1Text.text = "�̵��ӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Versatile)
            {
               // _skill1Text.text = "������ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Acupuncturist)
            {
                //_skill1Text.text = "��� Ȯ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SpoonKiller)
            {
               // _skill1Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Helen)
            {
               // _skill1Text.text = "���� Ȯ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Rich)
            {
                //_skill1Text.text = "ġ��ŸȮ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Swell)
            {
               // _skill1Text.text = "�ɷ�ġ ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Delivery)
            {
                //_skill1Text.text = "�̵��ӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Repairman)
            {
                //_skill1Text.text = "ü�� ����� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Dosa)
            {
                //_skill1Text.text = "�н� ���� Ȯ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Gambler)
            {
               // _skill1Text.text = "�ɷ�ġ ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SlowStarter)
            {
                //_skill1Text.text = "�ɷ�ġ ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Orpheus)
            {
          //      _skill1Text.text = "���ݷ°��ҹ��� ��ȭ";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.DokeV)
            {
            //    _skill1Text.text = "������ų Ȯ�� ����";
            }
            




            Player.Instance._skill1++;

        }
        else if (cnt == 2)
        {
            if (Player.Instance._playerTitle == Player.PlayerTitle.Normal)
            {
             //   _skill2Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.MagicalBlader)
            {
             //   _skill2Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.MadMan)
            {
             //   _skill2Text.text = "���� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.StrongMan)
            {
             //   _skill2Text.text = "�߰� ���� Ȯ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Warrior)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill2Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Dwarf)
            {
             //   _skill2Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
            {
              //  _skill2Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.AssaultCaptain)
            {
              //  _skill2Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.ZhangFei)
            {
             //  _skill2Text.text = "���� ���� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Berserker)
            {
               // _skill2Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Critialer)
            {
               // _skill2Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Druid)
            {
               // _skill2Text.text = "�̵��ӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Assassin)
            {
              //  _skill2Text.text = "ġ��Ÿ ������ ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Ambidextrous)
            {
              //  _skill2Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.LuBu)
            {
               // _skill2Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.HeavyCavalry)
            {
              //  _skill2Text.text = "�̵��ӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.HealthMagician)
            {
              //  _skill2Text.text = "�ֹ�Ȯ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Priest)
            {
               // _skill2Text.text = "ü��ȸ�� Ȯ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Warlock)
            {
              //  _skill2Text.text = "���� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Salamander)
            {
               // _skill2Text.text = "���׿� Ȯ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Zeus)
            {
              //  _skill2Text.text = "���� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.PracticeBug)
            {
              //  _skill2Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Stranger)
            {
              //  _skill2Text.text = "���� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Cook)
            {
              //  _skill2Text.text = "���������� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.QRF)
            {
              //  _skill2Text.text = "�̵��ӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Servant)
            {
               // _skill2Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Athlete)
            {
              //  _skill2Text.text = "ü�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Versatile)
            {
               // _skill2Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Acupuncturist)
            {
                //_skill2Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SpoonKiller)
            {
               // _skill2Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Helen)
            {
               // _skill2Text.text = "������ų ���� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Rich)
            {
              //  _skill2Text.text = "�̵��ӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Swell)
            {
                _skill2Text.text = "��� ȹ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Delivery)
            {
               // _skill2Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Repairman)
            {
               // _skill2Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Dosa)
            {
              //  _skill2Text.text = "�н� ���� ���";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Gambler)
            {
              //  _skill2Text.text = "���� �ɷ�ġ ������ Ȯ�� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SlowStarter)
            {
                _skill2Text.text = "��� ȹ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Orpheus)
            {
               // _skill2Text.text = "���ݷ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.DokeV)
            {
               // _skill2Text.text = "���Ŀ��� �ɷ�ġ �߰� ȹ��";
            }











            Player.Instance._skill2++;
        }
        else if(cnt ==3)
        {

            if (Player.Instance._playerTitle == Player.PlayerTitle.Normal)
            {
                Player.Instance._hp = Player.Instance._maxHp;
                //_skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.MagicalBlader)
            {
                Player.Instance._hp = Player.Instance._maxHp;
               // _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.MadMan)
            {
               
             //   _skill3Text.text = "ġ��Ÿ ������ ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.StrongMan)
            {
                Player.Instance._hp = Player.Instance._maxHp;
                //_skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Warrior)
            {
                
                _skill3Text.text = "��� ȹ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Dwarf)
            {
                Player.Instance._hp = Player.Instance._maxHp;
               // _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.JackFrost)
            {
               
                //_skill3Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.AssaultCaptain)
            {
                Player.Instance._hp = Player.Instance._maxHp;
                //_skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.ZhangFei)
            {
                Player.Instance._hp = Player.Instance._maxHp;
                //_skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Berserker)
            {
                Player.Instance._hp = Player.Instance._maxHp;
                //_skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Critialer)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Druid)
            {
                Player.Instance._hp = Player.Instance._maxHp;
               // _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Assassin)
            {
               
              //  _skill3Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Ambidextrous)
            {
                Player.Instance._hp = Player.Instance._maxHp;
               // _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.LuBu)
            {
                
               // _skill3Text.text = "�ɽŴܷ�";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.HeavyCavalry)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.HealthMagician)
            {
                Player.Instance._hp = Player.Instance._maxHp;
             //   _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Priest)
            {
                Player.Instance._hp = Player.Instance._maxHp;
               // _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Warlock)
            {
                Player.Instance._hp = Player.Instance._maxHp;
               // _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Salamander)
            {
                Player.Instance._hp = Player.Instance._maxHp;
               // _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Zeus)
            {
                Player.Instance._hp = Player.Instance._maxHp;
             //   _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.PracticeBug)
            {
                Player.Instance._hp = Player.Instance._maxHp;
               // _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Stranger)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Cook)
            {
               
               // _skill3Text.text = "���ݼӵ� ����";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.QRF)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Servant)
            {
                Player.Instance._hp = Player.Instance._maxHp;
               // _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Athlete)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Versatile)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Acupuncturist)
            {
                Player.Instance._hp = Player.Instance._maxHp;
               // _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SpoonKiller)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Helen)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Rich)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Swell)
            {
                Player.Instance._hp = Player.Instance._maxHp;
               // _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Delivery)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Repairman)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Dosa)
            {
                Player.Instance._hp = Player.Instance._maxHp;
               // _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Gambler)
            {
                Player.Instance._hp = Player.Instance._maxHp;
               // _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.SlowStarter)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.Orpheus)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }
            else if (Player.Instance._playerTitle == Player.PlayerTitle.DokeV)
            {
                Player.Instance._hp = Player.Instance._maxHp;
              //  _skill3Text.text = "ü�� ȸ��";
            }




            Player.Instance._skill3++;
        }

        _choicePopUp.gameObject.SetActive(false);
        Time.timeScale = 1f;
        if(Player.Instance._playerTitle != Player.PlayerTitle.Priest)
        {
            Player.Instance.HiddenSkill(Player.Instance._playerTitle);

        }
    }



    public IEnumerator CoTimer()
    {
        if(_currentStage == GameState.Stage1 && _isBoss == false)
        {
            _timer = 60f;
            Debug.Log("�۵��ߴ�");
        }
        else if(_currentStage == GameState.Stage2 && _isBoss == false)
        {
            _timer = 90f;
        }
        else if(_currentStage == GameState.Stage3 && _isBoss == false)
        {
            _timer = 120f;
        }

        while(_timer >= 0)
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
        }
        else if (_currentStage == GameState.Stage2)
        {
            BossSpawn(_golemPool);
        }
        else if (_currentStage == GameState.Stage3)
        {
            _timer = 120f;
        }
    }
  
}
