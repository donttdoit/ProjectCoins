using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinFactory", menuName = "Factory/CoinFactory")]
public class CoinFactory : ScriptableObject
{
    [SerializeField] private CoinConfig _smallCoin, _largeCoin;

    public Coin Get(CoinType type)
    {
        CoinConfig config = GetConfig(type);
        Coin coin = Instantiate(config.Prefab);
        coin.Initialize(config.Value);

        return coin;
    }

    private CoinConfig GetConfig(CoinType type)
    {
        switch (type)
        {
            case CoinType.Small:
                return _smallCoin;

            case CoinType.Large:
                return _largeCoin;

            default:
                throw new ArgumentException(nameof(type));
        }
    }
}
