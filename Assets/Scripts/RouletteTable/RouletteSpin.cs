using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteSpin : MonoBehaviour
{
    float rotationSpeed = 1024;
    float waitTime = 4;

    [System.NonSerialized]
    public float cooldownTime = 0;
    
    [System.NonSerialized]
    public int result = 0;

    float stopTime = 0;

    float currentRotation = 0;

    public void Spin()
    {
        stopTime = Time.time + waitTime;
        cooldownTime = stopTime + waitTime;
        result = Random.Range(1, 37);
    }

    private void Update()
    {
        if (Time.time < stopTime)
        {
            currentRotation += Mathf.Lerp(0, rotationSpeed, Time.deltaTime);
        }
        else
        {
            currentRotation = Mathf.Lerp(currentRotation, 0, Time.deltaTime);
        }

        transform.rotation = Quaternion.Euler(0, currentRotation, 0);
    }
}
