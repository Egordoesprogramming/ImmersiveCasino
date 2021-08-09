using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public enum TestType
    {
        SlotRoller,
        SlotMachine
    };

    public TestType testType = TestType.SlotRoller;

    public KeyCode testKey = KeyCode.Space;

    // components
    SlotRoller slotRoller;
    SlotMachine slotMachine;

    void Start()
    {
        slotRoller = GetComponent<SlotRoller>();
        slotMachine = GetComponent<SlotMachine>();
    }

    void Update()
    {
        if (!Input.GetKeyDown(testKey))
        {
            return;
        }
        
        Debug.Log("Input.GetKeyDown(" + testKey + ")");
        
        if (testType == TestType.SlotRoller)
        {
            slotRoller.SetRandomTarget();
        }
        else if (testType == TestType.SlotMachine)
        {
            slotMachine.StartRollers();
        }
    }
}
