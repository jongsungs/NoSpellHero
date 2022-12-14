using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTitle : MonoBehaviour
{
    static public OnTitle Instance { get; private set; }
    public int _onTitle;

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this);

        _onTitle++;
    }
}
