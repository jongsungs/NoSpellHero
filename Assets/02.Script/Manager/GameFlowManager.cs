﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowManager : MonoBehaviour
{
    static public GameFlowManager Instance { get; private set; }
    public Fade _fade;
    public Fade _logoFade;
    public Fade _titleFade;
    public GameObject _lobby;


    public bool _isLobby = true;

    

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    


    private void Update()
    {
    }

   

   

}

