using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasinoChip : MonoBehaviour
{
    Vector3 startPosition;
    Quaternion startRotation;

    RouletteBet heldBet;

    bool isFinalized = false;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;    
    }

    void ResetTransform()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (isFinalized)
            return;

        var bet = other.gameObject.GetComponent<RouletteBet>();
        if (bet != null)
            heldBet = bet;
    }

    public void FinalizeBet()
    {
        isFinalized = true;
    }

    public void OpenBet()
    {
        ResetTransform();
        isFinalized = false;
    }

    public bool CheckAgainstResult(int result)
    {
        return heldBet != null && heldBet.CheckAgainstResult(result);
    }


    public float PayOut()
    {
       return heldBet.PayOut();
    }

    public RouletteBet.Condition GetCondition()
    {
        if (heldBet != null)
        {
            return heldBet.condition;
        }
        return RouletteBet.Condition.None;
    }
}
