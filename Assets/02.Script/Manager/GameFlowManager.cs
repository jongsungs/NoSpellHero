using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowManager : MonoBehaviour
{
    static public GameFlowManager Instance { get; private set; }
    public Fade _fade;
    public Fade _logoFade;
    public Fade _titleFade;


    [SerializeField] bool _isLobby = true;



    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    private void Start()
    {
        StartCoroutine(LogoFadeStart());
    }


    private void Update()
    {
        if (_isLobby)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _fade.FadeOut(2f);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                _fade.FadeIn(2f);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                LoadSceneManager.LoadScene("GamePlay");
                _isLobby = false;
            }

        }

    }

   IEnumerator LogoFadeStart()
    {
        yield return new WaitForSeconds(1f);
        _logoFade.FadeIn(1f);
        yield return new WaitForSeconds(2f);
        _logoFade.FadeOut(1f);
        yield return new WaitForSeconds(2f);
        _titleFade.FadeIn(1f);

    }

   

}

