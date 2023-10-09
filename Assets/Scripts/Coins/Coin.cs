using UnityEngine;
using Zenject;

public abstract class Coin : MonoBehaviour
{
    public Vector2 Position { get => transform.position; set => transform.position = value; }

    protected int Value { get; private set; } = 0;
    protected Wallet Wallet;
    protected bool IsTriggered;

    [Inject]
    private void Construct(Wallet wallet) => Wallet = wallet;

    public void Initialize(int value) => Value = value;

    private void Update()
    {
        if (IsTriggered == true)
            PickingCoin();
    }

    private void OnTriggerEnter2D(Collider2D collision) => IsTriggered = true;
    private void OnTriggerExit2D(Collider2D collision) => IsTriggered = false;

    protected abstract void PickingCoin();
}
