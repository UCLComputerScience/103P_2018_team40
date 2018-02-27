using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hitbar : MonoBehaviour
{
    public float MovingSpeed;
    public GameObject CriticalBlock;
    public GameObject HitBlock;
    public Vector2 CBRange;
    public Vector2 HBRange;

    private Slider _slider;
    private bool _movingDirction = true; // ture -> towards right, false -> towards left
    private const int Max_Scale = 438;
    private const int Left_X_Pos = -220;
    private Vector2 CBValueRange;
    private Vector2 HBValueRange;

    // Use this for initialization 
    void Awake()
    {
        _slider = gameObject.GetComponent<Slider>();
    }

    private void Start()
    {
        GenerateBlocks();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_movingDirction)
        {
            _slider.value += MovingSpeed;
            if (_slider.value == 1)
            {
                _movingDirction = false;
            }
        }
        else
        {
            _slider.value -= MovingSpeed;
            if (_slider.value == 0)
            {
                _movingDirction = true;
            }
        }
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

        // TODO: hit bar should not overlap with critical bar
        range = Random.Range(HBRange.x, HBRange.y) / 100.0f;
        while (true)
        {
            xValue = Random.value * (1 - range);
            HBValueRange.x = xValue;
            HBValueRange.y = xValue + range;
            if (!ifOverlap())
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

    private bool ifOverlap()
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