using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public int Coins { get; private set; }

    public Action<int> Changed;

    public Score(int coins)
    {
        Coins = coins;
    }

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
