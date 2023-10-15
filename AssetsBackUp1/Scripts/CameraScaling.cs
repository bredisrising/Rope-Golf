using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaling : MonoBehaviour
{
    [SerializeField] float targetRatio;
    [SerializeField] float boundsX;
    public float[] boundsY;

    [SerializeField] Manager manager;

    float screenRatio;
    float difference;
    void Start()
    {
        

        screenRatio = (float)Screen.width / (float)Screen.height;

        if(screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = boundsY[manager.currentLvlIndex] / 2;
        }
        else
        {
            difference = targetRatio / screenRatio;
            Camera.main.orthographicSize = boundsY[manager.currentLvlIndex] / 2 * difference;
        }
    }

    private void Update()
    {
        screenRatio = (float)Screen.width / (float)Screen.height;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = boundsY[manager.currentLvlIndex] / 2;
        }
        else
        {
            difference = targetRatio / screenRatio;
            Camera.main.orthographicSize = boundsY[manager.currentLvlIndex] / 2 * difference;
        }
    }





}
