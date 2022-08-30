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

        _monsterPool = new ObjectPool<Monster>(CreatMonser);

        

    }

    private Monster CreatMonser()
    {
        var monster = Instantiate(_monsterList, transform.position, Quaternion.identity);
        return monster;
    }
    private void OngetMonster(GameObject obj)
    {

    }
    private void OnReleaseMonster(GameObject obj)
    {

    }
    private void OnDestroyMonster(GameObject obj)
    {

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
