using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hitbar : MonoBehaviour
{
    public float MovingSpeed;
    public float BaseDamage;
    public float DmgAdds;
    public int GoodBreathReward;
    public Vector2 RandomDmgRange;
    public Vector2 CBRange;
    public Vector2 HBRange;
    public float HBRangeMultiplier;
    public GameObject CriticalBlock;
    public GameObject HitBlock;
    public GameObject Pointer;
    public GameManager Gm;
    public bool GoodBreath;
    public bool BadBreath;

    private Slider _slider;
    private bool _movingDirction = true; // ture -> towards right, false -> towards left
    private bool _pausing = false;
    private int _comboNum;
    private const int MaxScale = 438;
    private const int LeftXPos = -220;
    private const int LeftXPosPointer = -215;
    private Vector2 CBValueRange;
    private Vector2 HBValueRange;


    // Use this for initialization 
    void Awake()
    {
        _slider = gameObject.GetComponent<Slider>();
        DmgAdds = 0;
        RandomDmgRange.x = 1;
        RandomDmgRange.y = 1;
        HBRangeMultiplier = 1;
        GoodBreath = false;
        BadBreath = false;
        _comboNum = 0;
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
            if (Input.GetKeyDown(KeyCode.Return) && !_pausing)
            {
                StartCoroutine(StopPointer());
            }
        }
        else
        {
            Pointer.GetComponent<Renderer>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.A)) // simulate good breath
        {
            GoodBreath = true;
        }
        else if (Input.GetKeyDown(KeyCode.B)) // simulate good breath
        {
            BadBreath = true;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!_pausing)
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

        if (GoodBreath)
        {
            GoodBreath = false;
            _comboNum += 1;
            Gm.ChangeCoinNum(GoodBreathReward * (1 + _comboNum / 10));
            Gm.ShowCombo(_comboNum);
        }
        else if (BadBreath)
        {
            BadBreath = false;
            _comboNum = 0;
            Gm.ShowCombo(_comboNum);
        }
    }

    private void DisplayPointer()
    {
        var pos = Pointer.transform.localPosition;
        pos.x = (float) 2 * -LeftXPosPointer * _slider.value + LeftXPosPointer;
        Pointer.transform.localPosition = pos;
        Pointer.GetComponent<Renderer>().enabled = true;
    }

    private IEnumerator StopPointer()
    {
        _pausing = true;
        var dmgMultiplier = Random.Range(RandomDmgRange.x, RandomDmgRange.y);
        if (CBValueRange.x < _slider.value && _slider.value < CBValueRange.y)
        {
            Gm.Hit((int) ((BaseDamage + DmgAdds) * 2 * dmgMultiplier));
        }
        else if (HBValueRange.x < _slider.value && _slider.value < HBValueRange.y)
        {
            Gm.Hit((int) ((BaseDamage + DmgAdds) * dmgMultiplier));
        }

        yield return new WaitForSeconds(0.5f);
        _pausing = false;
        GenerateBlocks();
    }

    private void GenerateBlocks()
    {
        // calc range for critical block
        float range = Random.Range(CBRange.x, CBRange.y) / 100.0f;
        float xValue = Random.value * (1 - range);
        CBValueRange.x = xValue;
        CBValueRange.y = xValue + range;

        int xScale = (int) (range * MaxScale);
        int xPos = (int) (xValue * MaxScale + LeftXPos);

        var pos = CriticalBlock.transform.localPosition;
        var scale = CriticalBlock.transform.localScale;
        pos.x = xPos;
        scale.x = xScale;
        CriticalBlock.transform.localPosition = pos;
        CriticalBlock.transform.localScale = scale;

        // calc range for hitblock
        range = Random.Range(HBRange.x * HBRangeMultiplier, HBRange.y * HBRangeMultiplier) / 100.0f;
        if (range + CBRange.y / 200.0f >= 0.5f) // range too large
        {
            range = 0.5f - CBRange.y / 200.0f;
        }

        do
        {
            xValue = Random.value * (1 - range);
            HBValueRange.x = xValue;
            HBValueRange.y = xValue + range;
        } while (IfOverlap()); // prevent green block overlapping with yellow one

        xScale = (int) (range * MaxScale);
        xPos = (int) (xValue * MaxScale + LeftXPos);

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