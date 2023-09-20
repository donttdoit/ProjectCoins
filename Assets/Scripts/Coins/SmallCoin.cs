using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCoin : Coin
{
    protected override void PickingCoin()
    {
        Debug.Log("SmallCoin");
    }
}
