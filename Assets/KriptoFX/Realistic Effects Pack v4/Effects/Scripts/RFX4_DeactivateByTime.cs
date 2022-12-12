using UnityEngine;
using System.Collections;

public class RFX4_DeactivateByTime : MonoBehaviour {

    public GameObject DeactivatedGameObject;
    public float DeactivateTime = 3;

    private bool isActiveState;
    public float currentTime;
	
	void OnEnable ()
	{
        currentTime = 0;
        isActiveState = true;
	    //DeactivatedGameObject.SetActive(true);
    }

    private void Update()
    {
        DeactivateTime -= Time.deltaTime;

        if(DeactivateTime <= 0)
        {
            DeactivateTime = 0f;
        }

        if (isActiveState && 0 >= DeactivateTime)
        {
            isActiveState = false;
            DeactivatedGameObject.SetActive(false);
        }

    }
}
