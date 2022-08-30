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
    public Monster _monsterList;

    private IObjectPool<Monster> _monsterPool;


    private void Awake()
    {
        Instance = this;
        _monsterPool = new ObjectPool<Monster>(CreatMonser,OngetMonster,OnReleaseMonster,OnDestroyMonster,maxSize:10);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _monsterPool.Get();
        }
    }

    private Monster CreatMonser()
    {
        var monster = Instantiate(_monsterList, transform.position, Quaternion.identity);
        monster.SetPool(_monsterPool);
        return monster;
    }
    private void OngetMonster(Monster obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.position = _player.transform.position;
    }
    private void OnReleaseMonster(Monster obj)
    {
        obj.gameObject.SetActive(false);
    }
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
