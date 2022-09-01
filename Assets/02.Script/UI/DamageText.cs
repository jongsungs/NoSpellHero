using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    //public GameObject _worldObject;
    RectTransform _ui_Elemnt;
    public RectTransform _canvasRect;
    TextMeshProUGUI _text;
    private void Awake()
    {
        //_canvasRect = GetComponent<RectTransform>();
        _text = GetComponent<TextMeshProUGUI>();
        _ui_Elemnt = GetComponent<RectTransform>();
    }

  
    public void RequestDamageText(string str, Vector3 pos)
    {
        Vector2 ViewortPosition = Camera.main.WorldToViewportPoint(pos);
        Vector2 worldObject_ScreenPosition = new Vector2(
            (ViewortPosition.x * _canvasRect.sizeDelta.x) + (_canvasRect.sizeDelta.x * -0.5f),
            (ViewortPosition.y * _canvasRect.sizeDelta.y) + (_canvasRect.sizeDelta.y * -0.5f));

        _ui_Elemnt.anchoredPosition = worldObject_ScreenPosition;
        _text.text = str;
    }
    public void TextDisable()
    {
        gameObject.SetActive(false);
    }
}
