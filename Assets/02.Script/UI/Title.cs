using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Title : MonoBehaviour,IPointerDownHandler
{
    Fade fade;

    private void Start()
    {
        fade = GetComponent<Fade>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("ŸġŸġ");
        LoadSceneManager.LoadScene("Lobby");
    }

   
}
