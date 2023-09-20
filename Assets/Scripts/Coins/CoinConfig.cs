using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoinConfig
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private float _value;

    public Coin Prefab => _prefab;
    public float Value => _value;
}
