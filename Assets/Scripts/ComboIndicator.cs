using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboIndicator : MonoBehaviour
{
    public Text ComboNumText;

    private void Start()
    {
        GetComponent<Text>().enabled = false;
        ComboNumText.gameObject.GetComponent<Text>().enabled = false;
    }

    public void UpdateCombo(int num)
    {
        ComboNumText.text = "X " + num;
        if (num >= 1)
        {
            GetComponent<Text>().enabled = true;
            ComboNumText.gameObject.GetComponent<Text>().enabled = true;
        }
        else
        {
            GetComponent<Text>().enabled = false;
            ComboNumText.gameObject.GetComponent<Text>().enabled = false;
        }
    }
}
