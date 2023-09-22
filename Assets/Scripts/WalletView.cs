using TMPro;
using UnityEngine;
using Zenject;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private float _disappearCooldown = 3f;
    
    private const float DisappearTextSpeed = 3f;
    private float _disappearTextTimer;
    private Color _textColor;
    

    private Wallet _wallet;

    [Inject]
    private void Construct(Wallet wallet) => _wallet = wallet;

    private void OnEnable()
    {
        _textColor = _coinsText.color;
        _wallet.Changed += UpdateValue;
        UpdateValue(_wallet.Coins);
    }

    private void OnDisable() => _wallet.Changed -= UpdateValue;

    private void Update()
    {
        _disappearTextTimer -= Time.deltaTime;
        if (_disappearTextTimer < 0)
        {
            DisappearCoinsText();
        }
        else
        {
            _textColor.a = 1;
            _coinsText.color = _textColor;
        }
    }

    private void UpdateValue(int value) 
    { 
        _coinsText.text = value.ToString();
        _disappearTextTimer = _disappearCooldown;
    }

    private void DisappearCoinsText()
    {
        _textColor.a -= DisappearTextSpeed * Time.deltaTime;
        _coinsText.color = _textColor;
    }

}
