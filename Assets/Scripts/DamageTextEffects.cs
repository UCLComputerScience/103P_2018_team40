using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTextEffects : MonoBehaviour
{
    public float FadeTime;
    public float MoveUpTime;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Fade());
        StartCoroutine(MoveUp());
    }

    // function adapted from https://answers.unity.com/questions/225438/slowly-fades-from-opaque-to-alpha.html
    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(MoveUpTime - FadeTime);
        Color colour = gameObject.GetComponent<Text>().color;
        float currentA = colour.a;
        for (float t = 0f; t < FadeTime; t += Time.deltaTime)
        {
            colour.a = Mathf.Lerp(currentA, 0, t / FadeTime);
            gameObject.GetComponent<Text>().color = colour;
            yield return null;
        }
    }

    private IEnumerator MoveUp()
    {
        Vector3 pos = transform.localPosition;
        float currentY = pos.y;
        for (float t = 0f; t < MoveUpTime; t += Time.deltaTime)
        {
            pos.y = Mathf.Lerp(currentY, 40, t / MoveUpTime);
            transform.localPosition = pos;
            yield return null;
        }

        GameObject.Destroy(gameObject);
    }
}