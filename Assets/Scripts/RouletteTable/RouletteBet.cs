using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteBet : MonoBehaviour
{
    public enum Condition
    {
        None,
        IsEven,
        IsOdd,
        IsLessThan,
        IsGreaterThan,
        IsEqualTo,
        PlusMinusSix

    };

    public Condition condition = Condition.None;
    public int value = 0;

    public bool CheckAgainstResult(int result)
    {
        switch (condition)
        {
            case Condition.IsEven:
                return result % 2 == 0;
            case Condition.IsOdd:
                return result % 2 != 0;
            case Condition.IsLessThan:
                return result < value;
            case Condition.IsGreaterThan:
                return result > value;
            case Condition.IsEqualTo:
                return result == value;
            case Condition.PlusMinusSix:
                return result > (value - 6) || result <= (value + 6);
            default:
                return false;
        }
    }

    public float PayOut()
    {
        switch (condition)
        {
            case Condition.IsEven:
                return 2f;
            case Condition.IsOdd:
                return 2f;
            case Condition.IsLessThan:
                return 4f;
            case Condition.IsGreaterThan:
                return 4f;
            case Condition.IsEqualTo:
                return 35f;
            case Condition.PlusMinusSix:
                return 4f;
            default:
                return 1f;
        }
    }
}
