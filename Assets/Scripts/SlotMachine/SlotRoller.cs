using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotRoller : MonoBehaviour
{
    // Settings
    float rotationSpeed = 1024;
    float waitTime = 4;

    // Constants
    public enum ChoiceCode
    {
        Question,
        Cherry,
        Orange,
        Bar,
        Diamond,
        Grape,
        Watermelon,
        Seven3,
        Dollar,
        Bell,
        Apple,
        Horseshoe,
        Seven1,
        Lemon,
        Plum,
        Heart
    }

    const int choiceCount = 16;
    const int minRevolutions = 360 * 2;
    const float intervalRotation = 360f / choiceCount;

    // Internal State
    [System.NonSerialized]
    public ChoiceCode targetChoice = ChoiceCode.Question;

    float targetRotation = 0;
    float currentRotation = 0;

    float startTime = 0;
    float stopTime = 0;
    float cooldownTime = 0;

    void SetTarget(int i)
    {
        targetChoice = (ChoiceCode)i;
        targetRotation = intervalRotation * i + minRevolutions;
        startTime = Time.time;
        stopTime = startTime + waitTime;
        cooldownTime = stopTime + waitTime; 
        Debug.Log("Current Choice = " + targetChoice);
    }

    public void SetRandomTarget()
    {
        SetTarget(Random.Range(0, choiceCount));
    }

    public bool IsActive()
    {
        return Time.time < cooldownTime;
    }

    public void DebugLog()
    {
        Debug.Log(Mathf.Round(currentRotation) +" != "+ Mathf.Round(targetRotation));
    }

    void Update()
    {
        if (Time.time < stopTime)
        {
            currentRotation += Mathf.Lerp(0, rotationSpeed, Time.deltaTime);
        }
        else
        {
            currentRotation = Mathf.Lerp(currentRotation, targetRotation, Time.deltaTime);
        }
        
        transform.rotation = Quaternion.Euler(currentRotation, 0, 0);
    }
}
