using UnityEngine;

[CreateAssetMenu(fileName = "FactoryConfig", menuName = "Configs/FactoryConfig")]
public class FactoryConfig : ScriptableObject
{
    [SerializeField] public CoinConfig SmallCoin, LargeCoin;
}
