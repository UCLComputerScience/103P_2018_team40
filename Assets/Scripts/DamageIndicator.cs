using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public GameObject DmgTextPrefab;

    public void ShowDmg(float dmg)
    {
        var text = Instantiate(DmgTextPrefab);
        text.transform.position = transform.position;
        text.transform.SetParent(transform,false); 
        text.transform.localScale = new Vector3(1, 1, 1);
        text.GetComponent<Text>().text = "-" + dmg;
    }
}