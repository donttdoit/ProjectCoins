using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public int Coins { get; private set; } = 0;

    public Action<int> Changed;

    //public Wallet(int coins)
    //{
    //    Coins = coins;
    //}

    public void AddCoins(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Coins += value;
        Changed?.Invoke(Coins);
    }

    public void SpendScore(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Coins -= value;
        Changed?.Invoke(Coins);
    }
}
