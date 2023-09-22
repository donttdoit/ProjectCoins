using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SmallCoin : Coin
{
    protected override void PickingCoin()
    {
        Wallet.AddCoins(1);
        Destroy(gameObject);
    }
}
