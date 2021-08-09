using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpentTextScript : MonoBehaviour
{
    Text textSpent;
    public static int moneySpent = 0;


    TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textSpent = GetComponent<Text>();
        textSpent.text = "";
        textMeshPro = GetComponentInParent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = textMeshPro.text.Split('$')[0] + "$" + moneySpent.ToString();
    }
}
