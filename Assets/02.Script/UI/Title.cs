using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Title : MonoBehaviour,IPointerDownHandler
{
       Fade fade;

     public MoreMountains.Feedbacks.MMF_Player _feedback;
    bool _istouch;
    private void Awake()
    {
        fade = GetComponent<Fade>();
        if (OnTitle.Instance._onTitle == 1)
            _istouch = false;
        else if (OnTitle.Instance._onTitle > 1)
            _istouch = true;
    }
    public void Start()
    {

        if(OnTitle.Instance._onTitle == 1 )
        StartCoroutine(coStart());
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(_istouch == true)
        this.gameObject.SetActive(false);
    }

    IEnumerator coStart()
    {
        OnTitle.Instance._onTitle++;
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            _feedback.PlayFeedbacks();
            yield return new WaitForSeconds(1f);
            _istouch = true;
        }
    }

   
}
