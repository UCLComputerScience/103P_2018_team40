﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hitbar : MonoBehaviour
{
    public float MovingSpeed;
    public int BaseDamage;
    public int DmgAdds;
    public Vector2 CBRange;
    public Vector2 HBRange;
    public float HBRangeMultiplier;
    public GameObject CriticalBlock;
    public GameObject HitBlock;
    public GameObject Pointer;

    private Slider _slider;
    private GameManager _gm;
    private bool _movingDirction = true; // ture -> towards right, false -> towards left
    private bool pausing = false;
    private const int Max_Scale = 438;
    private const int Left_X_Pos = -220;
    private const int Left_X_Pos_Pointer = -215;
    private Vector2 CBValueRange;
    private Vector2 HBValueRange;


    // Use this for initialization 
    void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _slider = gameObject.GetComponent<Slider>();
        DmgAdds = 0;
        HBRangeMultiplier = 1;
    }

    private void Start()
    {
        GenerateBlocks();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            DisplayPointer();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(StopPointer());
            }
        }
        else
        {
            HidePointer();
        }
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!pausing)
        {
            if (_movingDirction)
            {
                _slider.value += MovingSpeed;
//                var pos = Pointer.transform.localPosition;
//                pos.x += (float) 2 * -Left_X_Pos_Pointer / (1 / MovingSpeed);
//                Pointer.transform.localPosition = pos;
                if (_slider.value == 1)
                {
                    _movingDirction = false;
                }
            }
            else
            {
                _slider.value -= MovingSpeed;
//                var pos = Pointer.transform.localPosition;
//                pos.x -= (float) 2 * -Left_X_Pos_Pointer / (1 / MovingSpeed);
//                Pointer.transform.localPosition = pos;
                if (_slider.value == 0)
                {
                    _movingDirction = true;
                }
            }
        }
    }

    private void DisplayPointer()
    {
        var pos = Pointer.transform.localPosition;
        pos.x = (float) 2 * -Left_X_Pos_Pointer  * _slider.value + Left_X_Pos_Pointer;
        //Debug.Log(2 * -Left_X_Pos_Pointer  * _slider.value + Left_X_Pos_Pointer);
        Pointer.transform.localPosition = pos;
        Pointer.GetComponent<Renderer>().enabled = true;
    }

    private void HidePointer()
    {
        Pointer.GetComponent<Renderer>().enabled = false;
    }
    
    private IEnumerator StopPointer()
    {
        pausing = true;
        if (CBValueRange.x < _slider.value && _slider.value < CBValueRange.y)
        {
            _gm.DmgBuffer = (BaseDamage + DmgAdds) * 2;
        }
        else if (HBValueRange.x < _slider.value && _slider.value < HBValueRange.y)
        {
            _gm.DmgBuffer = BaseDamage + DmgAdds;
        }

        yield return new WaitForSeconds(0.5f);
        pausing = false;
        GenerateBlocks();
    }

    private void GenerateBlocks()
    {
        float range = Random.Range(CBRange.x, CBRange.y) / 100.0f;
        float xValue = Random.value * (1 - range);
        CBValueRange.x = xValue;
        CBValueRange.y = xValue + range;

        int xScale = (int) (range * Max_Scale);
        int xPos = (int) (xValue * Max_Scale + Left_X_Pos);

        var pos = CriticalBlock.transform.localPosition;
        var scale = CriticalBlock.transform.localScale;
        pos.x = xPos;
        scale.x = xScale;
        CriticalBlock.transform.localPosition = pos;
        CriticalBlock.transform.localScale = scale;

        range = Random.Range(HBRange.x * HBRangeMultiplier, HBRange.y * HBRangeMultiplier) / 100.0f;
        while (true)
        {
            xValue = Random.value * (1 - range);
            HBValueRange.x = xValue;
            HBValueRange.y = xValue + range;
            if (!IfOverlap())
            {
                break;
            }
        }

        xScale = (int) (range * Max_Scale);
        xPos = (int) (xValue * Max_Scale + Left_X_Pos);

        pos = HitBlock.transform.localPosition;
        scale = HitBlock.transform.localScale;
        pos.x = xPos;
        scale.x = xScale;
        HitBlock.transform.localPosition = pos;
        HitBlock.transform.localScale = scale;
    }

    private bool IfOverlap()
    {
        if (HBValueRange.x < CBValueRange.y && HBValueRange.x > CBValueRange.x)
        {
            return true;
        }

        if (HBValueRange.y < CBValueRange.y && HBValueRange.y > CBValueRange.x)
        {
            return true;
        }

        if (HBValueRange.x < CBValueRange.x && HBValueRange.y > CBValueRange.y)
        {
            return true;
        }

        return false;
    }
}