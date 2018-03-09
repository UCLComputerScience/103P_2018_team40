using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTextEffects : MonoBehaviour
{
    public float FadeTime;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Fade());
        StartCoroutine(MoveUp());
        StartCoroutine(Destory());
    }

    //https://answers.unity.com/questions/225438/slowly-fades-from-opaque-to-alpha.html
    private IEnumerator Fade()
    {
        Color colour = gameObject.GetComponent<Text>().color;
        float currentA = colour.a;
        for (float t = 0f; t < FadeTime; t += Time.deltaTime)
        {
            colour.a = Mathf.Lerp(currentA, 0, t);
            gameObject.GetComponent<Text>().color = colour;
            yield return null;
        }
    }

    private IEnumerator MoveUp()
    {
        Vector3 pos = transform.localPosition;
        float currentY = pos.y;
        for (float t = 0f; t < FadeTime; t += Time.deltaTime)
        {
            pos.y = Mathf.Lerp(currentY, 40, t);
            transform.localPosition = pos;
            yield return null;
        }
    }

    private IEnumerator Destory()
    {
        yield return new WaitForSeconds(FadeTime);
        GameObject.Destroy(gameObject);
    }
}