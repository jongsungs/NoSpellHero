using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GamePlay : MonoBehaviour
{

    static public GamePlay Instance { get; private set; }


    [SerializeField] Player _player;
    public GameObject _pausePopUp;
    public GameObject _choicePopUp;
    public GameObject _bossHPBar;
    public GameObject _resultPopUp;
    public Monster _wolf;
    public Monster _slime;
    public GameObject _objectPool;
    public GameObject _spawnZone;

    private IObjectPool<Monster> _wolfpool;
    private IObjectPool<Monster> _slimePool;


    private void Awake()
    {
        Instance = this;

        _slimePool = new ObjectPool<Monster>(CreatSlime,OngetMonster,OnReleaseMonster,OnDestroyMonster,maxSize:10);
        _wolfpool = new ObjectPool<Monster>(CreatWolf, OngetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);



    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            _slimePool.Get();
           // _wolfpool.Get();

        }
    }

    private Monster CreatSlime()
    {
        var monster = Instantiate(_slime, _spawnZone.transform.position, Quaternion.identity,_objectPool.transform);
        monster.SetPool(_slimePool);
        return monster;
    }
    private Monster CreatWolf()
    {
        var monster = Instantiate(_wolf, _spawnZone.transform.position, Quaternion.identity, _objectPool.transform);
        monster.SetPool(_wolfpool);
        return monster;
    }

    // 새로 뽑을 때
    private void OngetMonster(Monster obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.position = _spawnZone.transform.position;
    }

    // 반환할때 사라질때

    private void OnReleaseMonster(Monster obj)
    {
        obj.gameObject.SetActive(false);
    }

    //풀이 꽉차서 없어질때
    private void OnDestroyMonster(Monster obj)
    {
        Destroy(obj.gameObject);
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


}
