using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
   static public GameFlowManager Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }



}
