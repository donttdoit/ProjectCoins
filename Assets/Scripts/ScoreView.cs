using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _coins;

    private Score _score;

    public void Initialize(Score score)
    {
        _score = score;
    }

    private void OnEnable()
    {
        _score.Changed += UpdateValue;
        UpdateValue(_score.Coins);
    }

    private void OnDisable() => _score.Changed -= UpdateValue;

    private void UpdateValue(int value) => _coins.text = value.ToString();

}
