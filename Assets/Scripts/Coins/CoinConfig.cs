using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoinConfig
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private int _award;

    public Coin Prefab => _prefab;
    public int Award => _award;
}
