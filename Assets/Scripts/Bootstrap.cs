using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;
    private const int StartCoins = 0;

    private void Awake()
    {
        Score score = new Score(StartCoins);
        _coinSpawner.StartWork();
    }
}
