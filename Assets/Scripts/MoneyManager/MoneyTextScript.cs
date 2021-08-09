using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyTextScript : MonoBehaviour
{
    Text textMoney;

    TextMeshProUGUI textMeshPro;
    public static int moneyAmount = 1000;

    // Start is called before the first frame update
    void Start()
    {
        textMoney = GetComponent<Text>();
        textMoney.text = "";
        textMeshPro = GetComponentInParent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = textMeshPro.text.Split('$')[0] + "$" + moneyAmount.ToString();
    }
}
