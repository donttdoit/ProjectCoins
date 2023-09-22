using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;

public class CoinFactory
{
    private const string FactoryConfig = "FactoryConfig";
    private const string ConfigPath = "Configs";
    private CoinConfig _smallCoin, _largeCoin;
    private DiContainer _container;

    public CoinFactory(DiContainer container) 
    {
        _container = container;
        Load();
    }

    public Coin Get(CoinType type)
    {
        CoinConfig config = GetConfig(type);
        Coin coin = _container.InstantiatePrefabForComponent<Coin>(config.Prefab);
        coin.Initialize(config.Award);

        return coin;
    }

    private void Load()
    {
        _smallCoin = Resources.Load<FactoryConfig>(Path.Combine(ConfigPath, FactoryConfig)).SmallCoin;
        _largeCoin = Resources.Load<FactoryConfig>(Path.Combine(ConfigPath, FactoryConfig)).LargeCoin;
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
