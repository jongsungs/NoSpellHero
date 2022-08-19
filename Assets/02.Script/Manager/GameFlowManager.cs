using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowManager : MonoBehaviour
{
   static public GameFlowManager Instance { get; private set; }
	public Fade _fade;
	


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            _fade.FadeOut(2f);
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            _fade.FadeIn(2f);
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            LoadSceneManager.LoadScene("GamePlay");
        }

    }


   

}

