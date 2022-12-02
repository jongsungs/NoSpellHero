using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleFlow : MonoBehaviour
{
    public Fade _logoFade;
    public Fade _titleFade;

    [SerializeField] bool _istouch = false;



    private void Start()
    {
        StartCoroutine(LogoFadeStart());
    }


    IEnumerator LogoFadeStart()
    {
        yield return new WaitForSeconds(1f);
        _logoFade.FadeIn(1f);
        yield return new WaitForSeconds(2f);
        _logoFade.FadeOut(1f);
        yield return new WaitForSeconds(2f);
        LoadSceneManager.LoadScene("Lobby");
        


    }

    
}
