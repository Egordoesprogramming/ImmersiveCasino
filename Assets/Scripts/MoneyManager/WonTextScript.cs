using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WonTextScript : MonoBehaviour
{
    Text textWon;
    public static int moneyWon = 0;


    TextMeshProUGUI textMeshPro;

    void Start()
    {
        textWon = GetComponent<Text>();
        textWon.text = "";
        textMeshPro = GetComponentInParent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMeshPro.text = textMeshPro.text.Split('$')[0] + "$" + moneyWon.ToString();
    }
}
