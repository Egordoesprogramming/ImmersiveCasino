using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteTable : MonoBehaviour
{
    public Text countTextWin;
    public Text countTextLost;
    public Text Result;
    private int countWin;
    private int countLost;
    private int resultNum;

    CasinoChip[] chips;
    RouletteSpin rouletteSpin;

    bool IsSpinning = false;

    void Start()
    {
        rouletteSpin = GetComponentInChildren<RouletteSpin>();

        chips = FindObjectsOfType<CasinoChip>();
        if (chips.Length == 0)
        {
             Debug.Log("RouletteTable can't find any CasinoChips!");
        }

        countWin = 0;
        countTextWin.text = countWin.ToString();
        countLost = 0;
        countTextLost.text = countLost.ToString();
    }

    void Update()
    {
        if (ShouldOpenBets())
        {
            OpenBets();
            IsSpinning = false;
            CheckResults(rouletteSpin.result);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !IsSpinning)
        {
            Spin();
            IsSpinning = true;
        }
    }
    bool ShouldOpenBets()
    {
        return IsSpinning && Time.time >= rouletteSpin.cooldownTime;
    }

    public void Spin()
    {
        FinalizeBets();
        rouletteSpin.Spin();
    }

    void FinalizeBets()
    {
        foreach (var chip in chips)
        {
            chip.FinalizeBet();
        }
    }

    void OpenBets()
    {
        foreach (var chip in chips)
        {
            chip.OpenBet();
        }
    }

    void CheckResults(int result)
    {
        int winCount = 0;
        int lossCount = 0;
        int betAmount = 10;
        int winAmount = 0; 

        foreach (var chip in chips)
        {
            if (chip.CheckAgainstResult(result))
            {
                SpentTextScript.moneySpent += 10;

                ++winCount;
                countWin = winCount;
                countTextWin.text = countWin.ToString();

                winAmount +=(int) (betAmount * chip.PayOut());
                WonTextScript.moneyWon += winAmount;
                MoneyTextScript.moneyAmount += winAmount;
            }
            else if (chip.GetCondition() != RouletteBet.Condition.None)
            {
                MoneyTextScript.moneyAmount -= 10;
                SpentTextScript.moneySpent += 10;
                ++lossCount;
                countLost = lossCount;
                countTextLost.text = countLost.ToString();

            }
        }

        resultNum = result;
        Result.text = resultNum.ToString();

        Debug.Log("With result = " + result);
        Debug.Log("You won " + winCount + " bets this round.");
        Debug.Log("You won " + winAmount);

    }
}
