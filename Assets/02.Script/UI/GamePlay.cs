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
        Start = 0,
        Stage1 = 1,
        Stage2 = 2,
        Stage3 = 3,
        Stage4 = 4,
        Result = 5,
    }


    static public GamePlay Instance { get; private set; }


    public Player _player;
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

    public GameObject _blackHole;
    
    
    
    public GameObject _blizzard;

    public bool _isBlizzard;


    public IceBall _iceball;
    public FireBall _fireball;
    


    public bool _isBoss;

    public List<Material> _listStageGroundMaterial = new List<Material>();
    public List<GameObject> _listMeteorTarget = new List<GameObject>();
    public List<SkillBase> _listMeteor = new List<SkillBase>();


    public bool _islerp;
    public float _lerp = 0;
    public float _ReverseLerp = 1f;

    public int _totalCreepScore;

    public int _stage1CreepScore;
    public int _stage2CreepScore;
    public int _stage3CreepScore;
    public int _stage4CreepScore;


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



    public GameState _currentStage;

    public bool _collectionChecks = true;
    public int _maxPoolSize = 5;
    public float[] _percent = {30,50,20};


    public delegate void EventHandler();

    public static event EventHandler _eventHandler;
    




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


        _bossHPBar.SetActive(false);
        _currentStage = GameState.Start;
        StartCoroutine(CoStartStage());
       
        _totalCreepScore = _stage1CreepScore + _stage2CreepScore + _stage3CreepScore + _stage4CreepScore;

    }

    private void Update()
    {

        _creepScoreText.GetComponent<TextMeshProUGUI>().text = _totalCreepScore.ToString();
      
        if(_stage1CreepScore >= 1 && _isBoss == false && _currentStage == GameState.Stage1)
        {
            BossSpawn(_captainSkullPool);
        }
        if (_stage2CreepScore >= 1 && _isBoss == false && _currentStage == GameState.Stage2)
        {
            BossSpawn(_golemPool);
        }
        if (_stage3CreepScore >= 1 && _isBoss == false && _currentStage == GameState.Stage3)
        {
            BossSpawn(_dragonPool);
        }
        if (_stage4CreepScore >= 1 && _isBoss == false && _currentStage == GameState.Stage4)
        {
            BossSpawn(_demonkingPool);
        }

        



        if (Input.GetKeyDown(KeyCode.R))
        {
            _eventHandler();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_blackHole.gameObject, _player._meteorPoint.transform.position + new Vector3(0,1f,0),_player.transform.rotation, _objectPool.transform);
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
            _slimePool.Get();
        }


        




        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeStage(GameState.Stage1);
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
        var target = Instantiate(_meteorTarget, _player._meteorPoint.transform.position, Quaternion.identity, _objectPool.transform);
        _listMeteorTarget.Add(target);
        _meteorPool.Get();
        StartCoroutine(_listMeteor[0].GetComponent<Meteor>().Target(target));
        
        
        return target;
    }
    private SkillBase CreateMeteor()
    {
        var meteor = Instantiate(_meteor, _player.transform.position + new Vector3(0,10,0),Quaternion.identity, _objectPool.transform);
        meteor.SetPool(_meteorPool);
        return meteor;
    }
    private SkillBase CreateWall()
    {
        var wall = Instantiate(_wall, _player._meteorPoint.transform.position, Quaternion.identity, _objectPool.transform);
        wall.SetPool(_wallPool);
        return wall;

    }
    private Decoy CreateDecoy()
    {
        var decoy = Instantiate(_decoy, _randomSpawn.Return_RandomPosition(), Quaternion.identity, _objectPool.transform);
        decoy.SetPool(_decoyPool);
        return decoy;
    }
    

    // 새로 뽑을 때
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
    private void OngetMeteor(SkillBase meteor)
    {
        meteor.gameObject.SetActive(true);
        if(_listMeteor.Count <= 1)
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
    private void OngetSkill(SkillBase skill)
    {
        skill.gameObject.SetActive(true);
    }
    private void OngetDecoy(Decoy decoy)
    {
        decoy.gameObject.SetActive(true);
    }
    // 반환할때 사라질때

    private void OnReleaseMonster(Monster obj)
    {
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


    //풀이 꽉차서 없어질때
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

    }
    public void SelectAbility()
    {
        _choicePopUp.gameObject.SetActive(false);
        Time.timeScale = 1f;
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
            case GameState.Start:
                
                break;
            case GameState.Stage1:
                
                StartCoroutine(CoStartStage1());
                

                break;
            case GameState.Stage2:
                StartCoroutine(CoStartStage2());
                
                break;
            case GameState.Stage3:
                StartCoroutine(CoStartStage3());
             
               
                break;
            case GameState.Stage4:
                StartCoroutine(CoStartStage4());
                
                break;
            case GameState.Result:
                ActiveResultPopUp();
                break;
        }    

    }
    
    IEnumerator CoStartStage()
    {
        _lerp = 0f;
        SetValue(0f, _listStageGroundMaterial[0]);
        for (int i = (int)GameState.Stage1; i < _listStageGroundMaterial.Count; ++i)
        {
            SetValue(1f, _listStageGroundMaterial[i]);
        }
        yield return new WaitForSeconds(1f);
        ChangeStage(GameState.Stage1);
        
        
    }
    IEnumerator CoStartStage1()
    {
        _lerp = 0f;
        SetValue(0f, _listStageGroundMaterial[0]);
    
        for(int i = (int)GameState.Stage1; i < _listStageGroundMaterial.Count; ++i)
        {
            SetValue(1f, _listStageGroundMaterial[i]);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 5; ++i)
        {
            _slimePool.Get();
        }

    }
    IEnumerator CoStartStage2()
    {
        for (int i = (int)GameState.Stage2; i < _listStageGroundMaterial.Count; ++i)
        {
            SetValue(1f, _listStageGroundMaterial[i]);
        }
        _lerp = 0f;
        _ReverseLerp = 1f;
        while (_lerp <= 0.99f && _ReverseLerp >= 0.01f)
        {
            yield return new WaitForSeconds(0.05f);
            _lerp += Time.deltaTime;
            _ReverseLerp -= Time.deltaTime;
            SetValue(_lerp, _listStageGroundMaterial[0]);
            SetValue(_ReverseLerp, _listStageGroundMaterial[1]);
        }
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 5; ++i)
        {
            _slimePool.Get();
        }


    }
    IEnumerator CoStartStage3()
    {
        for (int i = (int)GameState.Stage3; i < _listStageGroundMaterial.Count; ++i)
        {
            SetValue(1f, _listStageGroundMaterial[i]);
        }
        _lerp = 0f;
        _ReverseLerp = 1f;
        while (_lerp <= 0.99f && _ReverseLerp >= 0.01f)
        {
            yield return new WaitForSeconds(0.05f);
            _lerp += Time.deltaTime;
            _ReverseLerp -= Time.deltaTime;
            SetValue(_lerp, _listStageGroundMaterial[1]);
            SetValue(_ReverseLerp, _listStageGroundMaterial[2]);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 5; ++i)
        {
            _slimePool.Get();
        }

    }
    IEnumerator CoStartStage4()
    {
        for (int i = (int)GameState.Stage4; i < _listStageGroundMaterial.Count; ++i)
        {
            SetValue(1f, _listStageGroundMaterial[i]);
        }
        _lerp = 0f;
        _ReverseLerp = 1f;
        while (_lerp <= 0.99f && _ReverseLerp >= 0.01f)
        {
            yield return new WaitForSeconds(0.05f);
            _lerp += Time.deltaTime;
            _ReverseLerp -= Time.deltaTime;
            SetValue(_lerp, _listStageGroundMaterial[2]);
            SetValue(_ReverseLerp, _listStageGroundMaterial[3]);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 5; ++i)
        {
            _slimePool.Get();
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
  
}
