using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entry : MonoBehaviour
{
    private Text _rankText;
    private Text _scoreText;
    private Text _nameText;

    private void Awake()
    {
        _rankText = gameObject.transform.Find("RankText").gameObject.GetComponent<Text>();
        _scoreText = gameObject.transform.Find("ScoreText").gameObject.GetComponent<Text>();
        _nameText = gameObject.transform.Find("NameText").gameObject.GetComponent<Text>();
    }

    public void SetEntry(string rank, string score, string username)
    {
        _rankText.text = rank;
        _scoreText.text = score.PadLeft(11, '0');
        _nameText.text = username;
    }
}