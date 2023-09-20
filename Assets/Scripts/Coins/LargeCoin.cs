using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeCoin : Coin
{
    protected override void PickingCoin()
    {
        Debug.Log("LargeCoin");
    }
}
