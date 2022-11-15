using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.UI;
using TMPro;


public class ServiceManager : MonoBehaviour
{
    private static ServiceManager _instance;
    public static ServiceManager Instance
    {
        get
        {
            if (_instance == null) _instance = new ServiceManager();
            return _instance;
        }
    }
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;

    private bool _authenticating = false;
    public bool Authenticated { get { return Social.Active.localUser.authenticated; } }

    //list of achievements we know we have unlocked (to avoid making repeated calls to the API)
    private Dictionary<string, bool> _unlockedAchievements = new Dictionary<string, bool>();

    //achievement increments we are accumulating locally, waiting to send to the games API
    private Dictionary<string, int> _pendingIncrements = new Dictionary<string, int>();

    private void Start()
    {
        PlayGamesPlatform.Activate();
        SignInToGooglePlay();
    }
    //GooglePlayGames �ʱ�ȭ
    //public void Initialize()
    //{
    //    //PlayGamesPlatform �α� Ȱ��ȭ/��Ȱ��ȭ
    //    PlayGamesPlatform.DebugLogEnabled = false;
    //    //Social.Active �ʱ�ȭ
    //    PlayGamesPlatform.Activate();
    //    Debug.Log("����");
    //}

    private void Update()
    {
        Debug.Log(Social.localUser.authenticated);
        text.text = Social.localUser.authenticated.ToString();
        text2.text = Social.localUser.userName.ToString();
    }
    //GooglePlayGames �α���
    public void SignInToGooglePlay()
    {
        if (Authenticated || _authenticating)
        {
            Debug.LogWarning("Ignoring repeated call to Authenticate().");
            return;
        }

        _authenticating = true;
        Social.localUser.Authenticate((bool success) =>
        {
            _authenticating = false;
            if (success)
            {
                Debug.Log("Sign in successful!");
            }
            else
            {
                Debug.LogWarning("Failed to sign in with Google Play");
            }
        });
    }

    //GooglePlayGames �α׾ƿ�
   // public void SignOutFromGooglePlay()
   // {
   //     GooglePlayGames.PlayGamesPlatform.Instance.SignOut();
   // }

    //���� ��ȸ�ϱ�
    public void ShowGooglePlayAchievements()
    {
        if (false == Social.localUser.authenticated)
            return;
            Social.ShowAchievementsUI();
        
    }

    //�������� ��ȸ�ϱ�
    public void ShowLeaderboardUI()
    {
        if (false == Social.localUser.authenticated)
            return;
            Social.ShowLeaderboardUI();
        
    }
}
