using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;

    private void Awake()
    {
        _coinSpawner.StartWork();
    }
}
