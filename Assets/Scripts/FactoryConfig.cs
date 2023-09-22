using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FactoryConfig", menuName = "Factory/FactoryConfig")]
public class FactoryConfig : ScriptableObject
{
    [SerializeField] public CoinConfig SmallCoin, LargeCoin;
}
