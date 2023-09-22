public class SmallCoin : Coin
{
    protected override void PickingCoin()
    {
        Wallet.AddCoins(1);
        Destroy(gameObject);
    }
}
