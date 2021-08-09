using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    public Text countTextWin;
    public Text countTextLost;
    private int countWin;
    private int countLost;

    bool IsSpinning = false;

    SlotRoller[] rollers;
    SlotArm arm;

    List<SlotRoller.ChoiceCode> choices = new List<SlotRoller.ChoiceCode>();

    void Start()
    {
        rollers = GetComponentsInChildren<SlotRoller>();
        arm = GetComponentInChildren<SlotArm>();
        countWin = 0;
        countTextWin.text = countWin.ToString();
        countLost = 0;
        countTextLost.text = countLost.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            arm.DebugLog();
            rollers[0].DebugLog();
        }

        if (ShouldUpdateStats())
        {
            IsSpinning = false;
            UpdateStats();
        }

        if (arm.IsActive() && !IsSpinning)
        {
            IsSpinning = true;
            StartRollers();
        }
    }

    bool IsReadyToRoll()
    {
        foreach (var roller in rollers)
        {
            if (roller.IsActive())
                return false;
        }

        return true;
    }

    bool ShouldUpdateStats()
    {
        return IsSpinning && IsReadyToRoll();
    }

    public void StartRollers()
    {
        choices.Clear();

        foreach (var roller in rollers)
        {
            roller.SetRandomTarget();
            choices.Add(roller.targetChoice);
        }
    }

    void UpdateStats()
    {
        if (Utilities.AllSame(choices))
        {
            Debug.Log("3 " + choices[0] + "s in a row!");
            countWin = countWin + 1;
            countTextWin.text = countWin.ToString();
        }
        else
        {
            countLost = countLost + 1;
            countTextLost.text = countLost.ToString();
            MoneyTextScript.moneyAmount -= 10;
            SpentTextScript.moneySpent += 10;
        }
    }
}