using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    RectTransform _rectTrans;
    bool _isButtonDown = false;
    
    private void Awake()
    {
        _rectTrans = this.GetComponent<RectTransform>();
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        _isButtonDown = true;

        

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isButtonDown = false;
        
        
    }

    private void Update()
    {
        if(_isButtonDown)
        {
            if (_rectTrans.localScale.x >= 0.8f && _rectTrans.localScale.y >= 0.8f && _rectTrans.localScale.z >= 0.8f)
            {

                _rectTrans.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            }
            
        }
        else if(!_isButtonDown)
        {
            if (_rectTrans.localScale.x <= 0.9f && _rectTrans.localScale.y <= 0.9f && _rectTrans.localScale.z <= 0.9f)
            {
                _rectTrans.localScale += new Vector3(0.1f, 0.1f, 0.1f);

            }
        }
         
    }

}
