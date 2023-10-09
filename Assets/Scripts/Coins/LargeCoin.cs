using TMPro;
using UnityEngine;
using Zenject;

public class LargeCoin : Coin
{
    [SerializeField] private TMP_Text _interactText;
    private InputHandler _inputHandler;

    [Inject]
    private void Construct(InputHandler inputHandler) => _inputHandler = inputHandler;

    private bool IsInteracted;
    private void OnEnable()
    {
        _inputHandler.Interacted += Interacting;
        _inputHandler.CancelInteracted += StopInteracting;
        _interactText.text = "";
    }

    private void OnDisable()
    {
        _inputHandler.Interacted -= Interacting;
        _inputHandler.CancelInteracted -= StopInteracting;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTriggered = false;
        _interactText.text = "";
    }

    protected override void PickingCoin()
    {
        _interactText.text = $"Взаимодействие {_inputHandler.InteractKey}";
        if (IsInteracted == true)
        {
            Wallet.AddCoins(Value);
            Destroy(gameObject);
        }
    }

    private void Interacting() => IsInteracted = true;
    private void StopInteracting() => IsInteracted = false;

}
