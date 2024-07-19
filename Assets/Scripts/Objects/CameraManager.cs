using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    float currentVelocity = 10f;
    float targetSize = 6.5f;
    float smoothTime = .5f;
    float maxSpeed = 10f;

    void FixedUpdate()
    {
        ZoomEffect();
    }
    private void ZoomEffect()
    {
        if (Camera.main.orthographicSize != targetSize)
        {
            Camera.main.orthographicSize = SmoothNum(Camera.main.orthographicSize, targetSize);
                
        }
    }
    private float SmoothNum(float currentNum, float targetNum)
    {
        return Mathf.SmoothDamp(
                    currentNum,
                    targetNum,
                    ref currentVelocity,
                    smoothTime,
                    maxSpeed,
                    Time.deltaTime);
    }
}
