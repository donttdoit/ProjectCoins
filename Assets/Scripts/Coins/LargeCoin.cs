using Zenject;

public class LargeCoin : Coin
{
    private InputHandler _inputHandler;

    [Inject]
    private void Construct(InputHandler inputHandler) => _inputHandler = inputHandler;

    private bool IsInteracted;
    private void OnEnable()
    {
        _inputHandler.Interacted += Interacting;
        _inputHandler.CancelInteracted += StopInteracting;
    }

    private void OnDisable()
    {
        _inputHandler.Interacted -= Interacting;
        _inputHandler.CancelInteracted -= StopInteracting;
    }

    protected override void PickingCoin()
    {
        if (IsInteracted == true)
        {
            Wallet.AddCoins(Value);
            Destroy(gameObject);
        }
    }

    private void Interacting() => IsInteracted = true;
    private void StopInteracting() => IsInteracted = false;

}
