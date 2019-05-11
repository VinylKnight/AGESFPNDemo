 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour
{
    private bool isFlashlightOn => flashlightGameObject.intensity > 0 ;

    [SerializeField]
    private Light flashlightGameObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Toggle Flashlight"))
        {
            if (isFlashlightOn)
                flashlightGameObject.intensity = 0;
            else
                flashlightGameObject.intensity = 5;
        }
    }
}
