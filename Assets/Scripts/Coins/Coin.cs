using UnityEngine;
using Zenject;

public abstract class Coin : MonoBehaviour
{
    public Vector2 Position { get => transform.position; set => transform.position = value; }

    protected int Value { get; private set; } = 0;

    protected Wallet Wallet;

    [Inject]
    private void Construct(Wallet wallet) { Wallet = wallet; }

    public void Initialize(int value) => Value = value;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PickingCoin();
    }

    protected abstract void PickingCoin();
}
